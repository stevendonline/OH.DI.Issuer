using OH.DI.Core.DigitalCredentialAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OH.DI.Infrastructure.Data.Config;

public class DigitalCredentialConfiguration : IEntityTypeConfiguration<DigitalCredential>
{
  public void Configure(EntityTypeBuilder<DigitalCredential> builder)
  {
    builder.ToContainer("DigitalCredential");
    builder.HasPartitionKey(cred => cred.UserId);

    builder.Property(p => p.Name)
        .HasMaxLength(100)
        .IsRequired();
  }
}
