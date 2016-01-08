
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales.Data.Infrastructure;
using Tales.Modal;

namespace Tales.Data.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(string id);

        int GetUserCount();

        IEnumerable<User> GetUsers();

        bool RemoveUser(string userId);
    }

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {


        public UserRepository(IDbFactory factory):base(factory)
        {

        }
        public User GetUserById(string id)
        {
            return base.Get(a => a.Id == id);
        }

        public int GetUserCount()
        {
            return GetAll().Count();
        }

        public IEnumerable<User> GetUsers()
        {
            return GetAll();
        }


        public bool RemoveUser(string userId)
        {
            var user = GetUserById(userId);

            if (user == null) return false;

            Delete(user);

            return true;
            
        }
    }
}
