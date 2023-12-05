// using AutoMapper;
// using Microsoft.AspNetCore.JsonPatch;
// using Microsoft.AspNetCore.Mvc;
// using Villa_Api.Logging;
// using Villa_Api.Model;
// using Villa_Api.Model.DTO;
// using Villa_Api.Repository.IRepository;
//
// namespace Villa_Api.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class VillaNumberAPIController : ControllerBase
//     {
//         private readonly ILogging _loggerc;
//         private readonly IVillaNumberRepository _dbVilla;
//         private readonly IMapper _mapper;
//         public VillaNumberAPIController(ILogging loggerc, IVillaNumberRepository dbVillaNumber, IMapper mapper)
//         {
//             _loggerc = loggerc;
//             _dbVilla = dbVillaNumber;
//             _mapper = mapper;
//         }
//          [HttpGet]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         [ProducesResponseType(StatusCodes.Status500InternalServerError)]
// 		public async Task<ActionResult<IEnumerable<VillaNumberDTO>>> GetVillaNumbers()
// 		{
//             _loggerc.Log("Getting all villa", "not an error");
//             IEnumerable<VillaNumber> villaList = await _dbVilla.GetAll();
// 			return Ok(_mapper.Map<List<VillaNumberDTO>>(villaList));
//         }
//
//
//         [HttpGet("{id:int}" , Name = "GetVillaNumber")]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         [ProducesResponseType(StatusCodes.Status404NotFound)]
//         public async Task<ActionResult<VillaNumberDTO>> GetVillaNumber(int id)
//         {
//             if (id == 0)
//             {
//                 return BadRequest();
//             }
//
//             var villaNumber = await _dbVilla.Get(u => u.VillaNo== id);
//             if (villaNumber == null)
//             {
//                 return NotFound();
//             }
//             return Ok(_mapper.Map<VillaNumberDTO>(villaNumber));
//         }
//
//         [HttpPost]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status201Created)]
//         [ProducesResponseType(StatusCodes.Status404NotFound)]
//         [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//
//         public async Task<ActionResult<VillaDTO>> CreateVillaNumber(VillaNumberCreateDTO createDto)
//         {
//             if(createDto == null)
//             {
//                 return BadRequest();
//             }
//             var model = _mapper.Map<VillaNumber>(createDto);
//             
//             await _dbVilla.Create(model);
//             return CreatedAtRoute("GetVillaNumber" ,new {id = model.VillaNo},model);
//         }
//
//         [HttpDelete ("{id:int}", Name = "DeleteVillaNumber")]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status204NoContent)]
//         [ProducesResponseType(StatusCodes.Status404NotFound)]
//
//         public async Task<IActionResult> DeleteVillaNumber(int id)
//         {
//             if(id == 0)
//             {
//                 return BadRequest();
//             }
//             var villaNumber = await _dbVilla.Get(u => u.VillaNo == id);
//             if(villaNumber == null)
//             {
//                 return StatusCode(StatusCodes.Status404NotFound);
//             }
//             await _dbVilla.Remove(villaNumber);
//             return NoContent();
//         }
//
//         [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status204NoContent)]
//         [ProducesResponseType(StatusCodes.Status404NotFound)]
//
//         public async Task<IActionResult> UpdateVillaNumber(int id, [FromBody]VillaNumberUpdateDTO updateDto)
//         {
//             if (id != updateDto.VillaNo || updateDto == null)
//             {
//                 return BadRequest();
//             }
//             VillaNumber model = _mapper.Map<VillaNumber>(updateDto);
//             
//             await _dbVilla.Update(model);
//             return NoContent();
//         }
//
//         [HttpPatch("{id:int}", Name = "PatchVillaNumber")]
//         [ProducesResponseType(StatusCodes.Status204NoContent)]
//         [ProducesResponseType(StatusCodes.Status404NotFound)]
//
//         public async Task<IActionResult> UpdateVilla(int id, JsonPatchDocument<VillaNumberUpdateDTO> patchdto)
//         {
//             if (id == 0 || patchdto == null)
//             {
//                 return BadRequest();
//             }
//             var villaNumber = await _dbVilla.Get(u => u.VillaNo == id,false);
//
//             var modelDTO = _mapper.Map<VillaNumberUpdateDTO>(villaNumber); 
//             patchdto.ApplyTo(modelDTO, ModelState);
//
//             var model = _mapper.Map<VillaNumber>(modelDTO);
//             
//             await _dbVilla.Create(model);
//
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }
//             return NoContent();
//         }
//     }
// }
//
