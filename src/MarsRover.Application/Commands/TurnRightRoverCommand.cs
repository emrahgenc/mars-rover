using MediatR;
using System;

namespace MarsRover.Application.Commands
{
    public class TurnRightRoverCommand : IRequest
    {
        public Guid RoverId { get; protected set; }

        public TurnRightRoverCommand(Guid roverId)
        {
            RoverId = roverId;
        }
    }
}