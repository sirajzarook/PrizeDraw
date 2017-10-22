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
		private static readonly int campaignLength = 5000;
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
			return campaignLength > length;
		}
		public int GetTotalPrizeMoney()
		{
			return TotalMoneyPrize;
		}

		public void RemoveCurrentHighAndLow()
		{
			OrdersToDraw.Remove(OrdersToDraw.Max());
			OrdersToDraw.Remove(OrdersToDraw.Min());
		}

		public static List<DaySales> PrepareInputFile(string fileName)
		{
			List<DaySales> DaySalesList = new List<DaySales>();
			string[] lines = { "" };
			try
			{
				lines = System.IO.File.ReadAllLines(fileName);
			}
			catch (System.IO.FileNotFoundException)
			{
				Console.WriteLine("Fle not found {0}", fileName);
				throw new System.IO.FileNotFoundException();
			}
			catch (Exception)
			{
				Console.WriteLine("Unexpected error {0}", fileName);
				throw new Exception();
			}
			int lineNum = 1;
			foreach (string line in lines)
			{
				try
				{
					line.Trim();
					if (lineNum == 1)
					{
						int camLength = Convert.ToInt32(line.Trim());
						if (!SalesCampaign.CampaignLengthCheck(camLength))
						{
								Console.WriteLine("Campaign lenght not valid {0}", fileName);
								throw new System.FormatException();
						};
						if (Convert.ToInt32(line.Trim()) != lines.Length - 1)
						{
							Console.WriteLine("Corrupt Input File {0}", fileName);
							throw new System.FormatException();
							//return null;
						}
						++lineNum;
						continue;
					}
					var SalesSplit = line.Trim().Split(" ");

					if (Convert.ToInt32(SalesSplit[0]) != SalesSplit.Length - 1)
					{
						Console.WriteLine("Corrupt Input File {0}", fileName);
						throw new System.FormatException();

						//return null;
					}

					SalesSplit = SalesSplit.Skip(1).ToArray();
					var daySale = new DaySales();
					foreach (var sale in SalesSplit)
					{
						
						daySale.Orders.AddRange(sale.Split(',').Select(Int32.Parse).ToList());
						if(daySale.Orders.Where(t => t <= 1000000).Count() == 0)
							throw new System.FormatException();//TODO check if the sales are below 1000000
					}
					DaySalesList.Add(daySale);
				}
				catch (System.FormatException)
				{
					Console.WriteLine("Fle not found {0}", fileName);
					throw new System.FormatException(); //TODO Error logging handling
				}
				catch (Exception)
				{
					Console.WriteLine("Corrupt Input File {0}", fileName);
					throw new System.FormatException(); ////TODO Error logging handling
				}

			}

			return DaySalesList;
		}
	}
}
