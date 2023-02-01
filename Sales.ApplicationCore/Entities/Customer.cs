using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ApplicationCore.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
