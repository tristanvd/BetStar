using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
	public class BalanceContext
	{
		private string ConnectionString { get; set; } = "Data Source=DESKTOP-38T55SN;Initial Catalog=TotoDB;User ID=sa;Password=784512tyghvB;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		public void Deposit(int id, decimal deposit)
		{
			decimal balance = deposit + GetBalance(id);

			string query = "UPDATE [User] SET Balance = " + balance + " where Id = " + id + "";

			string query2 = "INSERT INTO [Transaction] (UserId, Amount, DateTime) VALUES(@UserId, @Amount, @DateTime)";

			SqlConnection con = new SqlConnection(ConnectionString);

			SqlCommand updatebalance = new SqlCommand(query, con);
			SqlCommand transaction = new SqlCommand(query2, con);
			transaction.Parameters.Add(new SqlParameter("@UserId", id));
			transaction.Parameters.Add(new SqlParameter("@Amount", deposit));
			transaction.Parameters.Add(new SqlParameter("@DateTime", DateTime.Now));
			con.Open();
			updatebalance.ExecuteNonQuery();
			transaction.ExecuteNonQuery();
			con.Close();
		}

		public void Withdrawal(int id, decimal withdrawal)
		{
			decimal balance = GetBalance(id) - withdrawal;

			string query = "UPDATE [User] SET Balance = " + balance + " where Id = " + id + "";

			string query2 = "INSERT INTO [Transaction] (UserId, Amount, DateTime) VALUES(@UserId, @Amount, @DateTime)";

			SqlConnection con = new SqlConnection(ConnectionString);

			SqlCommand updatebalance = new SqlCommand(query, con);
			SqlCommand transaction = new SqlCommand(query2, con);
			transaction.Parameters.Add(new SqlParameter("@UserId", id));
			transaction.Parameters.Add(new SqlParameter("@Amount", withdrawal));
			transaction.Parameters.Add(new SqlParameter("@DateTime", DateTime.Now));
			con.Open();
			updatebalance.ExecuteNonQuery();
			transaction.ExecuteNonQuery();
			con.Close();
		}

		public decimal GetBalance(int id)
		{
			string query = "SELECT Balance FROM [User] WHERE Id = " + id + "";

			SqlDataAdapter sda = new SqlDataAdapter(query, new SqlConnection(ConnectionString));

			DataTable dt = new DataTable();
			sda.Fill(dt);
			decimal balance = Convert.ToDecimal(dt.Rows[0][0]);
			return balance;
		}
	}
}
