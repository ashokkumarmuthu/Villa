using System;
using Microsoft.AspNetCore.Mvc;
using Villa_Api.Data;
using Villa_Api.Model;
using Villa_Api.Model.DTO;

namespace Villa_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
	{
        [HttpGet]
		public IEnumerable<VillaDTO> GetVillas()
		{
			return VillaStore.VillaList;
		}
        [HttpGet("{id:int}")]
        public VillaDTO GetVilla(int id)
        {
            return VillaStore.VillaList.FirstOrDefault(u=>u.id==id);
        }
    }
}

