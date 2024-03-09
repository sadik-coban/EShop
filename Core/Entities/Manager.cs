using Core.Infrastructure.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;
public class Manager : ApplicationUser
{
    public ICollection<Brand> Brands { get; set; } = new HashSet<Brand>();
    public ICollection<CarouselImage> CarouselImages { get; set; } = new HashSet<CarouselImage>();
    public ICollection<Catalog> Catalogs { get; set; } = new HashSet<Catalog>();
    public ICollection<CatalogSpecificDiscount> CatalogSpecificDiscounts { get; set; } = new HashSet<CatalogSpecificDiscount>();
    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    public ICollection<ProductSpecificDiscount> ProductSpecificDiscounts { get; set; } = new HashSet<ProductSpecificDiscount>();
    public ICollection<Stock> Stocks { get; set; } = new HashSet<Stock>();
    public ICollection<TicketComment> TicketComments { get; set; } = new HashSet<TicketComment>();
}
