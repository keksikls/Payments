using Payments.Orders.Application.Models.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Application.Abstractions
{
    public interface ICartsService
    {
        Task<CartDto> Create(CartDto cart);
    }
}