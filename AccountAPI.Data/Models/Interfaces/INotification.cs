using AccountAPI.Data.Models.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAPI.Data.Models.Interfaces
{
    public interface INotification: IBaseModel
    {
        public string Message { get; set; }
        public Account Account { get; set; }
    }
}
