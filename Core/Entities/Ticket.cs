using Core.Infrastructure.Base.EntitiesBase;
using Core.Infrastructure.Base.EntitiesBase.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;
public class Ticket : Entity, IAuditableEntity
{
    public Guid CustomerId { get; set; }
    public Guid OrderId { get; set; }
    public Guid? ProductId { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    public Product? Product { get; set; }
    public Customer Customer { get; set; } = null!;
    public Order Order { get; set; } = null!;
    public ICollection<TicketImage> TicketImages = new HashSet<TicketImage>();
    public ICollection<TicketComment> TicketComments = new HashSet<TicketComment>();
}

