using PizzaTimeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Managers
{
    public interface IAuthenticationManager
    {
        Task Signup(RegisterModel registerModel);
        Task<TokensModel> Login(LoginModel loginModel);
    }
}
