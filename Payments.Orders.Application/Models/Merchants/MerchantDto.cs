using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Application.Models.Merchants
{
    public class MerchantDto
    {
        public long? Id { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public string WebSyte { get; set; }
    }
}

