using System;
using Sytner.Utilities.Providers.TimeProvider.UnitTest;

namespace Sytner.Utilities.Providers.TimeProvider
{
    /// <summary>
    /// Time provider interface. 
    /// This is useful for Unit Testing, see the <see cref="SystemTimeProviderMock"/> 
    /// </summary>
    public interface ITimeProvider
    {
        /// <summary>
        /// The UTC time now
        /// </summary>
        DateTime UtcNow { get; }

        /// <summary>
        /// The local time now
        /// </summary>
        DateTime Now { get; }

        /// <summary>
        /// The local date
        /// </summary>
        DateTime Today { get; }
    }
}
