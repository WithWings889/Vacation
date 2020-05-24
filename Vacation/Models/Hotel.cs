using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vacation.Models
{
    public class Hotel
    {
        public Hotel()
        {
            RoomTypeInHotels = new List<RoomTypeInHotel>();
            NutritionTypeInHotels = new List<NutritionTypeInHotel>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }
        [Range(1, 5)]
        public int Category { get; set; }
        public string info { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<RoomTypeInHotel> RoomTypeInHotels { get; set; }
        public virtual ICollection<NutritionTypeInHotel> NutritionTypeInHotels { get; set; }
    }
}
