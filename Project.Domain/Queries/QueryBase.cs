using MediatR;

namespace Project.Domain.Queries
{
    public abstract class QueryBase<TResult> : IRequest<TResult> where TResult : class
    {
        
    }
}