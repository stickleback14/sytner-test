namespace Sytner.Utilities.ServiceResult
{
    /// <summary>
    /// A validation error
    /// </summary>
    public sealed class ValidationError
    {
        /// <summary>
        /// Creates a new <see cref="ValidationError"/> object
        /// </summary>
        /// <param name="identifier">The name of the value that failed validation</param>
        /// <param name="message">The reason why it failed validation</param>
        public ValidationError(string identifier, string message)
        {
            Identifier = identifier;
            Message = message;
        }

        /// <summary>
        /// The name of the field that failed validation
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// The reason for validation failure
        /// </summary>
        public string Message { get; }
    }
}
