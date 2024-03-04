using Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;
public class CommentImage : AuditableEntity
{
    public Guid ProductId { get; set; }
    public string Image { get; set; } = string.Empty;
    public Product Product { get; set; } = null!;
}
