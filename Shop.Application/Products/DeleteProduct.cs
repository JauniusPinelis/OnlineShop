using Shop.Database;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DeleteProduct
{
    public class DeleteProduct
    {
        public ApplicationDbContext _context { get; set; }

        public DeleteProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Do(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }

       
    }

}
