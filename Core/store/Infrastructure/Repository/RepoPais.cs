
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Infrastructure.Repository
{
    // 
    public class RepoPais : GenericRepository<Pais>, IPais
    {
        private readonly StoreContext _context;

        public RepoPais(StoreContext context) : base(context)
        {
            _context = context;
        }

        //se necesita modificar unas cosas sobre la estructura o cuerpo //metodo como virtual para poder override
        public override async Task<IEnumerable<Pais>> GetAllAsync()
        {
            return await _context.Paises
                //para que tenga en cuenta la relacion 
                .Include(p => p.Estados)
                //retorna una coleccion de todos los elementos que se encontraron el la tabla
                .ToListAsync();
        }

        public override async Task<Pais> GetByIdAsync(int id)
        {
            return await _context.Paises
                .Include(p => p.Estados)
                //Encuentra el primer elemento
                .FirstOrDefaultAsync( p => p.Id == id);
        }
    }
}