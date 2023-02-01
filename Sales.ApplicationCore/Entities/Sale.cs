using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ApplicationCore.Entities
{
    public partial class Sale
    {
        public Sale()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public int SaleId { get; set; }
        public string CustomerId { get; set; }
        public decimal Total { get; set; }

        public virtual Customer CustomerIdNavigation { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
