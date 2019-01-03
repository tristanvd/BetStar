using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetStar.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


namespace BetStar.Controllers
{
    public class AccountController : Controller
    {
		AccountLogic AccountLogic = new AccountLogic();
		BalanceLogic BalanceLogic = new BalanceLogic();

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(LoginViewModel viewModel)
		{
			if (viewModel.EMail != null && viewModel.PassWord != null)
			{
				bool login = AccountLogic.LoginCheck(viewModel.EMail, viewModel.PassWord);
				if (login)
				{
					User user = AccountLogic.GetAccountByEMail(viewModel.EMail);
					LogUserIn(user);
					

					return RedirectToAction("Home", "Home");
				}
			}

			return View("Login", viewModel);
		}

		private void LogUserIn(User user)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim("Id", user.Id.ToString()),
				new Claim(ClaimTypes.Name, user.Name),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim("RoleId", user.RoleId.ToString()),
				new Claim("Balance", user.Balance.ToString())
			};

			var claimsIdentity = new ClaimsIdentity(claims,
				CookieAuthenticationDefaults.AuthenticationScheme);

			HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity)).Wait();
		}

		public IActionResult Cashier()
		{
			return View("Cashier");
		}

		[HttpPost]
		public IActionResult Cashier(BalanceViewModel viewModel)
		{
			if (viewModel.Deposit > 0)
			{
				BalanceLogic.Deposit(Convert.ToInt32(User.Claims.Where(claim => claim.Type == "Id").Select(claim => claim.Value).SingleOrDefault()), viewModel.Deposit);
			}
			if (viewModel.Withdrawal > 0)
			{
				BalanceLogic.Withdrawal(Convert.ToInt32(User.Claims.Where(claim => claim.Type == "Id").Select(claim => claim.Value).SingleOrDefault()), viewModel.Withdrawal);
			}
			return View("Cashier");
		}

		public IActionResult LogOut()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
			return RedirectToAction("Home", "Home");
		}

		public IActionResult MyAccount()
		{
			return View();
		}

		public IActionResult MyOpenBets()
		{
			MyBetsViewModel viewModel = new MyBetsViewModel();

			int userid = Convert.ToInt32(User.Claims.Where(claim => claim.Type == "Id").Select(claim => claim.Value).SingleOrDefault());

			viewModel.MyBets = AccountLogic.GetAllBetsByUser(userid);
			return View(viewModel);
		}

		public IActionResult MyClosedBets()
		{
			MyBetsViewModel viewModel = new MyBetsViewModel();

			int userid = Convert.ToInt32(User.Claims.Where(claim => claim.Type == "Id").Select(claim => claim.Value).SingleOrDefault());

			viewModel.MyBets = AccountLogic.GetAllBetsByUser(userid);
			return View(viewModel);
		}

		public IActionResult EditPersonalData()
		{
			string email = User.Claims.Where(claim => claim.Type == ClaimTypes.Email).Select(claim => claim.Value).SingleOrDefault();
			

			UserViewModel viewModel = new UserViewModel();
			viewModel.User = AccountLogic.GetAccountByEMail(email);

			return View(viewModel);
		}

		public PartialViewResult _FavoriteTeamsPartial()
		{
			int userid = Convert.ToInt32(User.Claims.Where(claim => claim.Type == "Id").Select(claim => claim.Value).SingleOrDefault());

			FavoriteTeamsViewModel viewModel = new FavoriteTeamsViewModel();
			viewModel.FavoriteTeams = AccountLogic.GetFavoriteTeams(userid);

			return PartialView("_FavoriteTeamsPartial", viewModel);
		}
	}
}