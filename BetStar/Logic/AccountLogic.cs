using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Models;

namespace Logic
{
	public class AccountLogic
	{
		AccountContext AccountContext = new AccountContext();

		public bool LoginCheck(string eMail, string passWord)
		{
			return AccountContext.LoginCheck(eMail, passWord);
		}

		public User GetAccountByEMail(string eMail)
		{
			return AccountContext.GetAccountByEMail(eMail);
		}

		public List<Bet> GetAllBetsByUser(int userid)
		{
			return AccountContext.GetAllBetsByUser(userid);
		}

		public List<Team> GetFavoriteTeams(int userid)
		{
			return AccountContext.GetFavoriteTeams(userid);
		}

	}
}
