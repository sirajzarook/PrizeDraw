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
			SalesCampaign SalesCampaign = new SalesCampaign(SalesMock.getMockSales());
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

	}
}
