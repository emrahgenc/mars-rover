using MediatR;
using System;

namespace MarsRover.Application.Commands
{
    public class CreatePlateauCommand : IRequest<Guid>
    {
        public string Code { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
