using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Logic
{
	public class BalanceLogic
	{
		BalanceContext BalanceContext = new BalanceContext();

		public void Deposit(int id, decimal deposit)
		{
			BalanceContext.Deposit(id, deposit);
		}

		public void Withdrawal(int id, decimal withdrawal)
		{
			BalanceContext.Withdrawal(id, withdrawal);
		}
	}
}
