using MediatR;
using System;

namespace MarsRover.Application.Commands
{
    public class TurnLeftRoverCommand : IRequest
    {
        public Guid RoverId { get; protected set; }

        public TurnLeftRoverCommand(Guid roverId)
        {
            RoverId = roverId;
        }
    }
}