using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ApplicationCore.Entities
{
    public partial class Product
    {
        public Product()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
