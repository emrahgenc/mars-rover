using AutoMapper;
using MarsRover.Domain.AggregatesModel.RoverAggregate;
using MarsRover.Domain.ViewModels;

namespace MarsRover.Infrastructure.Profiles
{
    public class RoverProfile : Profile
    {
        public RoverProfile()
        {
            CreateMap<Position, PositionViewModel>();
        }
    }
}