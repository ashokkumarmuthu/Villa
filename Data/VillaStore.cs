using System;
using Villa_Api.Model.DTO;

namespace Villa_Api.Data
{
	public static class VillaStore
	{
        public static List<VillaDTO> VillaList = new List<VillaDTO> {
			new VillaDTO{ id = 1, name = "ashok" },
			new VillaDTO{ id = 2, name = "kumar" }
		};
	}
}

