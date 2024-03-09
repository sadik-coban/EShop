using Core.Infrastructure.Base.EntitiesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;
public class CatalogSpecificDiscount : AuditableEntity
{
    public Guid CatalogId { get; set; }    
    public string Name { get; set; } = string.Empty;
    public int Rate { get; set; }
    public DateTime? DateFirst { get; set; }
    public DateTime? DateEnd { get; set; }
    public Catalog Catalog { get; set; } = null!;
}
