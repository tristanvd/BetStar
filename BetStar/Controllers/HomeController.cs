using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BetStar.ViewModels;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Models;

namespace BetStar.Controllers
{
	
	public class HomeController : Controller
	{
		AccountLogic AccountLogic = new AccountLogic();
		MatchLogic MatchLogic = new MatchLogic();

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Home()
		{
			MatchViewModel viewModel = new MatchViewModel();
			viewModel.AllMatches = MatchLogic.GetAllMatches();


			return View(viewModel);
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		//public IActionResult Error()
		//{
		//	return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		//}

		
	}


}
