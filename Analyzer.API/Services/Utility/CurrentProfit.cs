
using Analyzer.API.Models;
using Analyzer.API.Services.Contracts;
using Newtonsoft.Json;
namespace Analyzer.API.Services.Utility
{
	public class CurrentProfit: ICurrentProfit
	{
		private readonly HttpClient _httpClient;
		public CurrentProfit(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<decimal> GetCurrentProfit(string userId)
		{
			using (var client = new HttpClient())
			{
				string apiUrl = $" http://localhost:5000/api/Account/getById?Id={userId}";
				var response = await _httpClient.GetAsync(apiUrl);
				response.EnsureSuccessStatusCode();

				var content = await response.Content.ReadAsStringAsync();
				var account = JsonConvert.DeserializeObject<User>(content);

				return account.Balance;
			}
		}

	}
}
