using Analyzer.API.Services.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Analyzer.API.Services
{
	public class CurrentProfit:ICurrentProfit
	{
		public decimal GetCurrentProfit()
		{
			return 0;
		}
	}
}
