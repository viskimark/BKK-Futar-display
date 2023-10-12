using BKK_API_manager;

namespace BlazorWASM
{
	public class Data
	{
		public apiHandler apiHandler;
		public int index;
		public Departure[] departures;
        public Data(string key, string json)
        {
			var stops = System.Text.Json.JsonSerializer.Deserialize<JsonStructures.Stop[]>(json);
			apiHandler = new apiHandler(key, stops);
			index = getStartIndex();
		}
        int getStartIndex()
		{
			int index;
			try
			{
				index = Array.IndexOf(apiHandler.stopNames, "Örs vezér tere M+H (összes)");
			}
			catch
			{
				index = 0;
			}
			return index;
		}
		public async Task RefreshDepartures()
		{
			var _departures = await apiHandler.getDeparturesWithFictive(apiHandler.stops[index], "");
			departures = _departures;
		}
	}
}
