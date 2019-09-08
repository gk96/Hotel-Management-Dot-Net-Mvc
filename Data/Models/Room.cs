using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
   
        public class Room
        {
            [Key]
            public int Id { get; set; }
            
            public bool IsOccupied { get; set; }
            
            public int Price { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime? CheckInDate { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime? CheckOutDate { get; set; }
            public int? UserId { get; set; }

            [ForeignKey("UserId")]
            public virtual User User { get; set; }

        }
    
}
