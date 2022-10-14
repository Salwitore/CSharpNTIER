using Data;
using DataAccsess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{    
    //DataAccess'den dataya erişip istenilen işi yaptığım katman.
    public class UserBusiness
    {

        //UserBusiness
        public void AddUser(User user)
        {
            new UserDataAccess().AddUser(user);
        }


        public User DeleteUser(int UserId)
        {
            var user = new UserDataAccess().GetUsers().Where(user => user.UserId ==UserId).First();
            new UserDataAccess().DeleteUser(user);
            return user;
        }


        public IEnumerable<User> GetUsers()
        {
            return new UserDataAccess().GetUsers();
        }

        
        public User GetUser(int UserId)
        {
            return new UserDataAccess().GetUsers().Where(user => user.UserId ==UserId).First();
        }


        public IEnumerable<User> GetYoungUsers()
        {
            return new UserDataAccess().GetUsers().Where(user => user.Yas<18).ToList();
        }


        public IEnumerable<User> GetAdultUsers()
        {
            return new UserDataAccess().GetUsers().Where(user => user.Yas >= 18).ToList();
        }


        public IEnumerable<User> AddWordUsersName(string word)
        {
            var users = new UserDataAccess().GetUsers();
            foreach (var item in users)
            {
                item.Isim += word;
            }
            return users;
        }


        //DepartmentBusiness
        public void AddDepartment(Department department)
        {
            new UserDataAccess().AddDepartment(department);
        }


        public Department DeleteDepartment(int departmentId)
        {
            var department = new UserDataAccess().GetDepartments().Where(department => department.DepartmentId == departmentId).First();
            new UserDataAccess().DeleteDepartment(department);
            return department;
        }


        public IEnumerable<Department> GetDepartments()
        {
            return new UserDataAccess().GetDepartments().ToList();
        }


        public Department GetDepartment(int departmentId)
        {
            return new UserDataAccess().GetDepartments().Where(department => department.DepartmentId == departmentId).First();
        }


        public IEnumerable<Department> GetDepartmentsOnSameFloor(int FloorNum)
        {
            return new UserDataAccess().GetDepartments().Where(department => department.Floor == FloorNum).ToList();
        }


        public IEnumerable<User> GetUsersInSameDepartment(int DepartmentId)
        {
            return new UserDataAccess().GetUsers().Where(user => user.DepartmentId == DepartmentId).ToList();
        }

    }
}
