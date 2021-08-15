using MediatR;
using System;

namespace MarsRover.Application.Queries
{
    public class CheckPlateauByCodeQuery : IRequest<bool>
    {
        public string Code { get; protected set; }

        public CheckPlateauByCodeQuery(string code)
        {
            Code = code;
        }
    }
    public class CheckPlateauByIdQuery : IRequest<bool>
    {
        public Guid Id { get; protected set; }

        public CheckPlateauByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}