using System.Runtime.Serialization;

namespace GoogleMapsAPI.NET.API.Directions.Components
{
	/// <summary>
	/// Transit line component
	/// </summary>
	[DataContract]
	public class TransitLine
	{

		#region Properties

		/// <summary>
		/// Transit line name
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Transit line short name
		/// </summary>
		[DataMember(Name = "short_name")]
		public string ShortName { get; set; }

		#endregion

	}
}
