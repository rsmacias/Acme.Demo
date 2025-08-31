using System.Linq.Expressions;

namespace Demo.Domain.Abstractions;

public interface IRepository<TEntity> where TEntity : class, IAggregateRoot
{
    //IQueryable<TEntity> GetAll(ISpecification<TEntity>? specification = null, FindOptions? findOptions = null);
    //TEntity? FindOne(Func<TEntity, bool> predicate, ISpecification<TEntity>? specification = null, FindOptions? findOptions = null);
    //Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> predicate, ISpecification<TEntity>? specification = null, FindOptions? findOptions = null, CancellationToken cancellationToken = default);
    //IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, ISpecification<TEntity>? specification = null, FindOptions? findOptions = null);
    void Add(TEntity entity);
    void AddMany(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    bool Any(Expression<Func<TEntity, bool>> predicate);
}
