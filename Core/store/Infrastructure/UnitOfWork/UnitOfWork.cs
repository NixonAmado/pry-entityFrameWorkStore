using Core.Interfaces;
using Infrastructure.Repository;
using Infrastructure.Data;

namespace Infrastructure.UnitWork;
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly StoreContext context;
        private RepoPais _paises;
        private RepoEstado _estados;
        //private readonly EstadoRepository _estados;
        //private readonly RegionRepository _regiones;

        public  UnitOfWork(StoreContext _context)
        {
            context = _context;
        }
        public IPais Paises
        {
            get{
               if(_paises == null ){
                    _paises = new RepoPais(context);
                }
                return _paises;
            }
        }

        public IEstado Estados
        {
            get{
               if(_estados == null ){
                    _estados = new RepoEstado(context);
                }
                return _estados;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
        
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }

