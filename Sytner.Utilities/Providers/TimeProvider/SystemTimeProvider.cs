using System;
using System.Diagnostics.CodeAnalysis;

namespace Sytner.Utilities.Providers.TimeProvider
{
    /// <summary>
    /// Provides times directly from System.DateTime
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SystemTimeProvider : ITimeProvider
    {
        public DateTime Today => DateTime.Today;
        public DateTime Now => DateTime.Now;
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
