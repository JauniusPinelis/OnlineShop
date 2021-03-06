﻿using Shop.Database;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.StockAdmin
{
    public class CreateStock
    {
        private ApplicationDbContext _ctx;

        public CreateStock(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do(Request request)
        {
            var stock = new Stock()
            {
                ProductId = request.ProductId,
                Description = request.Description,
                Qty = request.Qty
            };

            _ctx.Stock.Add(stock);

            await _ctx.SaveChangesAsync();

            return new Response()
            {
                ProductId = request.ProductId,
                Description = request.Description,
                Qty = request.Qty

            };
        }

        public class Request
        {
            public int ProductId { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }

        }

        public class Response{
            public int ProductId { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }
        }
    }
}
