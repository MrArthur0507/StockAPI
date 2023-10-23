namespace Analyzer.API.Models
{
	public class DailyReturnChange
	{
		public string Symbol { get; set; }
		public decimal Change { get; set; }
		public DateTime Date { get; set; }
	}
}
