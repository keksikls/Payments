using Payments.Orders.Application.Models.Carts;
using Payments.Orders.Application.Models.Orders;
using Payments.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Application.Mappers
{
    public static class OrdersMapper
    {
        public static OrderDto ToDto(this OrderEntity entity, CartEntity? cart = null)
        {
            return new OrderDto
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId!.Value,
                Cart = cart == null ? entity.Cart?.ToDto() : cart.ToDto(),
                Name = entity.Name,
                OrderNumber = entity.OrderNumber
            };
        }

        public static OrderEntity ToEntity(this CreateOrderDto entity, CartDto? cart = null)
        {
            return new OrderEntity
            {

                CustomerId = entity.CustomerId,
                Cart = cart?.ToEntity(),
                Name = entity.Name,
                OrderNumber = entity.OrderNumber
            };
        }
    }
}