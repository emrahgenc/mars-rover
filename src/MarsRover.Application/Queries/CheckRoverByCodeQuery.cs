using MediatR;

namespace MarsRover.Application.Queries
{
    public class CheckRoverByCodeQuery : IRequest<bool>
    {
        public string Code { get; protected set; }

        public CheckRoverByCodeQuery(string code)
        {
            Code = code;
        }
    }
}