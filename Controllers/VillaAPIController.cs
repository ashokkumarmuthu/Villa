using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Villa_Api.Data;
using Villa_Api.Model;
using Villa_Api.Model.DTO;
using Villa_Api.Logging;
using Villa_Api.Repository.IRepository;
using Villa_Api.Services.IServices;

namespace Villa_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
	{
        private readonly ILogging _loggerc;
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;
        public VillaAPIController(ILogging loggerc, IVillaRepository dbVilla, IMapper mapper, IVillaService villaService)
        {
            _loggerc = loggerc;
            _mapper = mapper;
            _villaService = villaService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
		{
            _loggerc.Log("Getting all villa", "not an error");
            IEnumerable<Villa> villaList = await _villaService.GetAll();
			return Ok(_mapper.Map<List<VillaDTO>>(villaList));
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

            var villa = await _villaService.Get(u => u.id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<VillaDTO>(villa));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<VillaDTO>> CreateVilla(VillaCreateDTO createDto)
        {
            if(createDto == null)
            {
                return BadRequest();
            }
            var model = _mapper.Map<Villa>(createDto);
            
            await _villaService.Create(model);
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
            var villa = await _villaService.Get(u => u.id == id);
            if(villa == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            await _villaService.Remove(villa);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "Updatevilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateVilla(int id, [FromBody]VillaUpdateDTO updateDto)
        {
            if (id != updateDto.id || updateDto == null)
            {
                return BadRequest();
            }
            Villa model = _mapper.Map<Villa>(updateDto);
            
            await _villaService.Update(model);
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
            var villa = await _villaService.Get(u => u.id == id,false);

            var modelDTO = _mapper.Map<VillaUpdateDTO>(villa); 
            patchdto.ApplyTo(modelDTO, ModelState);

            var model = _mapper.Map<Villa>(modelDTO);
            
            await _villaService.Create(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}

