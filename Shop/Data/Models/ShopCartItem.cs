﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public int Price { get; set; }
        public string ShopCartID { get; set; }
    }
}