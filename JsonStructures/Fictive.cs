using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonStructures
{
	public class FictiveRoute
	{
        public string routeId { get; set; }
        public string routeName { get; set; }
        public string routeType { get; set; }
        public string color { get; set; }
        public string textColor { get; set; }
        public Destination[] destinations { get; set; }

		public class Destination
		{
			public Headsign[] headsigns { get; set; }
			public DepartureTimes departureTimes { get; set; }
		}
		public class Headsign
		{
			public string name { get; set; }
			public Stop[] stops { get; set; }
		}
		public class Stop
		{
			public string stopId { get; set; }
			public int time { get; set; }
		}
		public class DepartureTimes
		{
			public string[] weekdayTimes { get; set; }
			public string[] weekendTimes { get; set; }
		}
	}
}
