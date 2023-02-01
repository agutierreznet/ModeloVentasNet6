using Sales.ApplicationCore.DTOs;
using Sales.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ApplicationCore.Interfaces
{
    public interface ICustomerRepository
    {
        List<CustomerDto> GetCustomers();
        bool PostCustomer(CustomerDto customer);
    }
}
