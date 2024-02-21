using System;
using System.Collections.Generic;
using System.Linq;

namespace Sytner.Utilities.ServiceResult
{
    /// <summary>
    /// <see cref="ServiceResult"/> extension methods.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Convert a <see cref="ServiceResult"/> to a <see cref="ServiceResult{T}"/>
        /// preserving the <see cref="ServiceResultCode"/>, validation errors &amp; error message as appropriate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceResult"></param>
        /// <param name="value"></param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// If converting a successful code, the original ServiceResult.Content value (if any) will be replaced with <paramref name="value"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException"/>
        public static ServiceResult<T> ToType<T>(this ServiceResult serviceResult, T value = default)
        {
            if (serviceResult == null)
            {
                throw new ArgumentNullException(nameof(serviceResult));
            }

            switch (serviceResult.ResultCode)
            {
                //InvalidInput may have validation errors OR error message
                case ServiceResultCode.InvalidInput:
                    if (serviceResult.ValidationErrors?.Any() ?? false)
                    {
                        return new ServiceResult<T>
                            (
                                serviceResult.ResultCode,
                                serviceResult.ValidationErrors.Select(x => new KeyValuePair<string, string>(x.Identifier, x.Message)),
                                serviceResult.ErrorMessage
                            );
                    }
                    return new ServiceResult<T>(serviceResult.ResultCode, serviceResult.ErrorMessage);

                //Codes with error message
                case ServiceResultCode.Conflict:
                case ServiceResultCode.NotAuthenticated:
                case ServiceResultCode.NotFound:
                case ServiceResultCode.InternalError:
                case ServiceResultCode.ExternalError:
                case ServiceResultCode.ExternalErrorNoRetry:
                case ServiceResultCode.Forbidden:
                    return new ServiceResult<T>(serviceResult.ResultCode, serviceResult.ErrorMessage);

                //Codes with T values (everything else: Created, Accepted, Success)
                default:
                    return new ServiceResult<T>(serviceResult.ResultCode, value);
            }
        }

    }
}
