using AccountAPI.Data.Models.Implementation;
using Accounts.API.Services.Interfaces;
using Accounts.API.Services.ViewModels;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockAPI.Database.Interfaces;
using System.Web.Mvc;

namespace Accounts.API.Services.Implementation
{
    public class TransactionService : ITransactionService
    {

        private readonly IDataManager _dataManager;
        public TransactionService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public int CreateTransaction(TransactionViewModel transaction)
        {
            var transactions = _dataManager.SelectData<Transaction>("Transactions");
            var user = _dataManager.SelectData<Account>("Accounts").SingleOrDefault((acc) => acc.Id == transaction.AccountId);
            if (transaction == null || user == null || transactions.Any(acc => acc.StockName == transaction.StockName && acc.AccountId == transaction.AccountId))
            {
                return StatusCodes.Status400BadRequest;
            }
            var transactionDb = new Transaction(transaction.AccountId, transaction.StockName, transaction.Date, transaction.Price, transaction.Quantity);
            try
            {
                _dataManager.InsertData(transactionDb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCodes.Status400BadRequest;
            }
            SaveTransactionToPdf(transactionDb, "D:\\VTU software engineering\\C#\\StockAPI\\Accounts.API\\transactions");
            return StatusCodes.Status201Created;
        }
        public List<TransactionViewModel> GetAllTransactionsForUser(string userId)
        {
            var transactions = _dataManager.SelectData<Transaction>("Transactions").Where((transaction) => transaction.AccountId == userId);
            List<TransactionViewModel> result = new List<TransactionViewModel>();
            if (transactions != null)
            {
                foreach (var transaction in transactions)
                {
                    result.Add(new TransactionViewModel(transaction.AccountId, transaction.StockName, transaction.Date, transaction.Price, transaction.Quantity));
                }
            }
            return result;
        }
        public List<TransactionViewModel> GetAllTransactionsByStock(string stockId)
        {
            var transactions = _dataManager.SelectData<Transaction>("Transactions").Where((transaction) => transaction.StockName == stockId);
            List<TransactionViewModel> result = new List<TransactionViewModel>();
            if (transactions != null)
            {
                foreach (var transaction in transactions)
                {
                    result.Add(new TransactionViewModel(transaction.AccountId, transaction.StockName, transaction.Date, transaction.Price, transaction.Quantity));
                }
            }
            return result;
        }
        public ServiceResponse GetExistingPdf(string filePath)
        {
            try
            {
                byte[] pdfContent;


                using (MemoryStream stream = new MemoryStream())
                {
                    using (PdfReader pdfReader = new PdfReader(filePath))
                    {
                        using (PdfWriter pdfWriter = new PdfWriter(stream))
                        {
                            using (PdfDocument pdf = new PdfDocument(pdfReader, pdfWriter))
                            {
                                
                            }
                            pdfContent=stream.ToArray();
                        }
                    }
                }

                return new ServiceResponse
                {
                    PdfContent = pdfContent,
                    FileName = Path.GetFileName(filePath),
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ServiceResponse
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }
        }
        private void SaveTransactionToPdf(Transaction transaction, string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = $"{transaction.Date.ToString("yyyyMMdd")}_{transaction.AccountId}_TransactionDetails.pdf";

            // Combine the folder path and filename
            string filePath = Path.Combine(folderPath, fileName);
            using (var writer = new PdfWriter(filePath, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf);
                    document.Add(new Paragraph($"Transaction Details\n\n" +
                                               $"Account ID: {transaction.AccountId}\n" +
                                               $"Stock Name: {transaction.StockName}\n" +
                                               $"Date: {transaction.Date}\n" +
                                               $"Price: {transaction.Price}\n" +
                                               $"Quantity: {transaction.Quantity}\n"));
                    document.Close();
                }
            }
        }

        }
    }
