using AccountAPI.Data.Models.Interfaces;
using StockAPI.Database.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAPI.Data.Models.Implementation
{
    public class BaseModel : DummyModel, IBaseModel
    {
        public string Id { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public BaseModel()
        {
            Id = Guid.NewGuid().ToString();
            IsDeleted = false;
        }
    }
}
