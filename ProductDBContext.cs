using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netcore
{
    internal class ProductDBContext: DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options)
              : base(options) { }
        public DbSet<Product> Products{ get; set; }
    }
}
