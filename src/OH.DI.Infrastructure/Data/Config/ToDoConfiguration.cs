//using OH.DI.Core.DigitalCredentialAggregate;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace OH.DI.Infrastructure.Data.Config;

//public class ToDoConfiguration : IEntityTypeConfiguration<AssuredClaim>
//{
//  public void Configure(EntityTypeBuilder<AssuredClaim> builder)
//  {
//    builder.ToContainer("ToDoItem");
//    builder.HasPartitionKey(todoitem => todoitem.Id);
//    builder.Property(t => t.Name)
//        .IsRequired();
//  }
//}
