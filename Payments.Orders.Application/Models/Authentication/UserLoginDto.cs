using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Application.Models.Authentication
{
   public record UserLoginDto(string Username, string Email, string Phone, string Password);
}
