using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Villa_Api.Data;
using Villa_Api.Model;
using Villa_Api.Model.DTO;
using Villa_Api.Logging;

namespace Villa_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
	{
        private readonly ILogging _loggerc;
        public VillaAPIController(ILogging loggerc)
        {
            _loggerc = loggerc;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<IEnumerable<VillaDTO>> GetVillas()
		{
            _loggerc.Log("Retriving all villa", "not an error");
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

        [HttpDelete ("{id:int}", Name = "Deletevilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.VillaList.FirstOrDefault(u => u.id == id);
            if(villa == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            VillaStore.VillaList.Remove(villa);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "Updatevilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult UpdateVilla(int id, [FromBody]VillaDTO villadto)
        {
            if (id != villadto.id || villadto == null)
            {
                return BadRequest();
            }
            var villa = VillaStore.VillaList.FirstOrDefault(u => u.id == id);
            villa.name = villadto.name;

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "Patchvilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult UpdateVilla(int id, JsonPatchDocument<VillaDTO> patchdto)
        {
            if (id == 0 || patchdto == null)
            {
                return BadRequest();
            }
            var villa = VillaStore.VillaList.FirstOrDefault(u => u.id == id);
            patchdto.ApplyTo(villa, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}

