namespace GoogleMapsAPI.NET.API.Common.Components
{
    /// <summary>
    /// Time component
    /// </summary>
    public class Time
    {

        #region Properties

        /// <summary>
        /// Time in 12h format
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Time zone location
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Time in UNIX format in seconds
        /// </summary>
        public long Value { get; set; }

        #endregion

    }
}
