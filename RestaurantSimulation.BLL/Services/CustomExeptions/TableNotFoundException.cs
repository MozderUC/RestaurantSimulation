﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Services.CustomExeptions
{
    public class TableNotFoundException : Exception
    {
        public TableNotFoundException(string message)
        : base(message)
        { }
    }
}
