using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vacation.Models
{
    public class Tour
    {
        public Tour()
        {
            //Baskets = new List<Basket>();
        }
        public int Id { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public DateTime DateOfReturn { get; set; }
        public int TransportId { get; set; }
        public int CityId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public int CityOfDeparture { get; set; }
        
        public int? Price { get; set; }

        public virtual Transport Transport { get; set; }
        public virtual City City { get; set; }

        //public virtual ICollection<Basket> Baskets{ get; set; }
}
}
