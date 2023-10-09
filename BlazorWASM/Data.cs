namespace BlazorWASM
{
	public static class Data
	{
		public static string key = "";
		public static BKK_API_manager.apiHandler apiHandler = new BKK_API_manager.apiHandler(key);
		static int getStartIndex()
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
		public static int index = getStartIndex();

		public static BKK_API_manager.Departure[] departures = apiHandler.getDeparturesWithFictive(apiHandler.stops[index], "fiktiv.json");
		public static void RefreshDepartures()
		{
			departures = apiHandler.getDeparturesWithFictive(apiHandler.stops[index], "fiktiv.json");
		}
	}
}
