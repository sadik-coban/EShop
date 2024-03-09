using Core.Enums;
using Core.Infrastructure.Base.EntitiesBase;
using Core.Infrastructure.Base.EntitiesBase.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;
public class Product : AuditableEntity, ISoftDeleteableEntity
{
    public Guid StockId { get; set; }
    public Guid? BrandId { get; set; }
    public Guid? ProductSpecificDiscountId { get; set; }
    public Guid? CatalogSpecificDiscountId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool IsSoftDeleted { get; set; }
    public DominantDiscount DominantDiscount { get; set; }
    public DominantType DominantType { get; set; }

    public Stock Stock { get; set; } = null!;
    public Brand? Brand { get; set; }
    public ProductSpecificDiscount? ProductSpecificDiscount { get; set; }
    public ICollection<ProductImage> ProductImages { get; set; } = new HashSet<ProductImage>();
    public ICollection<Catalog> Catalogs { get; set; } = new HashSet<Catalog>();
    public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    public ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new HashSet<ShoppingCartItem>();
    public ICollection<Favorite> Favorites { get; set; } = new HashSet<Favorite>();

    [NotMapped]
    public decimal DiscountedPrice { get; set; }
}
