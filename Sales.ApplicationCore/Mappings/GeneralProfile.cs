using AutoMapper;
using Sales.ApplicationCore.DTOs;
using Sales.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ApplicationCore.Mappings
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<Usuario, UsuarioDto>();

            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();

            CreateMap<SaleDto, Sale>();
            CreateMap<Sale, SaleDto>();

        }
    }
}
