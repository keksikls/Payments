using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Application.Models.Orders
{
    public class OrderDto : CreateOrderDto
    {
        public long Id { get; set; }
    }
}