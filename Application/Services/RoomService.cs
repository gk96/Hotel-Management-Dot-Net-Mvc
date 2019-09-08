using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RoomService
    {
        UnitOfWork uow = new UnitOfWork();

        public virtual IEnumerable<User> ReturnUser()
        {
            return uow.UserRepository.dbSet.Where(g => g.IsAdmin == false).ToList();
        }

        public virtual IEnumerable<Room> GetRoomsByUserId(int id)
        {
            return uow.RoomRepository.dbSet.Where(g =>g.UserId==id).ToList();
        }

        public int GetPrice(int id)
        {
            return uow.RoomRepository.GetByID(id).Price;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return uow.RoomRepository.GetAll();
        }
        public Room GetRoomByID(int? id)
        {
            return uow.RoomRepository.GetByID(id);
        }
        public void InsertRoom(Room room)
        {
            uow.RoomRepository.Insert(room);
            uow.Save();
        }
        public void DeleteRoom(Room room)
        {
            uow.RoomRepository.Delete(room);
            uow.Save();
        }
        public void UpdateRoom(Room room)
        {
            uow.RoomRepository.Update(room);
            uow.Save();

        }
        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
