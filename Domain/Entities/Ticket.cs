using Core.Infrastructure.Base;
using Core.Infrastructure.Base.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;
public class Ticket : Entity, IAuditableEntity
{
    public Guid CustomerId { get; set; }
    public Guid ProductId { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public Customer Customer { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public ICollection<TicketImage> TicketImages = new HashSet<TicketImage>();
    public ICollection<TicketComment> TicketComments = new HashSet<TicketComment>();
}

