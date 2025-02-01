using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Domain.Extensions
{
    public static class ErrorExtensions
    {
        public static string ToText(this Exception exeption) 
        {

            return $"{exeption.Message} {exeption.StackTrace} {exeption.InnerException?.Message} {exeption.InnerException?.StackTrace}";
        }
    }
}
