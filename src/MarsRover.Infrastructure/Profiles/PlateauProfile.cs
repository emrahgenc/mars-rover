using AutoMapper;
using MarsRover.Domain.AggregatesModel.PlateauAggregate;
using MarsRover.Domain.ViewModels;

namespace MarsRover.Infrastructure.Profiles
{
    public class PlateauProfile : Profile
    {
        public PlateauProfile()
        {
            CreateMap<Plateau, PlateauViewModel>()
                .ForMember(p => p.Height, p => p.MapFrom(v => v.Size.Height))
                .ForMember(p => p.Width, p => p.MapFrom(v => v.Size.Width));
        }
    }
}
