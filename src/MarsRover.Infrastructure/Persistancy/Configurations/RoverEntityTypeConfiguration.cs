using MarsRover.Domain.AggregatesModel.RoverAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarsRover.Infrastructure.Persistancy.Configurations
{
    public class RoverEntityTypeConfiguration : IEntityTypeConfiguration<Rover>
    {
        public void Configure(EntityTypeBuilder<Rover> builder)
        {
            builder.HasKey(p => p.Id);
            builder.OwnsOne(p => p.Position, position => position.OwnsOne(po => po.Coordinate));
        }
    }
}