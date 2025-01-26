using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Domain.Entities
{
    public class CartItemEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public int Price { get; set; }

        public CartEntity? Cart { get; set; }
        public long? CartId { get; set; }
    }
}
