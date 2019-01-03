using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public class User
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime Birthdate { get; set; }
		public string Country { get; set; }
		public string Username { get; set; }
		public string Name { get; set; }
		public decimal Balance { get; set; }
		public int RoleId { get; set; }
	}
}
