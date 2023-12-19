using Stocks.Enums;
using Stocks.Models;

namespace Stocks.utils
{
    public class TimeSeriesHandler
    {
        private readonly int DataPointsFromIntraday = 100;
        private readonly int DataPointsFromDaily = 100;
        private readonly int DataPointsFromWeekly = 599;
        private readonly int DataPointsFromMonthly = 138;
        public TimeSeriesHandler() { }


        public List<ResponseData> HandleIntraday(List<ResponseData> data, Interval interval)
        {
            DateTime startDate = CalculateIntradayStartTime(interval);
            foreach (ResponseData responseData in data)
            {
                Console.WriteLine("data in response object : " + responseData.Date);
            }
            List<ResponseData> dataForThatPeriod = FilterData(data, TimeSeries.INTRADAY, startDate);
            //Console.WriteLine("dataForThatPeriod " + dataForThatPeriod);
          
            return HandleReturnData(dataForThatPeriod, DataPointsFromIntraday);
        }

        public List<ResponseData> HandleDaily(List<ResponseData> data)
        {

            DateTime today = DateTime.Now;

            // Calculate the date exactly DataPointsFromDaily days back from today
            DateTime startDate = today.AddDays(-DataPointsFromDaily);

            List<ResponseData> dailyData = FilterData(data, TimeSeries.DAILY, startDate);

            return HandleReturnData(dailyData, DataPointsFromDaily);
        }
        public List<ResponseData> HandleWeekly(List<ResponseData> data)
        {
           
            DateTime today = DateTime.Now;

            // Calculate the date exactly DataPointsFromWeekly weeks back from today
            DateTime startDate = today.AddDays(-(DataPointsFromWeekly * 7));


            List<ResponseData> weeklyData = FilterData(data, TimeSeries.WEEKLY, startDate);


            return HandleReturnData(weeklyData, DataPointsFromWeekly);

        }



        public List<ResponseData> HandleMonthly(List<ResponseData> data)
        {

            DateTime today = DateTime.Now;

            // Calculate the date exactly DataPointsFromMonthly months back from today
            DateTime startDate = today.AddMonths(-DataPointsFromMonthly);


            List<ResponseData> monthlyData = FilterData(data, TimeSeries.MONTHLY, startDate);


            return HandleReturnData(monthlyData, DataPointsFromMonthly);
        }


        // private helper methods

        private DateTime CalculateIntradayStartTime(Interval interval)
        {
            // subtract 1 day from today , since api
            // returns data only after the day is closed
            // for non-premium package
            DateTime yesterday = DateTime.Now.AddDays(-1);
            // Calculate the start date based on the intraday interval
            return interval switch
            {
                Interval.OneMin => yesterday.AddMinutes(-DataPointsFromIntraday),
                Interval.FiveMin => yesterday.AddMinutes(-DataPointsFromIntraday * 5),
                Interval.FifteenMin => yesterday.AddMinutes(-DataPointsFromIntraday * 15),
                Interval.ThirtyMin => yesterday.AddMinutes(-DataPointsFromIntraday * 30),
                Interval.SixtyMin => yesterday.AddHours(-DataPointsFromIntraday),
                _ => throw new ArgumentException("Invalid intraday interval"),
            };
        }

        private List<ResponseData> FilterData(IEnumerable<ResponseData> data, TimeSeries timeSeries, DateTime startDate)
        {
            // Filter data with TimeSeries equal to timeSeries and within the desired date/time range
            Console.WriteLine("Logs from FilterData method");
            foreach(var item in data)
            {
                Console.WriteLine("DateTime.Parse(item.Date!) : " + DateTime.Parse(item.Date!));

            }
            Console.WriteLine("startDate : " + startDate);
            var result = data
                .Where(item => item.TimeSeries == timeSeries && DateTime.Parse(item.Date!) >= startDate)
                .OrderByDescending(item => DateTime.Parse(item.Date!)) // Order by date in descending order
                .ToList();
            foreach(var item in result)
            {
                Console.WriteLine("item in result : " + item);
            }
            return result;
        }

        private List<ResponseData> HandleReturnData(List<ResponseData> data, int dataPoints)
        {
            // If there are enough data points, return the data
            // If not enough data points, return null
            if (data.Count >= dataPoints)
            {
                return data.Take(dataPoints).ToList();
            }
            return null!;
        }

    }
}
