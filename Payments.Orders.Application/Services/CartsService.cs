using Microsoft.EntityFrameworkCore;
using Payments.Orders.Application.Abstractions;
using Payments.Orders.Application.Mappers;
using Payments.Orders.Application.Models.Carts;
using Payments.Orders.Domain;
using Payments.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Application.Services
{
    public class CartsService(OrdersDbContext context) : ICartsService
    {
        public async Task<CartDto> Create(CartDto cart)
        {
            var cartEntity = new CartEntity();
            var cartSaveResult = await context.Carts.AddAsync(cartEntity);
            await context.SaveChangesAsync();


            var cartItems = cart.CartItems
                .Select(item => new CartItemEntity
                {
                    Name = item.Name,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    CartId = cartSaveResult.Entity.Id
                });

            await context.CartItems.AddRangeAsync(cartItems);
            await context.SaveChangesAsync();

            var result = await context.Carts
                .Include(x => x.CartItems)
                .FirstAsync(x => x.Id == cartSaveResult.Entity.Id);

            return result.ToDto();
        }
    }
}