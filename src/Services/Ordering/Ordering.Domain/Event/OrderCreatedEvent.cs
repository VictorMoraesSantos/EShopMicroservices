namespace Ordering.Domain.Event
{
    public record OrderCreatedEvent(Order order) : IDomainEvent;
}
