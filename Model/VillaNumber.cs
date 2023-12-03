using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Villa_Api.Model
{
	public class VillaNumber
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int VillaNo { get; set; }
		public string SpecialDetails { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
	}
}

