using Sales.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ApplicationCore.Interfaces
{
    public interface IProductRepository
    {
        List<ProductDto> GetProducts();
        bool PostProduct(ProductDto product);
    }
}
