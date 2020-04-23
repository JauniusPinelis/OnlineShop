﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Cart
{
	public class AddToCart
	{
		private readonly ISession _session;

		public AddToCart(ISession session)
		{
			_session = session;
		}

		public class Request
		{
			public int StockId { get; set; }
			public int Qty { get; set; }	
		}

		public void Do(Request request)
		{
			var cartProduct = new CartProduct()
			{
				StockId = request.StockId,
				Qty = request.StockId
			};

			var stringObject = JsonConvert.SerializeObject(cartProduct);

			_session.SetString("cart", stringObject);
		}
	}
}