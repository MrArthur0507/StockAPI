using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlementContracts
{
    public interface IQuarzScheduler
    {
        public Task<IActionResult> QuarzScheduler();
    }
}
