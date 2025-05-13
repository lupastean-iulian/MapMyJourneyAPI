namespace MapMyJourneyAPI.Application.Mediator;

public interface IMediator
{
    Task<TResponse> Send<TRequest, TResponse>(TRequest request);
    Task Publish<TNotification>(TNotification notification);
}
