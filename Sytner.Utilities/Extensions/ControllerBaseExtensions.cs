using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sytner.Utilities.ServiceResult;

namespace Sytner.Utilities.AspNetCore.Extensions
{
    /// <summary>
    /// Extensions for the <see cref="ControllerBase"/> class to remove need for inheritance
    /// </summary>
    public static class ControllerBaseExtensions
    {
        /// <summary>
        /// Converts a result from the service tier into a result from the API tier
        /// </summary>
        /// <param name="controller">The controller to extend</param>
        /// <param name="result">The service result</param>
        /// <param name="requestHadPreconditions">true if the request carried preconditions, false otherwise</param>
        /// <returns>An <see cref="IActionResult"/> of type <see cref="JsonResult"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IActionResult ServiceResultToActionResult(this ControllerBase controller, ServiceResult.ServiceResult result, bool requestHadPreconditions = false)
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));
            if (result == null) throw new ArgumentNullException(nameof(result));

            var statusCode = result.ResultCode.ToHttpStatusCode(false, requestHadPreconditions);
            if (result.IsSuccessful)
            {
                return controller.StatusCode(statusCode);
            }
            else
            {
                return GetErrorActionResult(statusCode, result);
            }
        }

        /// <summary>
        /// Converts a result from the service tier into a result from the API tier
        /// </summary>
        /// <typeparam name="T">The type of the ServiceResult content</typeparam>
        /// <param name="controller">The controller to extend</param>
        /// <param name="result">The service result</param>
        /// <param name="requestHadPreconditions">true if the request carried preconditions, false otherwise</param>
        /// <returns>An <see cref="IActionResult"/> of type <see cref="JsonResult"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IActionResult ServiceResultToActionResult<T>(this ControllerBase controller, ServiceResult<T> result, bool requestHadPreconditions = false)
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));
            if (result == null) throw new ArgumentNullException(nameof(result));

            var statusCode = result.ResultCode.ToHttpStatusCode(result.Content != null, requestHadPreconditions);
            if (result.IsSuccessful)
            {
                return new JsonResult(result.Content) { StatusCode = statusCode };
            }
            else
            {
                return GetErrorActionResult(statusCode, result);
            }
        }

        /// <summary>
        /// Converts a result from the service tier into a result from the API tier
        /// </summary>
        /// <typeparam name="T">The type in the ServiceResult content collection</typeparam>
        /// <param name="controller">The controller to extend</param>
        /// <param name="result">The service result</param>
        /// <param name="requestHadPreconditions">true if the request carried preconditions, false otherwise</param>
        /// <returns>An <see cref="IActionResult"/> of type <see cref="JsonResult"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IActionResult ServiceResultToActionResult<T>(this ControllerBase controller, ServiceResult<IEnumerable<T>> result, bool requestHadPreconditions = false)
        {
            if (controller == null) throw new ArgumentNullException(nameof(controller));
            if (result == null) throw new ArgumentNullException(nameof(result));

            var statusCode = result.ResultCode.ToHttpStatusCode(result.Content != null, requestHadPreconditions);
            if (result.IsSuccessful)
            {
                controller.Response.Headers.Add("Total-Count", result.Content.Count().ToString());
                return new JsonResult(result.Content) { StatusCode = statusCode };
            }
            else
            {
                return GetErrorActionResult(statusCode, result);
            }
        }

        /// <summary>
        /// Gets the correct failure result for a service result status code
        /// </summary>
        /// <param name="statusCode">The status code to set on the response</param>
        /// <param name="result">The service result object with any error messages to include in the response</param>
        /// <returns>An <see cref="IActionResult"/> of type <see cref="JsonResult"/></returns>
        internal static IActionResult GetErrorActionResult(int statusCode, ServiceResult.ServiceResult result)
        {
            // try returning validation errors by default, for consistency wrap the error message in a list of validation errors
            if (statusCode == (int)HttpStatusCode.BadRequest)
            {
                var validationErrors = result.ValidationErrors;
                if (!result.ValidationErrors.Any())
                {
                    validationErrors = new List<ValidationError>
                    {
                        new ValidationError("ErrorMessage", result.ErrorMessage)
                    };
                }

                return new JsonResult(validationErrors) { StatusCode = statusCode };
            }

            // Ensure returned message is valid JSON
            var jsonError = JsonConvert.SerializeObject(result.ErrorMessage);
            return new JsonResult(jsonError) { StatusCode = statusCode };
        }
    }
}
