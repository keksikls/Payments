﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Domain.Entities
{
    public class CartEntity : BaseEntity
    {
        public List<CartItemEntity>? CartItems { get; set; }
    }
}
