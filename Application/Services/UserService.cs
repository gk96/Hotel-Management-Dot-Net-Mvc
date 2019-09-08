using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService
    {
        UnitOfWork uow = new UnitOfWork();

        public User UserCheck(string email,string password)
        {
            return uow.UserRepository.dbSet.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return uow.UserRepository.GetAll();
        }
        public User GetUserByID(int? id)
        {
            return uow.UserRepository.GetByID(id);
        }
        public void InsertUser(User user)
        {
            uow.UserRepository.Insert(user);
            uow.Save();
        }
        public void DeleteUser(User user)
        {
            uow.UserRepository.Delete(user);
            uow.Save();
        }
        public void UpdateUser(User user)
        {
            uow.UserRepository.Update(user);
            uow.Save();

        }
        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
