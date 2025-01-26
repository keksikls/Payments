﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Domain.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public DateTime? BirthDate { get; set; }

        public List<OrderEntity>? Orders { get; set; }
    }
}
