using System.Linq.Expressions;
using TestAPI.Models.Interfaces;

namespace TestAPI.Data.Interfaces;

public interface IRepository<TEntity> where TEntity : IBaseModel
{
    TEntity GetById(int id);

    IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] properties);

    void Add(TEntity entity);

    public void Update(TEntity entity);

    void Delete(TEntity entity);

    int SaveChanges();
}
