using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// el objetivo con los dto es permitirme visualizar los departamentos que estan relacionados con el pais por ejemplo
namespace API.Controllers.Dtos
{
    public class PaisDto
    {
        public int Id { get; set; }
        public string ? NombrePais { get; set; }
        public List<EstadoDto>? estados { get; set; }
    }
}