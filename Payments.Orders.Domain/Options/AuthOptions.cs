using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Domain.Options
{
    public class AuthOptions
    {
        public string TokenPrivateKey { get; set; } = null!;
        public long ExpireIntervalMinutes { get; set; }
    }
}
