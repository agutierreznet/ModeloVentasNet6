using AutoMapper;
using Sales.ApplicationCore.DTOs;
using Sales.ApplicationCore.Entities;
using Sales.ApplicationCore.Interfaces;
using Sales.Infrastructure.Contexts;

namespace Sales.Infrastructure.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly SalesContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(SalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ProductDto> GetProducts()
        {
            List<ProductDto> listado = _context.Products.Select<Product, ProductDto>(
                                        x => _mapper.Map<ProductDto>(x)).ToList();
            return listado;
        }

        public bool PostProduct(ProductDto product)
        {
            Product product1 = _mapper.Map<Product>(product);
            _context.Add(product1);
            _context.SaveChanges();
            return true;
        }
    }
}
