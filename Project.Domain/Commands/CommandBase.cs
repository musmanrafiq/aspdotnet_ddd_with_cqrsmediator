using MediatR;

namespace Project.Domain.Commands
{
    public class CommandBase<T> : IRequest<T> where T : class
    {
        
    }
}