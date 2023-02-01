using Sales.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ApplicationCore.Interfaces
{
    public interface ISaleRepository
    {
        List<SaleDto> GetSales();
        bool PostSale(SaleDto sale);
    }
}
