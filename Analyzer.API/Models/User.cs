namespace Analyzer.API.Models
{
	public class User
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public decimal Balance { get; set; }
		public User(string username, string email, decimal balance)
		{
			Username = username;
			Email = email;
			Balance = balance;
		}
	}
}

