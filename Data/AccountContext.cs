using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
	public class AccountContext
	{
		private string ConnectionString { get; set; } = "Data Source=DESKTOP-38T55SN;Initial Catalog=TotoDB;User ID=sa;Password=784512tyghvB;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		public bool LoginCheck(string eMail, string passWord)
		{
			string query = "SELECT Email, Password FROM [User] WHERE Email=@EMail AND Password=@PassWord";
			bool logInIsValid = false;


			using (SqlConnection conn = new SqlConnection(this.ConnectionString))
			{
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{

					cmd.Parameters.Add(new SqlParameter("@EMail", eMail));
					cmd.Parameters.Add(new SqlParameter("@PassWord", passWord));
					conn.Open();

					foreach (DbDataRecord record in cmd.ExecuteReader())
					{
						logInIsValid = true;
					}


				}
			}

			return logInIsValid;
		}

		public User GetAccountByEMail(string eMail)
		{
			User user = new User();
			string query = $"SELECT Id, Name, Email, Balance, RoleId FROM [User] WHERE Email=@EMail";

			using (SqlConnection conn = new SqlConnection(this.ConnectionString))
			{
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.Add(new SqlParameter("@EMail", eMail));
					conn.Open();
					foreach (DbDataRecord record in cmd.ExecuteReader())
					{
						user = new User
						{
							Id = record.GetInt32(record.GetOrdinal("Id")),
							Name = record.GetString(record.GetOrdinal("Name")),
							Balance = record.GetDecimal(record.GetOrdinal("Balance")),
							Email = record.GetString(record.GetOrdinal("Email")),
							RoleId = record.GetInt32(record.GetOrdinal("RoleId")),
						};
					}
				}
			}

			return user;
		}

		public List<Bet> GetAllBetsByUser(int userid)
		{
			List<Bet> mybets = new List<Bet>();
			string query = "SELECT * FROM Bet WHERE UserId = " + userid + "";
			using (var conn = new SqlConnection(ConnectionString))
			{
				conn.Open();
				using (var cmd = new SqlCommand(query, conn))
				{
					using (var reader = cmd.ExecuteReader())
					{
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								Bet bet = new Bet();

								if (!DBNull.Value.Equals(reader["Result"]))
								{
									bet.Open = false;
									bet.Result = (bool)reader["Result"];
								}
								else
								{
									bet.Open = true;
								}

								

								bet.Id = (int)reader["Id"];
							
								
								bet.Amount = (decimal)reader["BetAmount"];
								bet.BettingOptions = GetBettingOptionsByBetId(bet.Id);

								mybets.Add(bet);
							}
						}
					}
				}

				return mybets;
			}
		}

		public List<BettingOption> GetBettingOptionsByBetId(int id)
		{
			List<BettingOption> bettingOptions = new List<BettingOption>();
			string query = "SELECT * FROM BetRule WHERE BetId = " + id + "";
			using (var conn = new SqlConnection(ConnectionString))
			{
				conn.Open();
				using (var cmd = new SqlCommand(query, conn))
				{
					using (var reader = cmd.ExecuteReader())
					{
						if (reader.HasRows)
						{
							while (reader.Read())
							{


								int betChoice_MatchId = (int)reader["betChoice_MatchId"];
								BettingOption bo = new BettingOption()
								{
									Id = (int)reader["Id"],
									Odd = (decimal)reader["Odd"],
									Choice = GetBetChoiceByBetChoice_MatchId(betChoice_MatchId),
									Type = GetBetTypeByBetChoice_MatchId(betChoice_MatchId)
								};
								bettingOptions.Add(bo);
							}
						}
					}
				}

				return bettingOptions;
			}
		}

		public string GetBetChoiceByBetChoice_MatchId(int id)
		{
			string query = "SELECT Choice FROM BetChoice WHERE Id = (SELECT BetChoiceId FROM BetChoice_Match WHERE Id = " + id + ")";

			SqlDataAdapter sda = new SqlDataAdapter(query, new SqlConnection(ConnectionString));

			DataTable dt = new DataTable();
			sda.Fill(dt);



			string choice = dt.Rows[0][0].ToString();



			return choice;
		}

		public string GetBetTypeByBetChoice_MatchId(int id)
		{
			string query = "SELECT Type FROM BetType WHERE Id = (SELECT BetTypeId FROM BetChoice WHERE Id = (SELECT BetChoiceId FROM BetChoice_Match WHERE Id = " + id +"))";

			SqlDataAdapter sda = new SqlDataAdapter(query, new SqlConnection(ConnectionString));

			DataTable dt = new DataTable();
			sda.Fill(dt);



			string type = dt.Rows[0][0].ToString();



			return type;
		}

		public List<Team> GetFavoriteTeams(int userid)
		{
			List<Team> teams = new List<Team>();
			string query = "SELECT Name FROM Team WHERE Id = (SELECT TeamId FROM FavoriteTeam WHERE UserId = " + userid + "";
			using (var conn = new SqlConnection(ConnectionString))
			{
				conn.Open();
				using (var cmd = new SqlCommand(query, conn))
				{
					using (var reader = cmd.ExecuteReader())
					{
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								Team team = new Team()
								{
									Name = (string)reader["Name"],
								};
								teams.Add(team);
							}
						}
					}
				}

				return teams;
			}
		}

	}
}
