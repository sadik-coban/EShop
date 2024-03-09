using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using X.PagedList;

namespace Core.Infrastructure.Base.RepositoriesBase;
public class RepositoryBase<TEntity>(ApplicationDbContext context) : IRepositoryBase<TEntity> where TEntity : class
{
    protected IQueryable<TEntity> Query => context.Set<TEntity>().AsNoTracking();

    protected IQueryable<TEntity> Command => context.Set<TEntity>();


    public async Task<int> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(entity, cancellationToken);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        context.Update(entity);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<int> ExecuteUpdateAsync(Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls, CancellationToken cancellationToken = default)
    {
        var result = await Command.ExecuteUpdateAsync(setPropertyCalls, cancellationToken);
        return result;
    }

    public async Task<int> ExecuteDeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var result = await Command.Where(predicate).ExecuteDeleteAsync(cancellationToken);
        return result;
    }


    public async Task<IPagedList<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string[]? includedProperties = null,
        int pageNumber = 1,
        int pageSize = 10,
        bool withDeleted = false)
    {
        var query = Query;
        GetListBase(predicate, includedProperties, withDeleted, orderBy, query);
        return await query.ToPagedListAsync(pageNumber, pageSize);
    }

    public async Task<IPagedList<TResult>> GetListAsync<TResult>(
        Func<IQueryable<TEntity>, IQueryable<TResult>> select,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string[]? includedProperties = null,
        int pageNumber = 1,
        int pageSize = 10,
        bool withDeleted = false)
    {
        var query = Query;
        GetListBase(predicate, includedProperties, withDeleted, orderBy, query);
        return await select(query).ToPagedListAsync(pageNumber, pageSize);
    }


    public async Task<IPagedList<TResult>> GetListAsync<TResult>(
        Func<TEntity, TResult> selector,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string[]? includedProperties = null,
        int pageNumber = 1,
        int pageSize = 10,
        bool withDeleted = false)
    {
        var query = Query;
        GetListBase(predicate, includedProperties, withDeleted, orderBy, query);
        return await query.Select(selector).ToPagedListAsync(pageNumber, pageSize);
    }

    public async Task<TEntity> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        string[]? includedProperties = null,
        bool withDeleted = false,
        CancellationToken cancellationToken = default)
    {
        var query = Query;
        GetBase(includedProperties, withDeleted, query);
        TEntity result = await query.FirstOrDefaultAsync(predicate, cancellationToken) ?? throw new ArgumentNullException(nameof(result), $"The {nameof(TEntity).ToLower()} does not exists");
        return result;
    }


    public async Task<TResult> GetAsync<TResult>(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IQueryable<TResult>> select,
        string[]? includedProperties = null,
        bool withDeleted = false,
        CancellationToken cancellationToken = default)
    {
        var query = Query;
        GetBase(includedProperties, withDeleted, query);
        query = query.Where(predicate);
        TResult result = await select(query).FirstOrDefaultAsync(cancellationToken) ?? throw new ArgumentNullException(nameof(result), $"The {nameof(TEntity).ToLower()} does not exists");
        return result;
    }

    public async Task<TResult> GetAsync<TResult>(
        Expression<Func<TEntity, bool>> predicate,
        Func<TEntity, TResult> selector,
        string[]? includedProperties = null,
        bool withDeleted = false,
        CancellationToken cancellationToken = default)
    {
        var query = Query;
        GetBase(includedProperties, withDeleted, query);
        query = query.Where(predicate);
        TResult result = await ((IQueryable<TResult>)query.Select(selector)).FirstOrDefaultAsync() ?? throw new ArgumentNullException(nameof(result), $"The {nameof(TEntity).ToLower()} does not exists");
        return result;
    }

    private void GetBase(string[]? includedProperties, bool withDeleted, IQueryable<TEntity> query)
    {
        if (includedProperties != null)
        {
            foreach (var includedProperty in includedProperties)
            {
                query = query.Include(includedProperty);
            }
        }
        if (withDeleted)
        {
            query = query.IgnoreQueryFilters();
        }
    }
    private void GetListBase(Expression<Func<TEntity, bool>>? predicate, string[]? includedProperties, bool withDeleted, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy, IQueryable<TEntity> query)
    {
        if (includedProperties != null)
        {
            foreach (var includedProperty in includedProperties)
            {
                query = query.Include(includedProperty);
            }
        }
        if (withDeleted)
        {
            query = query.IgnoreQueryFilters();
        }
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        if (orderBy != null)
        {
            query = orderBy(query);
        }
    }
}

