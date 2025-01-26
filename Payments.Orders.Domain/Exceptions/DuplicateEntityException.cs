using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Domain.Exceptions
{
    public class DuplicateEntityException(string? message = null) : Exception(message)
    {

    }
}
