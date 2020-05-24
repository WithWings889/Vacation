using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vacation.Models
{
    public partial class Basket
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public int? HotelId { get; set; }
        [ForeignKey("NutritionTypeInHotel")]
        public int? NutritionTypeInHotelId { get; set; }
        [ForeignKey("RoomTypeInHotel")]
        public int? RoomTypeInHotelId { get; set; }

        public virtual Tour Tour { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual NutritionType NutritionTypeInHotel { get; set; }
        public virtual RoomType RoomTypeInHotel { get; set; }
}


}
