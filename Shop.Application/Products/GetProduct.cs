using Microsoft.EntityFrameworkCore;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.GetProduct
{
    public class GetProduct
    {
        private readonly ApplicationDbContext _ctx;

        public GetProduct(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ProductViewModel Do(string name) =>
            _ctx.Products
            .Include(p => p.Stock)
            .Where(p => p.Name == name)
            .Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Value = x.Value,
                Stock = x.Stock.Select( y => new StockViewModel
                {
                    Id = y.Id,
                    Description = y.Description,
                    InStock = y.Qty > 0
                    
                })
            }).FirstOrDefault();


        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }

            public IEnumerable<StockViewModel> Stock { get; set; }
        }

        public class StockViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }

            public bool InStock { get; set; }
        }
    }
}
