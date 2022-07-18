using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantResources.Data.Repository.IRepository;
using TenantResources.Models;

namespace TenantResources.Data.Repository
{
    //internal class ProductRepository
    public class ProductRepository : IProductRepository
    {
        private readonly TenantDbContext _context;
        public ProductRepository(TenantDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateAsync(string name, string description, int rate)
        {
            var product = new Product(name, description, rate);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
