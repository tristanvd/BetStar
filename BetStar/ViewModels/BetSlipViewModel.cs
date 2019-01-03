using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetStar.ViewModels
{
	public class BetSlipViewModel
	{
		public List<int> ids { get; set; } = new List<int>();

		public string idstring { get; set; }

		public List<BettingOption> BettingOptions { get; set; } = new List<BettingOption>();

		public decimal Amount { get; set; }
	}
}
