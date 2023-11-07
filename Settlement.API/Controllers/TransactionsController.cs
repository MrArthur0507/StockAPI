using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SettlementServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data.SqlClient;
using System.Data;

namespace Settlement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ApiAccountService _apiAccountService;
        private readonly ApiStockService _apiStockService;

        public TransactionsController(ApiAccountService apiAccountService, ApiStockService apiStockService)
        {
            _apiAccountService = apiAccountService;
            _apiStockService = apiStockService;
        }


        [HttpPatch]
        public async Task<IActionResult> Transaction(string accountId, string stockName)
        {
            try
            {
                await _apiAccountService.GetAccountByIdAsync(accountId);
                await _apiStockService.GetStockByName(stockName);


                string connectionString = "Server=(Local)\\SQLEXPRESS01;Database=StockApiAccounts;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Your SQL operations will go here.
                

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    // Define your SQL query
                    string sqlQuery = "INSERT INTO YourTable (Column1, Column2) VALUES (@Value1, @Value2)";
                    command.CommandText = sqlQuery;

                    // Add parameters to the query to prevent SQL injection


                    //command.Parameters.AddWithValue("@Value1", value1);
                    //command.Parameters.AddWithValue("@Value2", value2);

                    // Execute the SQL command
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check rowsAffected to see if the operation was successful
                }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            return BadRequest("Not enough credit to buy the stock!");


            


        }
    }
}
