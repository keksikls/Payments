using Payments.Orders.Application.Abstractions;
using Payments.Orders.Application.Models.Merchants;
using Payments.Orders.Domain;
using Payments.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Application.Services
{
    public class MerchantsService(OrdersDbContext context) : IMerchantsService
    {
        public async Task<MerchantDto> Create(MerchantDto merchant)
        {
            var entity = new MerchantEntity
            {
                Name = merchant.Name,
                Phone = merchant.Phone,
                WebSyte = merchant.WebSyte
            };

            var result = await context.Merchants.AddAsync(entity);
            var resultentity = result.Entity;

            await context.SaveChangesAsync();

            return new MerchantDto
            {
                Name = resultentity.Name,
                Phone = resultentity.Phone,
                WebSyte = resultentity.WebSyte  
            };
        }
    }
}
