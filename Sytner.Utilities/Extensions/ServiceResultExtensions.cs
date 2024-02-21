using System.Net;
using Sytner.Utilities.ServiceResult;

namespace Sytner.Utilities.AspNetCore.Extensions
{
    /// <summary>
    /// Extensions for the domain service result
    /// </summary>
    public static class ServiceResultExtensions
    {
        /// <summary>
        /// Converts a result code from the domain into a result for the HTTP API
        /// </summary>
        /// <param name="code">The service result</param>
        /// <param name="responseHasContent">true if the response carries content, false otherwise</param>
        /// <param name="requestHadPreconditions">true if the request carried preconditions, false otherwise</param>
        /// <returns>The appropriate <see cref="HttpStatusCode"/></returns>
        public static int ToHttpStatusCode(this ServiceResultCode code, bool responseHasContent = true, bool requestHadPreconditions = false)
        {
            int result = (int)HttpStatusCode.NotImplemented;

            switch (code)
            {
                case ServiceResultCode.Created:
                    result = (int)HttpStatusCode.Created;
                    break;
                case ServiceResultCode.Accepted:
                    result = (int)HttpStatusCode.Accepted;
                    break;
                case ServiceResultCode.Success:
                    result = responseHasContent ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NoContent;
                    break;
                case ServiceResultCode.Conflict:
                    result = requestHadPreconditions ? (int)HttpStatusCode.PreconditionFailed : (int)HttpStatusCode.Conflict;
                    break;
                case ServiceResultCode.InvalidInput:
                    result = (int)HttpStatusCode.BadRequest;
                    break;
                case ServiceResultCode.NotFound:
                    result = (int)HttpStatusCode.NotFound;
                    break;
                case ServiceResultCode.ExternalError:
                    // Bad gateway implies temporary unavailability and therefore the request should be retried
                    result = (int)HttpStatusCode.BadGateway;
                    break;
                case ServiceResultCode.ExternalErrorNoRetry:
                case ServiceResultCode.InternalError:
                    result = (int)HttpStatusCode.InternalServerError;
                    break;
                case ServiceResultCode.Forbidden:
                    result = (int)HttpStatusCode.Forbidden;
                    break;
                case ServiceResultCode.NotAuthenticated:
                    result = (int)HttpStatusCode.Unauthorized;
                    break;
            }

            return result;
        }
    }
}
