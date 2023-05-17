using System;
using System.Collections.Generic;

namespace SalesTransactionApi.Models
{
    public partial class Customer
    {
        public Customer()
        {
            SalesTransaction = new HashSet<SalesTransaction>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<SalesTransaction> SalesTransaction { get; set; }
    }
}
