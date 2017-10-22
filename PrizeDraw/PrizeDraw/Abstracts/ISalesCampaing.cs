using PrizeDraw.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrizeDraw.Abstracts
{
    public interface ISalesCampaign
    {
		List<int> OrdersToDraw { get; set; }
		void RemoveCurrentHighAndLow();
		void DailyDraw();
		int GetTotalPrizeMoney();
    }
}
