namespace MapMyJourneyAPI.Application.Mediator;

public interface INotificationHandler<TNotification>
{
    Task Handle(TNotification notification);
}
