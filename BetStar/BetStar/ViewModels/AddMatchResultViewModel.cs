using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetStar.ViewModels
{
	public class AddMatchResultViewModel
	{
		public Match Match { get; set; } = new Match();
		public string Result { get; set; }
		public int HomeTeamCorners { get; set; }
		public int AwayTeamCorners { get; set; }
		public int HomeTeamYellowCards { get; set; }
		public int AwayTeamYellowCards { get; set; }
		public int HomeTeamRedCards { get; set; }
		public int AwayTeamRedCards { get; set; }
		public bool Available { get; set; } = false;

	}
}
