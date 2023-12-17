using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.API.Services.ViewModels
{
    public class ServiceResponse
    {
        public byte[] PdfContent { get; set; }
        public string FileName { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
