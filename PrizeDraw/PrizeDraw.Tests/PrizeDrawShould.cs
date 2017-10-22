using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrizeDraw.Abstracts;
using PrizeDraw.Mock;
using PrizeDraw.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace PrizeDraw.Tests
{
    [TestClass]
    public class PrizeDrawShould
    {
		[TestMethod]
		public void ReturnTheTotalPrizeMoneyOfACampaing()
		{
			ISalesCampaign SalesCampaign = new SalesCampaign(SalesMock.getMockSales());
			int TMP = SalesCampaign.GetTotalPrizeMoney();
			Debug.Print(TMP.ToString());
			Assert.AreEqual(19, TMP);

		}

		[TestMethod]
		public void ReturnTrueForValidCampaignLength()
		{
			int campaignLen = 4000;
			Assert.IsTrue(SalesCampaign.CampaignLengthCheck(campaignLen));

		}

		[TestMethod]
		public void ReturnTrueForInvalidCampaignLength()
		{
			int campaignLen = 60000;
			Assert.IsFalse(SalesCampaign.CampaignLengthCheck(campaignLen));

		}

		[TestMethod]
		public void ReturnListOfDaySalesWhenProvidedAvalidInputFile()
		{
			List<DaySales> DaySalesList = SalesCampaign.PrepareInputFile(@"C:\t.txt");
			Assert.AreEqual(typeof(List<DaySales>), DaySalesList.GetType());
			Assert.IsTrue(DaySalesList != null);

		}

		[TestMethod]
		[ExpectedException(typeof(System.IO.FileNotFoundException), "File not found.")]
		public void ReturnListOfDaySalesWhenProvidedAnInvalidInputFilePath()
		{
			List<DaySales> DaySalesList = SalesCampaign.PrepareInputFile(@"C:\fileErrorPath.txt");
			Assert.AreEqual(typeof(List<DaySales>), DaySalesList.GetType());
			Assert.IsTrue(DaySalesList != null);

		}

		[TestMethod]
		[ExpectedException(typeof(System.FormatException), "Curropt file.")]
		public void ReturnListOfDaySalesWhenProvidedAnInvalidInputFile()
		{
			List<DaySales> DaySalesList = SalesCampaign.PrepareInputFile(@"C:\t1.txt");
			Assert.AreEqual(typeof(List<DaySales>), DaySalesList.GetType());
			Assert.IsTrue(DaySalesList != null);

		}

	}
}
