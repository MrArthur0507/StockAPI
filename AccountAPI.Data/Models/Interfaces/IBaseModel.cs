﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAPI.Data.Models.Interfaces
{
    public interface IBaseModel
    {
        public string Id { get; set; }
        //public bool IsDeleted { get; set; }
    }
}
