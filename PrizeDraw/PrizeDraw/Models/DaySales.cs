using System;
using System.Collections.Generic;
using System.Text;

namespace PrizeDraw.Models
{
	public class DaySales
	{
		//public int Day { get; set; }
		public List<int> Orders { get; set; }

		public DaySales()
		{
			Orders = new List<int>();
		}

		public DaySales(List<int> orders)
		{
			//Day = day;
			//Orders = orders;
			Orders = orders;
		}

	}
}
