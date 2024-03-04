using Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;
public class Catalog : AuditableEntity
{
    public string Name { get; set; } = string.Empty;  
    public ICollection<Product> Products = new HashSet<Product>();
}
