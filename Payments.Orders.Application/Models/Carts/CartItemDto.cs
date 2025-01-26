using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Application.Models.Carts
{
    public class CartItemDto
    {
        public long? Id { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}