﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public List<SubCategory> Subcategories { get; set; }
    }
}
