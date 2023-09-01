
using API.Controllers.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.UnitWork;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
    public class PaisController : BaseApiController
    {

        private readonly IUnitOfWork unitOfWork;

    public IMapper Mapper { get; set; }
    
        public PaisController(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            this.Mapper = mapper;
            this.unitOfWork = unitOfOfWork;
        }

        //ENDPOINT
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //Va a obtener todos los paises de la bd
        public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
        {
            var paises = await unitOfWork.Paises.GetAllAsync();
            return Mapper.Map<List<PaisDto>>(paises);
        }
        
        //sobrecarga de funciones// sus argumentos tienen que ser diferentes 
        [MapToApiVersion("1.1")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var pais = await unitOfWork.Paises.GetByIdAsync(id);
            return Ok(pais);
        }

        [HttpPost]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Pais>> Post(PaisDto paisDto)
        {
            var pais = Mapper.Map<Pais>(paisDto);
            this.unitOfWork.Paises.Add(pais);
            await unitOfWork.SaveAsync();
            if(pais == null)
            {
                return BadRequest();
            }
            paisDto.Id = pais.Id;
            return CreatedAtAction(nameof(Post), new { id = paisDto.Id }, paisDto);
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaisDto>> Put(int id, PaisDto paisDto)
        {
            if(paisDto == null)
                return NotFound();
            var pais = this.Mapper.Map<Pais>(paisDto);
            unitOfWork.Paises.Update(pais);
            await unitOfWork.SaveAsync();
            return paisDto;
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id) {
            var pais = await unitOfWork.Paises.GetByIdAsync(id);
            if(pais == null)
            {
                return NotFound();
            }
        unitOfWork.Paises.Remove(pais);
        await unitOfWork.SaveAsync();
        return NoContent();
        }        
    }
