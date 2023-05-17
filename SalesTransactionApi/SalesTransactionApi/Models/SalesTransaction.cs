using System;
using System.Collections.Generic;

namespace SalesTransactionApi.Models
{
    public partial class SalesTransaction
    {
        public int SalesTransactionId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double Amount { get; set; }
        public bool? Invoice { get; set; }
        public DateTime TransactionDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
