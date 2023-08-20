using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_CRUD.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ProductId { get; set; }
        public string Status { get; set; }
    }
}
