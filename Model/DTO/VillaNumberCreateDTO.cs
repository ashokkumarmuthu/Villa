using System;
using System.ComponentModel.DataAnnotations;

namespace Villa_Api.Model.DTO
{
	public class VillaNumberCreateDTO
	{
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}

