using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Domain.Exceptions
{
    public class EntityNotFoundException(string message) : Exception(message);

    public class SoftEntityNotFoundExeption(string message) : Exception(message);

}