using System;
using System.Collections.Generic;
using Models;

namespace Models
{
	public class Match
	{
		public int Id { get; set; }
		public DateTime DateTime { get; set; }
		public string HomeTeam { get; set; }
		public string AwayTeam { get; set; }
		public bool Available { get; set; }
		public List<BettingOption> BettingOptions { get; set; }

		public string Result { get; set; }
		public int HomeTeamCorners { get; set; }
		public int AwayTeamCorners { get; set; }
		public int HomeTeamYellowCards { get; set; }
		public int AwayTeamYellowCards { get; set; }
		public int HomeTeamRedCards { get; set; }
		public int AwayTeamRedCards { get; set; }
	}
}
