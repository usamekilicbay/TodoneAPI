using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoneAPI.EntityConfigurations
{
    public class TodoEntityTypeConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("identifier")
                   .HasColumnType("varchar(36)")
                   .HasDefaultValueSql("uuid_generate_v4()")
                   .IsRequired();
        }
    }
}
