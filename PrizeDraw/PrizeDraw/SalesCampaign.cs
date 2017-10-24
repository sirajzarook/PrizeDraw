using PrizeDraw.Abstracts;
using PrizeDraw.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PrizeDraw
{
	public class SalesCampaign : ISalesCampaign 
	{
		private static readonly int MaxCampaignLength = 5000;
		private static readonly int MaxSlaesAmount = 1000000;
		public List<int> OrdersToDraw { get; set; }
		private int TotalMoneyPrize { get; set; }

		public SalesCampaign(IList<DaySales> daySalesList)
		{
			OrdersToDraw = new List<int>();
			foreach (var daySales in daySalesList)
			{
				OrdersToDraw.AddRange(daySales.Orders);
				//OrdersToDraw.Sort();
				DailyDraw();
			}
		}
		public void DailyDraw()
		{
			TotalMoneyPrize += OrdersToDraw.Max() - OrdersToDraw.Min();
			RemoveCurrentHighAndLow();
		}

		public static bool CampaignLengthCheck(int length)
		{
			return MaxCampaignLength > length;
		}
		public int GetTotalPrizeMoney()
		{
			return TotalMoneyPrize;
		}

		public void RemoveCurrentHighAndLow()
		{
			if (OrdersToDraw.Count() > 0)
				OrdersToDraw.Remove(OrdersToDraw.Max());
			if (OrdersToDraw.Count() > 0)
				OrdersToDraw.Remove(OrdersToDraw.Min());
		}

		public static List<DaySales> PrepareSalesData(string[] lines)
		{
			List<DaySales> DaySalesList = new List<DaySales>();
			//string[] lines = { "" };
			int lineNum = 1;
			foreach (string line in lines)
			{
				line.Trim();
				if (lineNum == 1)
				{
					int camLength = Convert.ToInt32(line.Trim());
					if (!SalesCampaign.CampaignLengthCheck(camLength))
					{
						Console.WriteLine("Campaign lenght not valid");
						//throw new System.FormatException();
					};

					if (Convert.ToInt32(line.Trim()) != lines.Length - 1)

					{
						Console.WriteLine("Corrupt input in sales data : {0}", lines);
						//throw new System.FormatException();
						//return null;

					}
					++lineNum;
					continue;

				}
				var SalesSplit = line.Trim().Split(new char[0]);

				SalesSplit = SalesSplit.Skip(1).ToArray();
				var daySale = new DaySales();
				foreach (var sale in SalesSplit)
				{

					daySale.Orders.AddRange(sale.Split(',').Select(Int32.Parse).ToList());
					if (daySale.Orders.Where(t => t <= MaxSlaesAmount).Count() == 0)
						Console.WriteLine("Corrupt input in sales data as each sale should be below 1000000");
					//throw new System.FormatException();//TODO check if the sales are below 1000000
				}
				DaySalesList.Add(daySale);
				

			}
			return DaySalesList;
		}

	}
}
