﻿using Shop.Database;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
    public class CreateProduct
    {
        public ApplicationDbContext _context { get; set; }

        public CreateProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Do(ProductViewModel vm)
        {
            _context.Add(new Product()
            {
                Name = vm.Name,
                Description = vm.Description,
                Value = vm.Value
            });
                
            await _context.SaveChangesAsync();
        }

        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }


    }
   
}
