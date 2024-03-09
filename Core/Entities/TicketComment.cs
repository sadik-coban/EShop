using Core.Infrastructure.Base.EntitiesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;
public class TicketComment : AuditableEntity
{
    public Guid TicketId { get; set; }  
    public string Body { get; set; } = string.Empty;
    public Ticket Ticket { get; set; } = null!;
}
