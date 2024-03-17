using Core.Data.Repositories.Abstract;
using Core.Entities;
using Core.Exceptions;
using Core.Infrastructure.Base.EntitiesBase;
using Core.Infrastructure.Base.RepositoriesBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Data.Repositories;
public class CatalogsRepository(ApplicationDbContext context) : RepositoryBase<Catalog>(context), ICatalogsRepository
{
    private void CheckFilters(bool withDeleted = false, bool withDisabled = true)
    {
        if (withDeleted)
        {
            Query.IgnoreQueryFilters();
        }
        if (!withDisabled)
        {
            Query.Where(p => p.Enabled);
        }
    }

    public async Task<IEnumerable<Catalog>> GetListSearchAsync(string? keywords = null, bool withDeleted = false, bool withDisabled = true)
    {
        CheckFilters(withDeleted, withDisabled);
        if (keywords != null)
        {
            var searchKeywords = Regex.Split(keywords.ToLower(), @"\s+").ToList();
            Query.Where(p => searchKeywords.Any(q => p.Name.ToLower().Contains(q)));
        }

        return await Query.OrderByDescending(p => p.DateCreated).ToListAsync();
    }

}


// Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object?>>? include = null,