using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Domain.Entities
{
    public class MerchantEntity : BaseEntity
    {
        
        public required string Name { get; set; }
       
        public required string Phone { get; set; }
        public string WebSyte { get; set; }
        public List<UserEntity> Users { get; set; }
    }
}
