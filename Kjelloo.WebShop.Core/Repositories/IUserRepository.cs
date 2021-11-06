using System.Collections;
using System.Collections.Generic;
using WebShop.Core.Models;

namespace WebShop.Core.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        IEnumerable<User> GetAll();
        
    }
}