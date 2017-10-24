using PrizeDraw.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrizeDraw.Mock
{
	public class SalesMock
	{
		public static List<DaySales> getMockSales()

		{
			List<DaySales> DaySales = new List<DaySales>()
			{
				new DaySales() {
					Orders = new List<int> {1,2,3}
					},
				new DaySales() {
					Orders = new List<int>  {1,1}
					},
				new DaySales() {
					Orders = new List<int>  {10,5,5,1}
					},
				new DaySales() {
					Orders = new List<int>  { }
					},
				new DaySales() {
					Orders = new List<int>  {2}
					},

			};
			return DaySales;

		}
	}
}
