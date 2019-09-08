using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class UnitOfWork : IDisposable
    {
        private RecordContext context = new RecordContext();
        private GenericRepository<User> userRepository;
        private GenericRepository<Room> roomRepository;

        public GenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        public GenericRepository<Room> RoomRepository
        {
            get
            {

                if (this.roomRepository == null)
                {
                    this.roomRepository = new GenericRepository<Room>(context);
                }
                return roomRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
