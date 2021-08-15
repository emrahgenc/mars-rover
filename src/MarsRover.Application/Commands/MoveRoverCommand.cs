using MediatR;
using System;

namespace MarsRover.Application.Commands
{
    public class MoveRoverCommand : IRequest
    {
        public Guid RoverId { get; protected set; }

        public MoveRoverCommand(Guid roverId)
        {
            RoverId = roverId;
        }
    }
}
