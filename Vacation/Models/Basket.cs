using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacation.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public int HotelId { get; set; }
        public int NutritionTypeId { get; set; }
        public int RoomTypeId { get; set; }

        public virtual Tour Tour { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual NutritionType NutritionType { get; set; }
        public virtual RoomType RoomType { get; set; }
}


}
