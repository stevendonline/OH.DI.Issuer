using OH.DI.Core.DigitalCredentialAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OH.DI.Infrastructure.Data.Config;

public class ToDoConfiguration : IEntityTypeConfiguration<ToDoItem>
{
  public void Configure(EntityTypeBuilder<ToDoItem> builder)
  {
    builder.ToContainer("ToDoItem");
    builder.HasPartitionKey(todoitem => todoitem.Id);
    builder.Property(t => t.Title)
        .IsRequired();
  }
}
