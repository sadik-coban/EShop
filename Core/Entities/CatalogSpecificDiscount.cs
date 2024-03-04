using Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;
public class CatalogSpecificDiscount : AuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public int Rate { get; set; }
    public DateTime? DateFirst { get; set; }
    public DateTime? DateEnd { get; set; }
    public ICollection<Catalog>? Catalogs { get; set; } = new HashSet<Catalog>();
}
