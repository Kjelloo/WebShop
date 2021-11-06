using System.Collections;
using System.Collections.Generic;
using WebShop.Core.Models;

namespace WebShop.Core.Services
{
    public interface IUserService
    {
        void Create(User user);
        List<User> GetAll();
    }
}