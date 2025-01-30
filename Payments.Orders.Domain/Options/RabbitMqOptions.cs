using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Domain.Options
{
    public class RabbitMqOptions
    {
        public string HostName { get; set; } = null!;
        public int Port { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string VirtualHost { get; set; } = null!;
        public string LifeArmStatusesQueueName { get; set; } = null!;
        public string CreateOrderQueueName { get; set; } = null!;


    }
}
