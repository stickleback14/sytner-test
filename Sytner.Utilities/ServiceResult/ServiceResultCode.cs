namespace Sytner.Utilities.ServiceResult
{
    /// <summary>
    /// Service result codes appropriate to the service tier
    /// </summary>
    public enum ServiceResultCode
    {
        /// <summary>
        /// The request created an entity
        /// </summary>
        Created,

        /// <summary>
        /// An operation has started as a result of the request but is not completed
        /// </summary>
        Accepted,

        /// <summary>
        /// The operation completed successfully
        /// </summary>
        Success,

        /// <summary>
        /// The operation could not be completed due to a conflict
        /// </summary>
        Conflict,

        /// <summary>
        /// The operation failed due to invalid input data
        /// </summary>
        InvalidInput,

        /// <summary>
        /// An entity required by the operation was not found
        /// </summary>
        NotFound,

        /// <summary>
        /// An internal error occurred. The operation should not be retried.
        /// </summary>
        InternalError,

        /// <summary>
        /// An external error occurred. The operation may be retried.
        /// </summary>
        ExternalError,

        /// <summary>
        /// An external error occurred. The operation should not be retried.
        /// </summary>
        ExternalErrorNoRetry,

        /// <summary>
        /// The client does not have access rights to the content
        /// </summary>
        Forbidden,

        /// <summary>
        /// The client has not been authenticated
        /// </summary>
        NotAuthenticated
    }
}
