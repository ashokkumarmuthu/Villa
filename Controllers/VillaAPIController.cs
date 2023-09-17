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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<IEnumerable<VillaDTO>> GetVillas()
		{
			return Ok(VillaStore.VillaList);
		}


        [HttpGet("{id:int}" , Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = VillaStore.VillaList.FirstOrDefault(u => u.id == id);
            if(villa == null)
            {
                return NotFound();
            }

            return Ok(VillaStore.VillaList.FirstOrDefault(u=>u.id==id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<VillaDTO> CreateVilla(VillaDTO villadto)
        {
            if(villadto == null)
            {
                return BadRequest();
            }
            if(villadto.id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            villadto.id = VillaStore.VillaList.OrderByDescending(u => u.id).FirstOrDefault().id + 1;

            VillaStore.VillaList.Add(villadto);
            return CreatedAtRoute("GetVilla" ,new {id = villadto.id},villadto);
        }

    }
}

