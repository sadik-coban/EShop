using Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;
public class ProductImage : Entity
{
    public Guid ProductId { get; set; }
    public bool IsShowcasePhoto { get; set; }   
    public string Image { get; set; } = string.Empty;
    public Product? Product { get; set; }
}
