using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetStar.ViewModels.Account
{
	public class BalanceViewModel
	{
		public decimal Deposit { get; set; } = 0;
		public decimal Withdrawal { get; set; } = 0;

		public decimal Balance { get; set; }
	}
}
