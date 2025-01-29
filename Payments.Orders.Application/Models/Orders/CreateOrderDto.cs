using Payments.Orders.Application.Models.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Application.Models.Orders
{
    public class CreateOrderDto
    {
        public string? Name { get; set; }
        public long OrderNumber { get; set; }
        public long CustomerId { get; set; }
        public CartDto? Cart { get; set; }
        public long MerchantId { get; set; }
    }
}