using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RecordContext : DbContext
    {
        public RecordContext() : base("name=con")
        {

        }
        public DbSet<User> UserList { get; set; }
        public DbSet<Room> RoomList { get; set; }
    }
}
