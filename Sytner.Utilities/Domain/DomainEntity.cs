namespace Sytner.Utilities.Domain
{
    /// <summary>
    /// Domain Entity
    /// </summary>
    public abstract class DomainEntity<TId> : IDomainEntity<TId>
    {
        /// <inheritdoc />
        public TId Id { get; set; }
    }
}
