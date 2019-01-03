using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class BettingOption
	{
		public int Id { get; set; }
		public int BetId { get; set; }
		public int MatchId { get; set; }
		public string Type { get; set; }
		public string Choice { get; set; }
		public decimal Odd { get; set; }

		public BettingOption()
		{

		}

		public BettingOption(decimal odd)
		{
			Odd = odd;
		}
	}
}
