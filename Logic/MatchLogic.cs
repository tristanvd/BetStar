using Data;
using Models;
using System;
using System.Collections.Generic;

namespace Logic
{
	public class MatchLogic
	{
		MatchContext MatchContext = new MatchContext();

		public List<Match> GetAllMatches()
		{
			return MatchContext.GetAllMatches();
		}

		public Match GetMatchDetails(int id)
		{
			return MatchContext.GetMatchDetails(id);
		}

		public void AddMatch(Match match)
		{
			MatchContext.AddMatch(match);
		}

		public List<BettingOption> GetAllBettingOptions()
		{
			return MatchContext.GetAllBettingOptions();
		}

		public BettingOption AddBetSlipOption(int id)
		{
			return MatchContext.AddBetSlipOption(id);
		}

		public List<Match> SearchMatches(string searchword)
		{
			return MatchContext.SearchMatches(searchword);
		}

		public void AddBet(string idstring, decimal amount, int userid)
		{
			idstring = idstring.Remove(idstring.Length - 1, 1);
			string[] ids = idstring.Split(",");

			List<BettingOption> betlist = new List<BettingOption>();
			foreach (var item in ids)
			{
				betlist.Add(MatchContext.AddBetSlipOption(Convert.ToInt32(item)));
			}

			MatchContext.AddBet(betlist, amount, userid);
		}

		public void AddMatchResult(int id, string result, int homeTeamCorners, int awayTeamCorners, int homeTeamYellowCards, int awayTeamYellowCards, int homeTeamRedCards, int awayTeamRedCards, bool available)
		{
			MatchContext.AddMatchResult(id, result, homeTeamCorners, awayTeamCorners, homeTeamYellowCards, awayTeamYellowCards, homeTeamRedCards, awayTeamRedCards, available);

			//CalculateResults(id);
		}

		public Match GetOpenMatch()
		{
			return MatchContext.GetOpenMatch();
		}

		public void CalculateResults(int matchid)
		{
			List<BettingOption> allBetRules = MatchContext.GetBetRulesByMatchId(matchid);
			Match match = MatchContext.GetMatchStats(matchid);

			foreach (var item in allBetRules)
			{

			}

			//string matchresult;
			//int goalsteam1 = split = 2
			//int goalsteam2 = split = 1

			//if (goalsteam1 > goalsteam2){ matchresult = 1 }
			//if (goalsteam1 == goalsteam2){ matchresult = X }
			//if (goalsteam1 < goalsteam2){ matchresult = 2 }


			//foreach(var item in allBetRules)
			//{
			//	if(item.choice == matchresult){ item.Result = true }
			//  else { item.Result = false }
			//}


			//lijst ophalen met betrules met bepaalde matchid

			//stats ophalen van die matchid

			//if (keuze == uitslag){ result = true }else{ result = false }
			//checken of er nog betrules in die bet open staan, zoja: niks doen. zonee: kijken of alles goed of fout is en bet result aanpassen + balance bijwerken

		}
		
		public void AddBetType(string betType)
		{
			MatchContext.AddBetType(betType);
		}

		public List<int> GetAllBetTypeIds()
		{
			return MatchContext.GetAllBetTypeIds();
		}

	}
}
