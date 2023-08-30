
using API.Controllers.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.UnitWork;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
    public class EstadoController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;

    public IMapper Mapper { get; set; }
    
        public EstadoController(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            this.Mapper = mapper;
            this.unitOfWork = unitOfOfWork;
        }

        //ENDPOINT
        [HttpGet]
        //[MapToApiVersion(1.1)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //Va a obtener todos los Estado de la bd
        public async Task<ActionResult<IEnumerable<EstadoDto>>> Get()
        {
            var Estado = await unitOfWork.Estados.GetAllAsync();
            return Mapper.Map<List<EstadoDto>>(Estado);
        }
        
        //sobrecarga de funciones// sus argumentos tienen que ser diferentes 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var Estado = await unitOfWork.Estados.GetByIdAsync(id);
            return Ok(Estado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Estado>> Post(EstadoDto EstadoDto)
        {
            var Estado = Mapper.Map<Estado>(EstadoDto);
            this.unitOfWork.Estados.Add(Estado);
            await unitOfWork.SaveAsync();
            if(Estado == null)
            {
                return BadRequest();
            }
            EstadoDto.IdEstado = Estado.Id;
            return CreatedAtAction(nameof(Post), new { id = EstadoDto.IdEstado }, EstadoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoDto>> Put(int id, EstadoDto EstadoDto)
        {
            if(EstadoDto == null)
                return NotFound();
            var Estado = this.Mapper.Map<Estado>(EstadoDto);
            unitOfWork.Estados.Update(Estado);
            await unitOfWork.SaveAsync();
            return EstadoDto;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id) {
            var Estado = await unitOfWork.Estados.GetByIdAsync(id);
            if(Estado == null)
            {
                return NotFound();
            }
        unitOfWork.Estados.Remove(Estado);
        await unitOfWork.SaveAsync();
        return NoContent();
        }        
    }
