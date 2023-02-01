using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ApplicationCore.Entities
{
    public partial class SaleDetail
    {
        public int SaleDetailId { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        public virtual Sale SaleIdNavigation { get; set; }
        public virtual Product ProductIdNavigation { get; set; }
    }
}
