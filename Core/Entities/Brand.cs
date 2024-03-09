using Core.Infrastructure.Base.EntitiesBase;
using Core.Infrastructure.Base.EntitiesBase.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;
public class Brand : AuditableEntity, ISoftDeleteableEntity
{
    public string Name { get; set; } = string.Empty;
    public bool IsSoftDeleted { get; set; }
}
