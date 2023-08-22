﻿using System.ComponentModel.DataAnnotations;

namespace IEnumerable_IQueryable
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}


