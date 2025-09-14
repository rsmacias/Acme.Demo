using Demo.Domain.Abstractions;
using System.Linq.Expressions;

namespace Demo.Infrastructure.Persistence.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
{
    protected readonly DemoContext _context;

    protected Repository(DemoContext context)
    {
        _context = context;
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public void AddMany(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().AddRange(entities);
    }

    public bool Any(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.Set<TEntity>().Any(predicate);
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }
}
