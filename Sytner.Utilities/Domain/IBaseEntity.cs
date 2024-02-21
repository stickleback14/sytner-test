using System;

namespace Sytner.Utilities.Domain
{
    /// <summary>
    /// A standardised database entity
    /// </summary>
    /// <typeparam name="TId">The type used for the ID of this entity</typeparam>
    public interface IBaseEntity<TId> : IDomainEntity<TId>
    {
        /// <summary>
        /// The created date of the entity
        /// </summary>
        DateTime CreatedDate { get; set; }

        /// <summary>
        /// The modified date of the entity
        /// </summary>
        DateTime? DeletedDate { get; set; }

        /// <summary>
        /// The deleted date of the entity
        /// </summary>
        DateTime ModifiedDate { get; set; }
    }
}