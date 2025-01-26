using Payments.Orders.Application.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Orders.Application.Abstractions
{
    public interface IAuthService
    {
        Task<UserResponse> Register(UserRegisterDto userRegisterModel);
        Task<UserResponse> Login(UserLoginDto userLoginDto);
    }
}
