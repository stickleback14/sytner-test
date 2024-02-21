using System.Collections.Generic;

namespace Sytner.Utilities.ServiceResult
{
    /// <summary>
    /// Domain tier Service Result
    /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// The default error message used when invoking the ServiceResult.InvalidInput(validationErrors) extension method
        /// </summary>
        protected const string DefaultInvalidErrorMessage = "Validation errors were found";

        /// <summary>
        /// Initialises a new instance of the <see cref="ServiceResult"/> class
        /// </summary>
        /// <param name="code">The result code appropriate to the operation</param>
        public ServiceResult(ServiceResultCode code)
        {
            ResultCode = code;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ServiceResult"/> class
        /// </summary>
        /// <param name="code">The result code appropriate to the operation</param>
        /// <param name="errorMessage">The error message in the event of a failure</param>
        public ServiceResult(ServiceResultCode code, string errorMessage)
        {
            ResultCode = code;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ServiceResult"/> class
        /// </summary>
        /// <param name="code">The result code appropriate to the operation</param>
        /// <param name="validationErrors">The validation error messages for the supplied values</param>
        /// <param name="errorMessage">The error message in the event of a failure</param>
        public ServiceResult(ServiceResultCode code, IEnumerable<KeyValuePair<string, string>> validationErrors, string errorMessage)
        {
            ResultCode = code;
            ErrorMessage = errorMessage;

            if (validationErrors != null)
            {
                foreach (var item in validationErrors)
                {
                    ValidationErrors.Add(new ValidationError(item.Key, item.Value));
                }
            }
        }

        /// <summary>
        /// Gets the result code for the service operation
        /// </summary>
        public ServiceResultCode ResultCode { get; }

        /// <summary>
        /// The ResultCode is Success, Created or Accepted
        /// </summary>
        public bool IsSuccessful => ResultCode == ServiceResultCode.Success || ResultCode == ServiceResultCode.Created || ResultCode == ServiceResultCode.Accepted;

        /// <summary>
        /// Gets the error message for the service operation
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Gets the validation errors for the supplied values
        /// </summary>
        public IList<ValidationError> ValidationErrors { get; } = new List<ValidationError>();

        /// <summary>
        /// Creates a service result indicating an entity was created
        /// </summary>
        /// <returns>The service result</returns>
        public static ServiceResult Created() => new ServiceResult(ServiceResultCode.Created);

        /// <summary>
        /// Creates a service result indicating an instruction was accepted
        /// </summary>
        /// <returns>The service result</returns>
        public static ServiceResult Accepted() => new ServiceResult(ServiceResultCode.Accepted);

        /// <summary>
        /// Creates a service result indicating success
        /// </summary>
        /// <returns>The service result</returns>
        public static ServiceResult Success() => new ServiceResult(ServiceResultCode.Success);

        /// <summary>
        /// Creates a service result indicating the operation could not be completed due to a conflict
        /// </summary>
        /// <param name="errorMessage">The operation error message</param>
        /// <returns>The service result</returns>
        public static ServiceResult Conflict(string errorMessage = "") => new ServiceResult(ServiceResultCode.Conflict, errorMessage);

        /// <summary>
        /// Creates a service result indicating the user is not authenticated
        /// </summary>
        /// <param name="errorMessage">The operation error message</param>
        /// <returns>The service result</returns>
        public static ServiceResult NotAuthenticated(string errorMessage = "") => new ServiceResult(ServiceResultCode.NotAuthenticated, errorMessage);

        /// <summary>
        /// Creates a service result indicating supplied values are invalid
        /// </summary>
        /// <param name="errorMessage">The operation error message</param>
        /// <returns>The service result</returns>
        public static ServiceResult InvalidInput(string errorMessage = "") => new ServiceResult(ServiceResultCode.InvalidInput, errorMessage);

        /// <summary>
        /// Creates a service result indicating supplied values are invalid
        /// </summary>
        /// <param name="validationErrors">The validation error messages for the supplied values</param>
        /// <returns>The service result</returns>
        public static ServiceResult InvalidInput(IEnumerable<KeyValuePair<string, string>> validationErrors) => new ServiceResult(ServiceResultCode.InvalidInput, validationErrors, DefaultInvalidErrorMessage);

        /// <summary>
        /// Creates a service result indicating an entity was not found
        /// </summary>
        /// <param name="errorMessage">The operation error message</param>
        /// <returns>The service result</returns>
        public static ServiceResult NotFound(string errorMessage = "") => new ServiceResult(ServiceResultCode.NotFound, errorMessage);

        /// <summary>
        /// Creates a service result indicating an internal error occurred
        /// </summary>
        /// <param name="errorMessage">The operation error message</param>
        /// <returns>The service result</returns>
        public static ServiceResult InternalError(string errorMessage = "") => new ServiceResult(ServiceResultCode.InternalError, errorMessage);

        /// <summary>
        /// Creates a service result indicating an external error occurred
        /// </summary>
        /// <param name="errorMessage">The operation error message</param>
        /// <returns>The service result</returns>
        public static ServiceResult ExternalError(string errorMessage = "") => new ServiceResult(ServiceResultCode.ExternalError, errorMessage);

        /// <summary>
        /// Creates a service result indicating an external error occurred and the operation should not be retried
        /// </summary>
        /// <param name="errorMessage">The operation error message</param>
        /// <returns>The service result</returns>
        public static ServiceResult ExternalErrorNoRetry(string errorMessage = "") => new ServiceResult(ServiceResultCode.ExternalErrorNoRetry, errorMessage);

        /// <summary>
        /// Creates a service result indicating that the client is not authorised to perform the operation
        /// </summary>
        /// <param name="errorMessage">The operation error message</param>
        /// <returns>The service result</returns>
        public static ServiceResult Forbidden(string errorMessage = "") => new ServiceResult(ServiceResultCode.Forbidden, errorMessage);

    }
}
