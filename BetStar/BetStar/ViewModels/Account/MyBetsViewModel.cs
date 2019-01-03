using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetStar.ViewModels.Account
{
	public class MyBetsViewModel
	{
		public List<Bet> MyBets { get; set; } = new List<Bet>();
	}
}
