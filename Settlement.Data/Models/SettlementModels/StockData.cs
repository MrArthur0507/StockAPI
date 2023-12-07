namespace Settlement.Infrastructure.Models.SettlementModels
{
    public class StockData
    {

        public StockData() { }
        public StockData(DateTime date, double Open, double High, double Low, double Close, long Volume)
        {
            Date = date;
            this.Open = Open;
            this.High = High;
            this.Low = Low;
            this.Close = Close;
            this.Volume = Volume;
        }
        public DateTime Date { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public long Volume { get; set; }
    }

}
