using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetStar.ViewModels;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BetStar.Controllers
{
    public class AdminController : Controller
    {
		MatchLogic MatchLogic = new MatchLogic();

        public IActionResult AddMatch()
        {
			Match match = new Match();
			match.BettingOptions = MatchLogic.GetAllBettingOptions();

			MatchViewModel viewModel = new MatchViewModel(match);
			return View(viewModel);
        }

		[HttpPost]
		public IActionResult AddMatch(MatchViewModel viewModel, List<BettingOption> bo)
		{
			viewModel.Match.BettingOptions = bo;
			MatchLogic.AddMatch(viewModel.Match);
			
			return RedirectToAction("AddMatch", "Admin");
		}

		public IActionResult AddMatchResult()
		{
			AddMatchResultViewModel viewModel = new AddMatchResultViewModel();

			viewModel.Match = MatchLogic.GetOpenMatch();

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult AddMatchResultPost(AddMatchResultViewModel viewModel)
		{
			int id = viewModel.Match.Id;
			string result = viewModel.Result;
			int homeTeamCorners = viewModel.HomeTeamCorners;
			int awayTeamCorners = viewModel.AwayTeamCorners;
			int homeTeamYellowCards = viewModel.HomeTeamYellowCards;
			int awayTeamYellowCards = viewModel.AwayTeamYellowCards;
			int homeTeamRedCards = viewModel.HomeTeamRedCards;
			int awayTeamRedCards = viewModel.AwayTeamRedCards;
			bool available = viewModel.Available;

			MatchLogic.AddMatchResult(id, result, homeTeamCorners, awayTeamCorners, homeTeamYellowCards, awayTeamYellowCards, homeTeamRedCards, awayTeamRedCards, available);
			return RedirectToAction("AddMatchResult");
		}

		public IActionResult AddBetType()
		{
			AddBetTypeViewModel viewModel = new AddBetTypeViewModel();
			viewModel.BetTypeIds = MatchLogic.GetAllBetTypeIds();

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult AddBetType(AddBetTypeViewModel viewModel)
		{
			MatchLogic.AddBetType(viewModel.BetType);
			return RedirectToAction("Home", "Home");
		}

    }
}