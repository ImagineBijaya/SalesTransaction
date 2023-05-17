using System;
using System.Collections.Generic;

namespace SalesTransactionApi.Models
{
    public partial class Product
    {
        public Product()
        {
            SalesTransaction = new HashSet<SalesTransaction>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductUnit { get; set; }
        public double ProductPrice { get; set; }

        public virtual ICollection<SalesTransaction> SalesTransaction { get; set; }
    }
}
