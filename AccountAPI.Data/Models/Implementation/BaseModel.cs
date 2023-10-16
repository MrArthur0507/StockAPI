using AccountAPI.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAPI.Data.Models.Implementation
{
    public class BaseModel : IBaseModel
    {
        public Guid Id { get ; set ; }
        public BaseModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
