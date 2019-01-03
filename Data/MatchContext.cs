using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace Data
{
	public class MatchContext
	{
		private string ConnectionString { get; set; } = "Data Source=DESKTOP-38T55SN;Initial Catalog=TotoDB;User ID=sa;Password=784512tyghvB;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		public List<Match> GetAllMatches()
		{
			List<Match> matches = new List<Match>();
			string query = "SELECT * FROM Match";
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
								int homeid = (int)reader["HomeTeamId"];
								int awayid = (int)reader["AwayTeamId"];
								int id = (int)reader["Id"];
								Match match = new Match()
								{
									Id = id,
									HomeTeam = GetTeamName(homeid),
									AwayTeam = GetTeamName(awayid),
									DateTime = (DateTime)reader["DateTime"],
									Available = (bool)reader["Available"],
									BettingOptions = GetBettingOptions(id)
								};
								matches.Add(match);
							}
						}
					}
				}

				return matches;
			}
		}

		public string GetTeamName(int id)
		{
			string query = "SELECT Name FROM Team where Id = " + id + "";

			SqlDataAdapter sda = new SqlDataAdapter(query, new SqlConnection(ConnectionString));

			DataTable dt = new DataTable();
			sda.Fill(dt);
			string team = dt.Rows[0][0].ToString();
			return team;
		}

		public int GetTeamId(string name)
		{
			string query = "SELECT Id FROM Team where Name = '" + name + "'";

			SqlDataAdapter sda = new SqlDataAdapter(query, new SqlConnection(ConnectionString));

			DataTable dt = new DataTable();
			sda.Fill(dt);
			int id = Convert.ToInt32(dt.Rows[0][0].ToString());
			return id;
		}

		public Match GetMatchDetails(int id)
		{
			Match match = new Match();
			string query = "SELECT * FROM Match where Id = " + id + "";
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
								int homeid = (int)reader["HomeTeamId"];
								int awayid = (int)reader["AwayTeamId"];
								match = new Match()
								{
									Id = (int)reader["Id"],
									HomeTeam = GetTeamName(homeid),
									AwayTeam = GetTeamName(awayid),
									DateTime = (DateTime)reader["DateTime"],
									Available = (bool)reader["Available"],
									BettingOptions = GetBettingOptions(id),
									
								};



							}
						}
					}
				}

				return match;
			}
		}

	

		public List<BettingOption> GetBettingOptions(int id)
		{
			List<BettingOption> bettingOptions = new List<BettingOption>();
			string query = "SELECT Id, (Select Choice from BetChoice where Id = BetChoiceId) AS BetChoice, (Select Type from BetType where Id = (Select BetTypeId from BetChoice where Id = BetChoiceId)) AS BetType, Odd, MatchId from BetChoice_Match where MatchId = " + id + "";
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
								BettingOption bettingOption = new BettingOption
								{
									MatchId = (int)reader["MatchId"],
									Id = (int)reader["Id"],
									Type = (string)reader["BetType"],
									Choice = (string)reader["BetChoice"],
									Odd = (decimal)reader["Odd"]
								};
								bettingOptions.Add(bettingOption);
							}
						}
					}
				}

				return bettingOptions;
			}
		}


		public string GetBettingChoice(int id)
		{
			string query = "SELECT Choice FROM BetChoice where Id = " + id + "";

			SqlDataAdapter sda = new SqlDataAdapter(query, new SqlConnection(ConnectionString));

			DataTable dt = new DataTable();
			sda.Fill(dt);
			string choice = dt.Rows[0][0].ToString();
			return choice;
		}

		public void AddMatch(Match match)
		{
			int homeid = GetTeamId(match.HomeTeam);
			int awayid = GetTeamId(match.AwayTeam);

			SqlConnection con = new SqlConnection(ConnectionString);
			SqlCommand cmd = new SqlCommand("AddMatch", con)
			{
				CommandType = CommandType.StoredProcedure
			};
			cmd.Parameters.Add(new SqlParameter("@HomeTeamId", homeid));
			cmd.Parameters.Add(new SqlParameter("@AwayTeamId", awayid));
			cmd.Parameters.Add(new SqlParameter("@DateTime", match.DateTime));
			cmd.Parameters.Add(new SqlParameter("@Available", match.Available));
			cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

			con.Open();
			cmd.ExecuteNonQuery();
			int matchid = Convert.ToInt32(cmd.Parameters["@Id"].Value);
			con.Close();
			

			foreach (var item in match.BettingOptions)
			{
				string query2 = "INSERT INTO [BetChoice_Match](BetChoiceId, MatchId, Odd) VALUES(@BetChoiceId, @MatchId, @Odd)";

				SqlCommand cmd2 = new SqlCommand(query2, con);
				cmd2.Parameters.Add(new SqlParameter("@BetChoiceId", item.Id));
				cmd2.Parameters.Add(new SqlParameter("@MatchId", matchid));
				cmd2.Parameters.Add(new SqlParameter("@Odd", item.Odd));

				con.Open();
				cmd2.ExecuteNonQuery();
				con.Close();
			}

		
		}

		public void AddBetType(string betType)
		{
			string query = "INSERT INTO BetType(Type) VALUES('" + betType + "')";

			SqlConnection conn = new SqlConnection(ConnectionString);
			SqlCommand cmd = new SqlCommand(query, conn);

			conn.Open();
			cmd.ExecuteNonQuery();
			conn.Close();

		}

		public List<int> GetAllBetTypeIds()
		{
			List<int> ids = new List<int>();
			string query = "SELECT * FROM BetType";
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
								int id = (int)reader["Id"];

								ids.Add(id);

							}
						}
					}
				}

				return ids;
			}
		}

		public List<BettingOption> GetAllBettingOptions()
		{
			List<BettingOption> bettingOptions = new List<BettingOption>();
			string query = "SELECT Id, Choice, (Select Type from BetType where Id = BetTypeId) AS BetType from BetChoice";
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
								BettingOption bettingOption = new BettingOption
								{
									Choice = (string)reader["Choice"],
									Id = (int)reader["Id"],
									Type = (string)reader["BetType"]
								};
								bettingOptions.Add(bettingOption);
							}
						}
					}
				}

				return bettingOptions;
			}
		}

		public BettingOption AddBetSlipOption(int id)
		{
			string query = "SELECT Id, MatchId, Odd, (SELECT Choice FROM BetChoice where Id = BetChoiceId) AS Choice, (SELECT Type FROM BetType where Id = (SELECT BetTypeId FROM BetChoice WHERE Id = BetChoiceId)) AS Type FROM BetChoice_Match WHERE Id = " + id + "";

			SqlDataAdapter sda = new SqlDataAdapter(query, new SqlConnection(ConnectionString));

			DataTable dt = new DataTable();
			sda.Fill(dt);

			BettingOption bo = new BettingOption();

			bo.MatchId = Convert.ToInt32(dt.Rows[0][1]);
			bo.Id = Convert.ToInt32(dt.Rows[0][0]);
			bo.Choice = dt.Rows[0][3].ToString();
			bo.Type = dt.Rows[0][4].ToString();
			bo.Odd = Convert.ToDecimal(dt.Rows[0][2]);


			return bo;
		}


		public List<Match> SearchMatches(string searchword)
		{
			List<Match> matches = new List<Match>();
			string query = "SELECT * FROM Match WHERE HomeTeamId = (Select Id from Team where Name LIKE '%" + searchword + "%') OR AwayTeamId = (Select Id from Team where Name LIKE '%" + searchword + "%')";
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
								int homeid = (int)reader["HomeTeamId"];
								int awayid = (int)reader["AwayTeamId"];
								int id = (int)reader["Id"];
								Match match = new Match()
								{
									Id = id,
									HomeTeam = GetTeamName(homeid),
									AwayTeam = GetTeamName(awayid),
									DateTime = (DateTime)reader["DateTime"],
									Available = (bool)reader["Available"],
									BettingOptions = GetBettingOptions(id)
								};
								matches.Add(match);
							}
						}
					}
				}

				return matches;
			}
		}


		public void AddBet(List<BettingOption> bets, decimal amount, int userid)
		{
			string query = "INSERT INTO Bet(UserId, DateTime, BetAmount) VALUES(@UserId, @DateTime, @BetAmount)";
			
			SqlConnection conn = new SqlConnection(ConnectionString);

			SqlCommand cmd = new SqlCommand(query, conn);
			

			DateTime dt = DateTime.Now;
			
			cmd.Parameters.Add(new SqlParameter("UserId", userid));
			cmd.Parameters.Add(new SqlParameter("DateTime" , dt));
			cmd.Parameters.Add(new SqlParameter("BetAmount", amount));

			conn.Open();
			cmd.ExecuteNonQuery();
			conn.Close();

			foreach (var item in bets)
			{
				string query2 = "INSERT INTO BetRule(BetId, BetChoice_MatchId, Odd) VALUES((SELECT MAX(Id) FROM BET), @BetChoice_MatchId, @Odd)";
				SqlCommand cmd2 = new SqlCommand(query2, conn);

				cmd2.Parameters.Add(new SqlParameter("@BetChoice_MatchId", GetBetChoice_MatchId(item)));
				cmd2.Parameters.Add(new SqlParameter("@Odd", item.Odd));
				conn.Open();
				cmd2.ExecuteNonQuery();
				conn.Close();
			}
		}

		public int GetBetChoice_MatchId(BettingOption bo)
		{
			string query = "SELECT Id FROM BetChoice_Match WHERE BetChoiceId = " + GetBettingChoiceId(bo) + " AND MatchId = " + bo.MatchId + "";

			SqlDataAdapter sda = new SqlDataAdapter(query, new SqlConnection(ConnectionString));

			DataTable dt = new DataTable();
			sda.Fill(dt);

			

			int id = Convert.ToInt32(dt.Rows[0][0]);



			return id;
		}

		public int GetBettingChoiceId(BettingOption bo)
		{
			string query = "SELECT Id FROM BetChoice WHERE Choice = '" + bo.Choice + "' AND BetTypeId = " + GetBetTypeId(bo) + "";

			SqlDataAdapter sda = new SqlDataAdapter(query, new SqlConnection(ConnectionString));

			DataTable dt = new DataTable();
			sda.Fill(dt);



			int id = Convert.ToInt32(dt.Rows[0][0]);



			return id;
		}

		public int GetBetTypeId(BettingOption bo)
		{
			string query = "SELECT Id FROM BetType WHERE Type = '" + bo.Type + "'";

			SqlDataAdapter sda = new SqlDataAdapter(query, new SqlConnection(ConnectionString));

			DataTable dt = new DataTable();
			sda.Fill(dt);



			int id = Convert.ToInt32(dt.Rows[0][0]);



			return id;
		}


		public void AddMatchResult(int id, string result, int homeTeamCorners, int awayTeamCorners, int homeTeamYellowCards, int awayTeamYellowCards, int homeTeamRedCards, int awayTeamRedCards, bool available)
		{
			string query = "UPDATE Match SET Result = @Result, HomeTeamCorners = @HomeTeamCorners, AwayTeamCorners = @AwayTeamCorners, HomeTeamYellowCards = @HomeTeamYellowCards, AwayTeamYellowCards = @AwayTeamYellowCards, HomeTeamRedCards = @HomeTeamRedCards, AwayTeamRedCards = @AwayTeamRedCards WHERE Id = @Id";

			SqlConnection conn = new SqlConnection(ConnectionString);

			SqlCommand cmd = new SqlCommand(query, conn);

			cmd.Parameters.Add(new SqlParameter("@Id", id));
			cmd.Parameters.Add(new SqlParameter("@Result", result));
			cmd.Parameters.Add(new SqlParameter("@HomeTeamCorners", homeTeamCorners));
			cmd.Parameters.Add(new SqlParameter("@AwayTeamCorners", awayTeamCorners));
			cmd.Parameters.Add(new SqlParameter("@HomeTeamYellowCards", homeTeamYellowCards));
			cmd.Parameters.Add(new SqlParameter("@AwayTeamYellowCards", awayTeamYellowCards));
			cmd.Parameters.Add(new SqlParameter("@HomeTeamRedCards", homeTeamRedCards));
			cmd.Parameters.Add(new SqlParameter("@AwayTeamRedCards", awayTeamRedCards));

			conn.Open();
			cmd.ExecuteNonQuery();
			conn.Close();
		}

		public Match GetOpenMatch()
		{
			Match match = new Match();
			string query = "SELECT TOP 1 * FROM Match WHERE Result IS NULL";
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
								int homeid = (int)reader["HomeTeamId"];
								int awayid = (int)reader["AwayTeamId"];
								int id = (int)reader["Id"];
								
								
								match.Id = id;
								match.HomeTeam = GetTeamName(homeid);
								match.AwayTeam = GetTeamName(awayid);
								match.DateTime = (DateTime)reader["DateTime"];
								match.Available = (bool)reader["Available"];
								match.BettingOptions = GetBettingOptions(id);
								
								
							}
						}
					}
				}

				return match;
			}

		}

		public int GetMatchIdByBetRuleId(int id)
		{
			string query = "SELECT MatchId FROM BetChoice_Match WHERE Id = (SELECT BetChoice_MatchId FROM BetRule WHERE Id = " + id + ")";

			SqlDataAdapter sda = new SqlDataAdapter(query, new SqlConnection(ConnectionString));

			DataTable dt = new DataTable();
			sda.Fill(dt);

			int matchid = Convert.ToInt32(dt.Rows[0][0]);

			return matchid;
		}

		public List<BettingOption> GetBetRulesByMatchId(int id)
		{
			List<BettingOption> bettingOptions = new List<BettingOption>();
			string query = "SELECT Id, BetId, (SELECT Choice FROM BetChoice where Id = (SELECT BetChoiceId FROM BetChoice_Match WHERE Id = BetChoice_MatchId)) AS Choice, (SELECT Type FROM BetType where Id = (SELECT BetTypeId FROM BetChoice WHERE Id = (SELECT BetTypeId FROM BetChoice_Match WHERE Id = BetChoice_MatchId))) AS Type FROM BetRule WHERE BetChoice_MatchId IN (SELECT Id FROM BetChoice_Match WHERE MatchId = " + GetMatchIdByBetRuleId(id) + ")";
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
								BettingOption bettingOption = new BettingOption()
								{
									Id = (int)reader["Id"],
									BetId = (int)reader["BetId"],
									Choice = (string)reader["Choice"],
									Type = (string)reader["Type"]
								};
							}
						}
					}
				}

				return bettingOptions;
			}
		}

		public Match GetMatchStats(int id)
		{
			string query = "SELECT Id, Result, HomeTeamCorners, AwayTeamCorners, HomeTeamYellowCards, AwayTeamYellowCards, HomeTeamRedCards, AwayTeamRedCards FROM Match WHERE Id = " + id + "";

			SqlDataAdapter sda = new SqlDataAdapter(query, new SqlConnection(ConnectionString));

			DataTable dt = new DataTable();
			sda.Fill(dt);

			Match match = new Match();

			match.Id = Convert.ToInt32(dt.Rows[0][0]);
			match.Result = dt.Rows[0][1].ToString();
			match.HomeTeamCorners = Convert.ToInt32(dt.Rows[0][2]);
			match.AwayTeamCorners = Convert.ToInt32(dt.Rows[0][3]);
			match.HomeTeamYellowCards = Convert.ToInt32(dt.Rows[0][4]);
			match.AwayTeamYellowCards = Convert.ToInt32(dt.Rows[0][5]);
			match.HomeTeamRedCards = Convert.ToInt32(dt.Rows[0][6]);
			match.AwayTeamRedCards = Convert.ToInt32(dt.Rows[0][7]);


			return match;
		}

	}
}
