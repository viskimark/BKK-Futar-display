namespace BlazorUI
{
	public static class Data
	{
		static int getStartIndex()
		{
			int index;
			try
			{
				index = Array.IndexOf(BKK_API_manager.apiHandler.stopNames, "Örs vezér tere M+H (összes)");
			}
			catch
			{
				index = 0;
			}
			return index;
		}
		public static int index = getStartIndex();

		public static BKK_API_manager.Departure[] departures = BKK_API_manager.apiHandler.getDeparturesWithFictive(BKK_API_manager.apiHandler.stops[index], "fiktiv.json");
		public static void RefreshDepartures()
		{
			departures = BKK_API_manager.apiHandler.getDeparturesWithFictive(BKK_API_manager.apiHandler.stops[index], "fiktiv.json");
		}
	}
}
