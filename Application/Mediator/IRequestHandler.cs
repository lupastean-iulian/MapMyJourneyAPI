namespace MapMyJourneyAPI.Application.Mediator;

public interface IRequestHandler<TRequest, TResponse>
{
    Task<TResponse> Handle(TRequest request);
}
