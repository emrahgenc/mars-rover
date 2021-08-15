using AutoMapper;
using MarsRover.Application.Commands;
using MarsRover.Application.Queries;
using MarsRover.Core.Abstraction;
using MarsRover.Domain.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MarsRover.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoverController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RoverController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}/Position")]
        public async Task<PositionViewModel> GetPosition(Guid id)
        {
            var position = await _mediator.Send(new GetRoverPositionByIdQuery(id));
            return _mapper.Map<PositionViewModel>(position);
        }

        [HttpPost]
        [Route("")]
        public async Task<Guid> Insert(CreateRoverCommand createRoverCommand)
        {
            return await _mediator.Send(createRoverCommand);
        }

        [HttpPatch]
        [Route("{id}/Land")]
        public async Task Land(Guid id, LandToPlateauCommand landToPlateauCommand)
        {
            if (landToPlateauCommand.RoverId != id) ApplicationContext.ThrowBusinessException("Invalid request");

            await _mediator.Send(landToPlateauCommand);
        }

        [HttpPatch]
        [Route("{id}/Move")]
        public async Task Move(Guid id, MoveRoverCommand moveRoverCommand)
        {
            if (moveRoverCommand.RoverId != id) ApplicationContext.ThrowBusinessException("Invalid request");

            await _mediator.Send(moveRoverCommand);
        }

        [HttpPatch]
        [Route("{id}/Left")]
        public async Task Left(Guid id, TurnLeftRoverCommand turnLeftRoverCommand)
        {
            if (turnLeftRoverCommand.RoverId != id) ApplicationContext.ThrowBusinessException("Invalid request");

            await _mediator.Send(turnLeftRoverCommand);
        }

        [HttpPatch]
        [Route("{id}/Right")]
        public async Task Right(Guid id, TurnRightRoverCommand turnRightRoverCommand)
        {
            if (turnRightRoverCommand.RoverId != id) ApplicationContext.ThrowBusinessException("Invalid request");

            await _mediator.Send(turnRightRoverCommand);
        }
    }
}
