using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testshop.Data.Entity;
using System.Data.Entity;



namespace testshop.Data
{
    public interface IproductRepository
    {
        
        Task<bool> SaveChangesAsync();

        
        void Addproduct(product product);
        void Deleteproduct(product product);
        //Task<product[]> GetAllproductsAsync(bool includeproduct = false);
        //Task<product> GetproductAsync(string moniker, bool includeproduct = false);
        //Task GET();
        Task<product[]> GetAllproductAsync();
        Task<product> GetProductAsync(int productId);
        void map(product product, product product2);

        //Task<product[]> GetAllproductByEventDate(DateTime dateTime, bool includeproduct = false);
    }
}
