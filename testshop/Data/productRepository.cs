using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testshop.Data.Entity;
using testshop.Data;
using System.Data.Entity;

namespace testshop.Data
{
    public class productRepository : IproductRepository
    {
        private  productContext _context;
        public productRepository()
        {
            _context = new productContext();
        }
        public async Task<bool> SaveChangesAsync()
        {
            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }
        public void Addproduct(product product)
        {
            _context.products.Add(product);            
        }
        public void Deleteproduct(product  product)
        {
            _context.products.Remove(product);
        }
        public async Task<product[]> GetAllproductAsync()
        {
            var query = _context.products
        .OrderBy(t => t.name);

            return await query.ToArrayAsync<product>();
        }
        public async Task<product> GetProductAsync(int id)
        {

            return await _context.products.FirstOrDefaultAsync(o => o.ID == id);
        }
        public void map(product product, product product2)
        {
            product.ID = product2.ID;
            product.name = product2.name;
            product.description = product2.description;
            product.price = product2.price;
        }

    }
}
