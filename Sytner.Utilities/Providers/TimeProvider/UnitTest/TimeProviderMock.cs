using System;

namespace Sytner.Utilities.Providers.TimeProvider.UnitTest
{
    /// <summary>
    /// Mock System Time Provider
    /// </summary>
    public class SystemTimeProviderMock : ITimeProvider
    {
        private DateTime _dateTime { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dateTime">The date time to use within the mock</param>
        public SystemTimeProviderMock(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public DateTime UtcNow => _dateTime.ToUniversalTime();

        public DateTime Now => _dateTime;

        public DateTime Today => _dateTime.Date;
    }
}
