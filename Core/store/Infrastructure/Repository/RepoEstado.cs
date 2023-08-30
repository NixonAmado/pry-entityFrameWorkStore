
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Infrastructure.Repository
{
    // 
    public class RepoEstado : GenericRepository<Estado>, IEstado
    {
        private readonly StoreContext _context;

        public RepoEstado(StoreContext context) : base(context)
        {
            _context = context;
        }

        //se necesita modificar unas cosas sobre la estructura o cuerpo //metodo como virtual para poder override
        public override async Task<IEnumerable<Estado>> GetAllAsync()
        {
            return await _context.Estados
                //para que tenga en cuenta la relacion 
                .Include(p => p.Regiones)
                //retorna una coleccion de todos los elementos que se encontraron en la tabla
                .ToListAsync();
        }

        public override async Task<Estado> GetByIdAsync(int id)
        {
            return await _context.Estados
                .Include(p => p.Regiones)
                //Encuentra el primer elemento
                .FirstOrDefaultAsync( p => p.Id == id);
        }
    }
}