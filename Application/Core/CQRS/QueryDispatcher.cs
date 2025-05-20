using Microsoft.Extensions.DependencyInjection;

namespace Application.Core.CQRS;

public class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
{
    public async Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery<TResult>
    {
        var handler = serviceProvider.GetService<IQueryHandler<TQuery, TResult>>();
        if (handler == null)
            throw new InvalidOperationException($"No query handler registered for {typeof(TQuery).Name}");        
        return await handler.HandleAsync(query, cancellationToken); 
    }
}
