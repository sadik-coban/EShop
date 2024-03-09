using Core.Entities;
using Core.Infrastructure.Base.RepositoriesBase;
using System.Linq.Expressions;

namespace Core.Data.Repositories.Abstract;
public interface ICatalogsRepository : IRepositoryBase<Catalog>
{
    Task<IEnumerable<Catalog>> GetListSearchAsync(string? keywords = null, bool withDeleted = false, bool withDisabled = true);
}
