namespace Core.Interfaces;
using Microsoft.EntityFrameworkCore;
    public interface IUnitOfWork
    {
        IPais Paises { get;}
        IEstado Estados { get;}
        //ITipoPersona TipoPersonas { get; set;}
        //IRegion Regiones { get; set; }
        Task<int> SaveAsync();
    }
