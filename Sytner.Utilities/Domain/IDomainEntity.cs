namespace Sytner.Utilities.Domain
{
    /// <summary>
    /// Domain Entity
    /// </summary>
    public interface IDomainEntity
    {

    }

    /// <summary>
    /// Domain Entity
    /// </summary>
    /// <typeparam name="TId">The type used for the ID of this entity</typeparam>
    public interface IDomainEntity<out TId> : IDomainEntity
    {
        /// <summary>
        /// The ID of the entity
        /// </summary>
        TId Id { get; }
    }
}
