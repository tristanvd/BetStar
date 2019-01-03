using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class Bet
	{
		public int Id { get; set; }
		public decimal Amount { get; set; }
		public bool Open { get; set; }
		public List<BettingOption> BettingOptions { get; set; } = new List<BettingOption>();
		public bool Result { get; set; }
	}
}
