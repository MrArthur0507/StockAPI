using AccountAPI.Data.Models.Implementation;
using StockApiRepDB.Interfaces;
using StockApiRepDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApiRepDB.Data
{
    public class RepDataManager:IRepDataManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _connectionString = "Server=DESKTOP-4UNOHKM\\SQLEXPRESS;Initial Catalog=StockTestingNew;Integrated Security=SSPI;Trusted_Connection=True;TrustServerCertificate=True;";
        public RepDataManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Start()
        {
            _unitOfWork.CreateDb(_connectionString);
            var accountRep = _unitOfWork.GetRepository<Account>(_connectionString);
            accountRep.CreateIfNotExists();
            var stockRep = _unitOfWork.GetRepository<Stock>(_connectionString);
            stockRep.CreateIfNotExists();
            var trancastionRep = _unitOfWork.GetRepository<Transaction>(_connectionString);
            trancastionRep.CreateIfNotExists();
        }
        public void DeleteTable<T>() where T : class
        {
            var repository = _unitOfWork.GetRepository<T>(_connectionString);
            repository.DeleteIfExists();
        }
    }
}
