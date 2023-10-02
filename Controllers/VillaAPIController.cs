﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _db;
        public VillaAPIController(ILogging loggerc, ApplicationDbContext db)
        {
            _loggerc = loggerc;
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<IEnumerable<VillaDTO>> GetVillas()
		{
            _loggerc.Log("Retriving all villa", "not an error");
			return Ok(_db.Villas.ToList());
		}


        [HttpGet("{id:int}" , Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTO>> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = await _db.Villas.FirstOrDefaultAsync(u => u.id == id);
            if(villa == null)
            {
                return NotFound();
            }

            return Ok(await _db.Villas.FirstOrDefaultAsync(u=>u.id==id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<VillaDTO>> CreateVilla(VillaCreateDTO villadto)
        {
            if(villadto == null)
            {
                return BadRequest();
            }
            // if(villadto.id > 0)
            // {
            //     return StatusCode(StatusCodes.Status500InternalServerError);
            // }

            // villadto.id = VillaStore.VillaList.OrderByDescending(u => u.id).FirstOrDefault().id + 1;

            Villa model = new()
            {
                name = villadto.name,
                Sqft = villadto.Sqft,
                Occupancy = villadto.Occupancy
            };
            await _db.Villas.AddAsync(model);
            await _db.SaveChangesAsync();
            // VillaStore.VillaList.Add(villadto);
            return CreatedAtRoute("GetVilla" ,new {id = model.id},model);
        }

        [HttpDelete ("{id:int}", Name = "Deletevilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var villa = await _db.Villas.FirstOrDefaultAsync(u => u.id == id);
            if(villa == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            _db.Villas.Remove(villa);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "Updatevilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateVilla(int id, [FromBody]VillaUpdateDTO villadto)
        {
            if (id != villadto.id || villadto == null)
            {
                return BadRequest();
            }
            var villa =await _db.Villas.FirstOrDefaultAsync(u => u.id == id);
            // villa.name = villadto.name;
            Villa model = new()
            {
                name = villadto.name,
                Sqft = villadto.Sqft,
                Occupancy = villadto.Occupancy
            };
            _db.Villas.Update(model);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "Patchvilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchdto)
        {
            if (id == 0 || patchdto == null)
            {
                return BadRequest();
            }
            var villa = await _db.Villas.AsNoTracking().FirstOrDefaultAsync(u => u.id == id);
            VillaUpdateDTO modelDTO = new()
            {
                name = villa.name,
                Sqft = villa.Sqft,
                Occupancy = villa.Occupancy
            };
            patchdto.ApplyTo(modelDTO, ModelState);
            Villa model = new()
            {
                name = modelDTO.name,
                Sqft = modelDTO.Sqft,
                Occupancy = modelDTO.Occupancy
            };
            await _db.Villas.AddAsync(model);
            await _db.SaveChangesAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}

