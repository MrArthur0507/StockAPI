namespace Settlement.API.Controllers.SettlementContracts
{
    public interface IGetStockPriceService
    {
        public Task<double> GetStockPrice(string stock);
    }
}
