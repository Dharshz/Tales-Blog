
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales.Data.Infrastructure;
using Tales.Data.Repositories;
using Tales.Modal;

namespace Tales.Services
{
    public interface IUserService
    {
        User GetUserById(string id);

        int GetUserCount();


        bool RemoveUser(string userId);

        void SaveChanges();

    }
    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork;
        private IUserRepository userRepository;


        public UserService(IUserRepository ur, IUnitOfWork now)
        {
            this.unitOfWork = now;
            this.userRepository = ur;
        }

        public User GetUserById(string id)
        {
            return userRepository.GetUserById(id);
        }

        public int GetUserCount()
        {
            return userRepository.GetUserCount();
        }


        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetUsers();
        }


        public bool RemoveUser(string userId)
        {
            return userRepository.RemoveUser(userId);
        }


        public void SaveChanges()
        {
            unitOfWork.Commit();
        }
    }
}
