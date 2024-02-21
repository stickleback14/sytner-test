using System;

namespace Sytner.Utilities.Domain
{
    /// <summary>
    /// A standardised database entity
    /// </summary>
    /// <typeparam name="TId">The type used for the ID of this entity</typeparam>
    public abstract class BaseEntity<TId> : DomainEntity<TId>, IBaseEntity<TId>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseEntity()
        {
            this.CreatedDate = DateTime.UtcNow;
            this.ModifiedDate = DateTime.UtcNow;
        }

        /// <inheritdoc />
        public DateTime CreatedDate { get; set; }

        /// <inheritdoc />
        public DateTime ModifiedDate { get; set; }

        /// <inheritdoc />
        public DateTime? DeletedDate { get; set; }
    }
}
