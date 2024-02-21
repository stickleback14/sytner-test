using System.Collections.Generic;

namespace Sytner.Utilities.ServiceResult
{
    /// <summary>
    /// A service result with content
    /// </summary>
    /// <typeparam name="T">The type of the content</typeparam>
    public class ServiceResult<T> : ServiceResult
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ServiceResult"/> class
        /// </summary>
        /// <param name="code">The result code</param>
        /// <param name="content">The result content</param>
        public ServiceResult(ServiceResultCode code, T content)
            : base(code)
        {
            Content = content;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ServiceResult"/> class
        /// </summary>
        /// <param name="code">The result code</param>
        /// <param name="errorMessage">The error message in the event of a failure</param>
        public ServiceResult(ServiceResultCode code, string errorMessage)
            : base(code, errorMessage)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ServiceResult"/> class
        /// </summary>
        /// <param name="code">The result code</param>
        /// <param name="validationErrors">The validation error messages for the supplied values</param>
        /// <param name="errorMessage">The error message in the event of a failure</param>
        public ServiceResult(ServiceResultCode code, IEnumerable<KeyValuePair<string, string>> validationErrors, string errorMessage)
            : base(code, validationErrors, errorMessage)
        {
        }

        /// <summary>
        /// Gets the content of the service result
        /// </summary>
        public T Content { get; set; }

        /// <summary>
        /// Creates a service result indicating entity was created
        /// </summary>
        /// <returns>The service result</returns>
        public static ServiceResult<T> Created(T content) => new ServiceResult<T>(ServiceResultCode.Created, content);

        /// <summary>
        /// Creates a service result indicating an instruction was accepted
        /// </summary>
        /// <returns>The service result</returns>
        public static ServiceResult<T> Accepted(T content) => new ServiceResult<T>(ServiceResultCode.Accepted, content);

        /// <summary>
        /// Creates a service result indicating success
        /// </summary>
        /// <returns>The service result</returns>
        public static ServiceResult<T> Success(T content) => new ServiceResult<T>(ServiceResultCode.Success, content);

        /// <summary>
        /// Creates a service result indicating the operation could not be completed due to a conflict
        /// </summary>
        /// <param name="errorMessage">The operation error message</param>
        /// <returns>The service result</returns>
        public static new ServiceResult<T> Conflict(string errorMessage = "") => new ServiceResult<T>(ServiceResultCode.Conflict, errorMessage);

        /// <summary>
        /// Creates a service result indicating the user is not authenticated
        /// </summary>
        /// <param name="errorMessage">The operation error message</param>
        /// <returns>The service result</returns>
        public static new ServiceResult<T> NotAuthenticated(string errorMessage = "") => new ServiceResult<T>(ServiceResultCode.NotAuthenticated, errorMessage);

        /// <summary>
        /// Creates a service result indicating supplied values are invalid
        /// </summary>
        /// <param name="errorMessage">The operation error message</param>
        /// <returns>The service result</returns>
        public static new ServiceResult<T> InvalidInput(string errorMessage = "") => new ServiceResult<T>(ServiceResultCode.InvalidInput, errorMessage);

        /// <summary>
        /// Creates a service result indicating supplied values are invalid
        /// </summary>
        /// <param name="validationErrors">The validation error messages for the supplied values</param>
        /// <returns>The service result</returns>
        public static new ServiceResult<T> InvalidInput(IEnumerable<KeyValuePair<string, string>> validationErrors) => new ServiceResult<T>(ServiceResultCode.InvalidInput, validationErrors, DefaultInvalidErrorMessage);

        /// <summary>
        /// Creates a service result indicating an entity was not found
        /// </summary>
        /// <param name="errorMessage">The operation error message</param>
        /// <returns>The service result</returns>
        public static new ServiceResult<T> NotFound(string errorMessage = "") => new ServiceResult<T>(ServiceResultCode.NotFound, errorMessage);

        /// <summary>
        /// Creates a service result indicating an internal error occurred
        /// </summary>
        /// <param name="errorMessage">The operation error message</param>
        /// <returns>The service result</returns>
        public static new ServiceResult<T> InternalError(string errorMessage = "") => new ServiceResult<T>(ServiceResultCode.InternalError, errorMessage);

        /// <summary>
        /// Creates a service result indicating an external error occurred
        /// </summary>
        /// <param name="errorMessage">The operation error message</param>
        /// <returns>The service result</returns>
        public static new ServiceResult<T> ExternalError(string errorMessage = "") => new ServiceResult<T>(ServiceResultCode.ExternalError, errorMessage);

        /// <summary>
        /// Creates a service result indicating an external error occurred and the operation should not be retried
        /// </summary>
        /// <param name="errorMessage">The operation error message</param>
        /// <returns>The service result</returns>
        public static new ServiceResult<T> ExternalErrorNoRetry(string errorMessage = "") => new ServiceResult<T>(ServiceResultCode.ExternalErrorNoRetry, errorMessage);

        /// <summary>
        /// Creates a service result indicating that the client is not authorised to perform the operation
        /// </summary>
        /// <param name="errorMessage">The operation error message</param>
        /// <returns>The service result</returns>
        public static new ServiceResult<T> Forbidden(string errorMessage = "") => new ServiceResult<T>(ServiceResultCode.Forbidden, errorMessage);

    }
}
