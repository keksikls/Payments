using Microsoft.EntityFrameworkCore;
using Payments.Orders.Application.Abstractions;
using Payments.Orders.Application.Mappers;
using Payments.Orders.Application.Models.Orders;
using Payments.Orders.Domain;
using Payments.Orders.Domain.Entities;
using Payments.Orders.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Application.Services
{
    public class OrdersService(OrdersDbContext context, ICartsService cartsService) : IOrdersService
    {
        public async Task<OrderDto> Create(CreateOrderDto order)
        {
            if (order.Cart == null)
            {
                throw new ArgumentNullException();
            }

            var cart = await cartsService.Create(order.Cart);

            var entity = new OrderEntity
            {
                OrderNumber = order.OrderNumber,
                Name = order.Name,
                CustomerId = order.CustomerId,
                CartId = cart.Id
            };

            var orderSaveResult = await context.Orders.AddAsync(entity);
            await context.SaveChangesAsync();

            var orderEnityResult = orderSaveResult.Entity;

            return orderEnityResult.ToDto();
        }

        public async Task<List<OrderDto>> GetAll()
        {
            var entity = await context.Orders
                 .Include(u => u.Cart)
                 .ThenInclude(x => x.CartItems)
                 .ToListAsync();

            return entity.Select(x => x.ToDto()).ToList();
        }

        public async Task<OrderDto> GetById(long orderId)
        {
            var entity = await context.Orders
                .Include(u => u.Cart)
                .ThenInclude(x => x.CartItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (entity == null)
            {
                throw new EntityNotFoundException(message: $"Order entity with id {orderId} not found");
            }

            return entity.ToDto();

        }

        public async Task<List<OrderDto>> GetByUser(long customerId)
        {
            var entity = await context.Orders
                .Include(u => u.Cart)
                .ThenInclude(x => x.CartItems)
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();

            return entity.Select(x => x.ToDto()).ToList();
        }

        public Task Reject(long orderId)
        {
            throw new NotImplementedException();
        }
    }
}