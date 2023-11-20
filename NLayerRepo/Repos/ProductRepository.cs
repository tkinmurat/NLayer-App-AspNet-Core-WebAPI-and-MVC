using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerRepo.Repos
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
           return await _context.Products.Include(x=>x.Category).ToListAsync();
        }
    }
}
