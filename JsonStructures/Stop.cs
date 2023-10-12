using System.Text.Json.Serialization;

namespace JsonStructures
{
	[JsonSerializable(typeof(Stop))]
	internal partial class MyJsonContext : JsonSerializerContext { }

	public class Stop
	{
		public string longName { get; set; }
		public string shortName { get; set; }
		public string[] ids { get; set; }
		public string[] exits { get; set; }
	}
}