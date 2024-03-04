using Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;
public class ShoppingCartItem : Entity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
