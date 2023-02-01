using Sales.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ApplicationCore.DTOs
{
    public class SaleDto
    {
        public int SaleId { get; set; }
        public string CustomerId { get; set; }
        public decimal Total { get; set; }

        public List<SaleDetail> SaleDetails { get; set; }
    }
}
