using Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;
public class TicketImage : Entity
{
    public string Image { get; set; } = string.Empty;
}
