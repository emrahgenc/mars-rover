using MarsRover.Domain.AggregatesModel.PlateauAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarsRover.Infrastructure.Persistancy.Configurations
{
    public class PlateauEntityTypeConfiguration : IEntityTypeConfiguration<Plateau>
    {
        public void Configure(EntityTypeBuilder<Plateau> builder)
        {
            builder.HasKey(p => p.Id);
            builder.OwnsOne(p => p.Size);
        }
    }
}
