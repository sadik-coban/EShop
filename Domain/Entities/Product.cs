using Core.Enums;
using Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;
public class Product : AuditableEntity
{
    public Guid? BrandId {  get; set; }    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Brand? Brand { get; set; }
    public DominantDiscount DominantDiscount { get; set; } 
    public ProductSpecificDiscount? ProductSpecificDiscount { get; set; }
    public CatalogSpecificDiscount? CatalogSpecificDiscount { get; set; }
    public ICollection<ProductImage> ProductImages { get; set; } = new HashSet<ProductImage>();
    public ICollection<Catalog> Catalogs { get; set; } = new HashSet<Catalog>();
    public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    public ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new HashSet<ShoppingCartItem>();
    public ICollection<Favorite> Favorites { get; set; } = new HashSet<Favorite>();

}
