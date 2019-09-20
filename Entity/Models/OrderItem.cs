﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Order Order { get; set; }
    }
}
