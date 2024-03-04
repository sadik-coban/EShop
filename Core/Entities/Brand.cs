using Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;
public class Brand : AuditableEntity
{
    public string Name { get; set; } = string.Empty;
}
