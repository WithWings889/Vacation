using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vacation.Models
{
    public class RoomType
    {
        public RoomType()
        {
            RoomTypeInHotels = new List<RoomTypeInHotel>();
            //Baskets = new List<Basket>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }
        [Range(1, 5)]
        public int MaxNumberOfPeople { get; set; }
        public string info { get; set; }

        public virtual ICollection<RoomTypeInHotel> RoomTypeInHotels { get; set; }
        //public virtual ICollection<Basket> Baskets { get; set; }
    }
}
