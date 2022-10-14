
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess
{   
    //Data'ya erişim businessa returnlediğim kısım
    public class UserDataAccess
    {
        //UserDataAccess
        public IEnumerable<User> GetUsers()
        {
            return new UserContext().Users.ToList();
        }
        public IEnumerable<User> GetUsers(Expression<Func<User, bool>> exp)
        {
            return new UserContext().Users.Where(exp);
        }
        public void AddUser(User user)
        {   
            var usercontext = new UserContext();
            usercontext.Users.Add(user);
            usercontext.SaveChanges();

        }
        public void DeleteUser(User user)
        {
            var usercontext =new UserContext();
            usercontext.Users.Remove(user);
            usercontext.SaveChanges();
        }
        //DepartmentDataAccess
        public IEnumerable<Department> GetDepartments()
        {
            return new UserContext().Departments.ToList();
        }
        public void AddDepartment(Department department)
        {
            var usercontext = new UserContext();
            usercontext.Departments.Add(department);
            usercontext.SaveChanges();
        }
        public void DeleteDepartment(Department department)
        {
            var usercontext = new UserContext();
            usercontext.Departments.Remove(department);
            usercontext.SaveChanges();
        }
        
    }
}
