using Core.Infrastructure.Authentication;
using Core.Infrastructure.Base.EntitiesBase;
using Core.Infrastructure.Base.EntitiesBase.Abstract;

namespace Core.Entities;
public class Stock : Entity, ICreatedByUser
{
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public int StockCount { get; set; }

    public Product Product { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;
}

