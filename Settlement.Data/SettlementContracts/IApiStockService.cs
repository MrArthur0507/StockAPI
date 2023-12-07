namespace Settlement.API.Controllers.SettlementContracts
{
    public interface IApiStockService
    {
        public Task<String> GetStockByName(Stocks.Models.Stock stock);
    }
}
