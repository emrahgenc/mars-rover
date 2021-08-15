using AutoMapper;
using MarsRover.Application.Commands;
using MarsRover.Application.Queries;
using MarsRover.Domain.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarsRover.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlateauController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PlateauController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("")]
        public async Task<Guid> Insert(CreatePlateauCommand createPlateauCommand)
        {
            return await _mediator.Send(createPlateauCommand);
        }

        [HttpGet]
        [Route("")]
        public async Task<List<PlateauViewModel>> Get()
        {
            var plateous = await _mediator.Send(new GetAllPlateausQuery());
            return _mapper.Map<List<PlateauViewModel>>(plateous);
        }
    }
}
