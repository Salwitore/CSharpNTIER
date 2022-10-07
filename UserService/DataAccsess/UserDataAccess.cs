
using Data;
using Store.UsersStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess
{   
    //Data'ya erişim businessa returnlediğim kısım
    public class UserDataAccess
    {
        public List<User> GetUsers()
        {
            return UserStore.Users;
        }
        public void AddUser(User user)
        {
            UserStore.Users.Add(user);
        }
        public void DeleteUser(User user)
        {
            UserStore.Users.Remove(user);
        }
        
    }
}
