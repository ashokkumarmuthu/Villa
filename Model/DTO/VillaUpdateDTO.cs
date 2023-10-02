using System;
using System.ComponentModel.DataAnnotations;

namespace Villa_Api.Model.DTO
{
	public class VillaUpdateDTO
	{
		[Required]
        public int id { get; set; }
        [Required]
        [MaxLength(30)]
        public string name { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
    }
}

