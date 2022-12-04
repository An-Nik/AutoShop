﻿using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    public interface ICategories
    {
        IEnumerable<Category> Categories { get; }
    }
}
