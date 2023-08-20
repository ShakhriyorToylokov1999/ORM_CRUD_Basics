using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_CRUD.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
    }
}
