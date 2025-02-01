using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Domain.Models
{
    public enum OrderStatusType
    {
        Created = 1,
        Pending,
        Succes,
        Reject,
        Fail,
        Error
    }
}
