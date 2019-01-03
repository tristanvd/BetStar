using System;
using System.Collections.Generic;
using System.Text; 

namespace Models
{
	public class BetSlip
	{
		public List<BettingOption> BettingOptions { get; set; } = new List<BettingOption>();
		public decimal Amount { get; set; }

		public void AddBet(BettingOption bo)
		{
			BettingOptions.Add(bo);
		}
	}
}
