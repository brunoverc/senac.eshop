using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Senac.eShop.Domain.Entities;

namespace Senac.eShop.Infra.Data.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Cpf).HasMaxLength(14).IsRequired();

            builder.Property(c => c.Active).HasDefaultValue(true);
            builder.Property(c => c.AddressId).IsRequired();
            builder.Property(c => c.Birth).IsRequired();

            builder.HasKey(c => c.Id);
        }
    }
}
