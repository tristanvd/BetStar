using BetStar.ViewModels.Account;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetStar.ViewModels
{
	public class MatchViewModel
	{
		public List<Match> AllMatches { get; set; }
		public Match Match { get; set; } = new Match();
		public BetSlip BetSlip { get; set; } = new BetSlip();
		public string SearchWord { get; set; }
		public string idstring { get; set; }

		public MatchViewModel(Match match)
		{
			Match = match;
		}

		public MatchViewModel() { }
	}
}
