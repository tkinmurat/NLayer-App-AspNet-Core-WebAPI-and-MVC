using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerRepo.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product { Id = 1, CategoryId = 1, Name="Mercedes-Benz",Price=10000000, Stock=2,CreatedDate=DateTime.Now },
                            new Product { Id = 2, CategoryId = 1, Name = "BMW", Price = 5000000, Stock = 5, CreatedDate = DateTime.Now },
                            new Product { Id = 3, CategoryId = 2, Name = "Audi", Price = 15000000, Stock = 1, CreatedDate = DateTime.Now },
                            new Product { Id = 4, CategoryId = 2, Name = "Nissan", Price = 25000000, Stock = 1, CreatedDate = DateTime.Now });
        }
    }
}
