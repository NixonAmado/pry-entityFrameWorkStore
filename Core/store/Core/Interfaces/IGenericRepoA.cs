using Core.Entities;
using System.Linq.Expressions;
namespace Core.Interfaces;
//definicion
    public interface IGenericRepoA<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        //busquedas booleanas
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        //agregar elementos
        void Add(T entity);
        //agregar un conjunto elementos
        void AddRange(IEnumerable<T> entities);
        //eliminar un registro
        void Remove(T entity);
        //eliminar registros
        void RemoveRange(IEnumerable<T> entities);
        //actualizar un  registro
        void Update(T entity);
    }
