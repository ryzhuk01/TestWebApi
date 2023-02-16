using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestAPI.Data.Interfaces;
using TestAPI.Models.Interfaces;

namespace TestAPI.Data;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseModel
{
    public Repository(TestAPIDbContext databaseContext)
    {
        DbContext = databaseContext;
        Entities = DbContext.Set<TEntity>();
    }

    protected DbSet<TEntity> Entities { get; }

    protected DbContext DbContext { get; }

    public TEntity GetById(int id)
    {
        return Entities.Where(x => x.Id == id).FirstOrDefault();
    }

    public IQueryable<TEntity> GetAll()
    {
        return Entities;
    }


    public virtual IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] properties)
    {
        if (properties == null)
            throw new ArgumentNullException(nameof(properties));

        var query = Entities as IQueryable<TEntity>;

        query = properties
                   .Aggregate(query, (current, property) => current.Include(property));

        return query.AsNoTracking().ToList();
    }



    public void Add(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        Entities.Add(entity);
    }

    public void Update(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        Entities.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        Entities.Remove(entity);
    }

    public int SaveChanges()
    {
        return DbContext.SaveChanges();
    }   
}
