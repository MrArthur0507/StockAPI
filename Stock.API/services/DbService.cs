using Microsoft.EntityFrameworkCore;
using Stocks.DB;
using Stocks.Enums;
using Stocks.Interfaces;
using Stocks.Models;

namespace Stocks.utils
{
    public class DbService
    {


        private readonly ApplicationDbContext _context;

        private readonly TimeSeriesHandler _seriesHandler;

        public DbService(ApplicationDbContext context, TimeSeriesHandler seriesHandler)
        {
            _context = context;
            _seriesHandler = seriesHandler;
        }

        public async Task<List<ResponseData>> GetDataFromDb(IBaseStock stock)
        {
            string stockSymbol = stock.Symbol!;
            var data = await SymbolData(stockSymbol);

            if (data != null)
            {
                switch (stock.TimeSeries)
                {
                    case TimeSeries.INTRADAY:
                        {

                            return _seriesHandler.HandleIntraday(data, (Interval)stock.Interval!);

                        }

                    case TimeSeries.DAILY:
                        {
                            return _seriesHandler.HandleDaily(data);
                        }

                    case TimeSeries.WEEKLY:
                        {
                            return _seriesHandler.HandleWeekly(data);
                        }

                    case TimeSeries.MONTHLY:
                        {
                            return _seriesHandler.HandleMonthly(data);
                        }

                    default:
                        {
                            return null!;
                        }
                }
            }

            return null!;


        }




        private async Task<List<ResponseData>> SymbolData(string Symbol)
        {
            List<ResponseData> result = await _context.Responses.Where(res => res.Symbol == Symbol).ToListAsync();
            return result;

        }

        public async Task AddToDb(IEnumerable<ResponseData> data)
        {
            try
            {
                foreach (ResponseData dataPoint in data)
                {
                    await _context.Responses.AddAsync(dataPoint);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in AddToDb: {ex.Message}");
            }
        }

    }
}