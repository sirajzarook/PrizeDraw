using System;
using System.Collections.Generic;
using System.Text;

namespace PrizeDraw.Models
{
	public class Order
	{
		//For a comlecated order object
		public int SaleAmount { get; set; }
		public Order(int saleAmount) { SaleAmount = saleAmount; }
	}
}
