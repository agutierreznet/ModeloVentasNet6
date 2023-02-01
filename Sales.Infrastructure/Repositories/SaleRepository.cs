using AutoMapper;
using Sales.ApplicationCore.DTOs;
using Sales.ApplicationCore.Entities;
using Sales.ApplicationCore.Interfaces;
using Sales.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repositories
{
    public class SaleRepository:ISaleRepository
    {
        private readonly SalesContext _context;
        private readonly IMapper _mapper;
        public SaleRepository(SalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SaleDto> GetSales()
        {
            List<SaleDto> listado = _context.Sales.Select<Sale, SaleDto>(
                                        x => _mapper.Map<SaleDto>(x)).ToList();
            return listado;
        }

        public bool PostSale(SaleDto sale)
        {
            Sale sale1 = _mapper.Map<Sale>(sale);
            _context.Add(sale1);
            _context.SaveChanges();
            return true;
        }
    }
}
