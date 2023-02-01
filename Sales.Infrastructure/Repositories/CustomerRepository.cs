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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SalesContext _context;
        private readonly IMapper _mapper;
        public CustomerRepository(SalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CustomerDto> GetCustomers()
        {
            List<CustomerDto> listado = _context.Customers.Select<Customer,CustomerDto>(
                                        x => _mapper.Map<CustomerDto>(x)).ToList();
            return listado;
        }

        public bool PostCustomer(CustomerDto customer)
        {
            Customer customer1 = _mapper.Map<Customer>(customer);
            _context.Add(customer1);
            _context.SaveChanges();
            return true;
        }
    }
}
