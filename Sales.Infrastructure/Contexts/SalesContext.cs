using Microsoft.EntityFrameworkCore;
using Sales.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Contexts
{
    public partial class SalesContext : DbContext
    {

        public SalesContext()
        {

        }

        public SalesContext(DbContextOptions<SalesContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleDetail> SaleDetails { get; set; }


    }
}