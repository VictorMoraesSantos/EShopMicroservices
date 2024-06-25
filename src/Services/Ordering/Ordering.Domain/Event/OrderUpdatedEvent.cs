namespace Ordering.Domain.Event
{
    public record OrderUpdatedEvent(Order order) : IDomainEvent;
}
