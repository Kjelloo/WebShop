using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebShop.Core.Models;
using WebShop.Core.Repositories;
using WebShop.Infrastructure.Data.Entities;

namespace WebShop.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WebShopContext _ctx;

        public UserRepository(WebShopContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(User user)
        {
            var userAdd = new UserEntity
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password
            };
            
            _ctx.Users.Add(userAdd);
            _ctx.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            var selectQuery = _ctx.Users
                .Select(user => new User
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password
                });
            return selectQuery;
        }
    }
}