using System;
using System.ComponentModel.DataAnnotations;

namespace Villa_Api.Model.DTO
{
	public class VillaNumberUpdateDTO
	{
		[Required]
		public int VillaNo { get; set; }
		public string SpecialDetails { get; set; }
    }
}

