using Data;
using DataAccsess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{   
    //İstenilen işi yaptığım katman
    public class UserBusiness
    {


        public void AddUser(User user)
        {
            new UserDataAccess().AddUser(user);
        }
        public User DeleteUser(int Id)
        {
            var user = new UserDataAccess().GetUsers().Where(user => user.Id ==Id).First();
            new UserDataAccess().DeleteUser(user);
            return user;
        }

        public List<User> GetUsers()
        {
            return new UserDataAccess().GetUsers();
        }
        
        public User GetUser(int Id)
        {
            return new UserDataAccess().GetUsers().Where(user => user.Id ==Id).First();
        }
        
        public List<User> GetYoungUsers()
        {
            return new UserDataAccess().GetUsers().Where(user => user.Yas<18).ToList();
        }
        public List<User> GetAdultUsers()
        {
            return new UserDataAccess().GetUsers().Where(user => user.Yas >= 18).ToList();
        }
        
        public List<User> AddWordUsersName(string word)
        {
            var users = new UserDataAccess().GetUsers();
            foreach (var item in users)
            {
                item.Isim += word;
            }
            return users;
        }

        



    }
}
