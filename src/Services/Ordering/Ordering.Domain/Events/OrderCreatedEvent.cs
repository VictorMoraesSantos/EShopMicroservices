using Ordering.Domain.Abstractions;
using Ordering.Domain.Models;

namespace Ordering.Domain.Events
{
    public record class OrderCreatedEvent(Order order) : IDomainEvent;
}
