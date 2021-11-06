using System.Collections.Generic;
using System.Linq;
using WebShop.Core.Models;
using WebShop.Core.Repositories;
using WebShop.Core.Services;

namespace WebShop.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public void Create(User user)
        {
            _userRepo.Create(user);
        }

        public List<User> GetAll()
        {
            return _userRepo.GetAll().ToList();
        }
    }
}