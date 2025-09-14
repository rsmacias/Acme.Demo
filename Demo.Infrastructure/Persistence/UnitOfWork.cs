using Demo.Domain.Abstractions;

namespace Demo.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    protected readonly DemoContext _context;

    public UnitOfWork(DemoContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
