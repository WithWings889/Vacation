using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacation.Models
{
    public class NutritionTypeInHotel
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int HotelId { get; set; }
        public int NutritionTypeId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual NutritionType NutritionType{ get; set; }
}
}
