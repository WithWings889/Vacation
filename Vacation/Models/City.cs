using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vacation.Models
{
    public partial class City
    {
        public City()
        {
            Hotels = new List<Hotel>();
            Tours = new List<Tour>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string info { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
