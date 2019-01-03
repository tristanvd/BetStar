using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using BetStar.ViewModels;
using Models;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace BetStar.Controllers
{
    public class MatchController : Controller
    {
		MatchLogic MatchLogic = new MatchLogic();

		public IActionResult MatchDetails(int id)
        {
			
			MatchViewModel viewModel = new MatchViewModel();
			viewModel.Match = MatchLogic.GetMatchDetails(id);

			return View(viewModel);
        }

		public IActionResult Stats(int id)
		{

			//MatchStatsViewModel viewModel = new MatchStatsViewModel();
			//viewModel.HomeTeamWins = MatchLogic.GetHomeTeamWins(id);
			//viewModel.Draws = MatchLogic.GetDraws(id);
			//viewModel.AwayTeamWins = MatchLogic.GetAwayTeamWins(id);

			return View();
		}

		public IActionResult ChangeBetslip(int id, BetSlipViewModel bsvm)
		{
			bsvm.idstring = bsvm.idstring + id;

			string[] idlijst = bsvm.idstring.Split(',');

			
			

			foreach (var item in idlijst)
			{
				BettingOption bo = MatchLogic.AddBetSlipOption(Convert.ToInt32(item));
				bsvm.BettingOptions.Add(bo);
			}

			//HttpContext.Session.SetString("test", "testj");

			

			return PartialView("_BetslipPartial", bsvm);
		}

		public IActionResult SearchResults(MatchViewModel viewModel)
		{
			viewModel.AllMatches = MatchLogic.SearchMatches(viewModel.SearchWord);

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult PlaceBet(BetSlipViewModel viewModel)
		{
			var userid = Convert.ToInt32(User.Claims.Where(claim => claim.Type == "Id").Select(claim => claim.Value).SingleOrDefault());



			MatchLogic.AddBet(viewModel.idstring, viewModel.Amount, userid);

			viewModel = new BetSlipViewModel();
			return PartialView("_BetslipPartial", viewModel);
		}
    }
}