using PrizeDraw.Abstracts;
using PrizeDraw.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrizeDraw
{
    public class Program
    {
        static void Main(string[] args)
        {
			List<DaySales> DaySalesList = SalesCampaign.PrepareInputFile(@"C:\t.txt");


			ISalesCampaign salesCampaing = new SalesCampaign(DaySalesList);

			Console.WriteLine("{0}", salesCampaing.GetTotalPrizeMoney());
			Console.ReadKey();
        }

	

    }
}
