using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacation.Models
{
    public class RoomTypeInHotel
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}
