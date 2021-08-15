using MediatR;
using System;

namespace MarsRover.Application.Commands
{
    public class CreateRoverCommand : IRequest<Guid>
    {
        public string Code { get; set; }
    }
}
