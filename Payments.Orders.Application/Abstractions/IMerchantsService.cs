using Payments.Orders.Application.Models.Merchants;
using Payments.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Application.Abstractions
{
    public interface IMerchantsService
    {
        Task<MerchantDto> Create (MerchantDto merchant);
    }
}
