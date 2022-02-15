﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OH.DI.EntityFrameworkCore.Identity.Cosmos.EntityConfigurations
{
    public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        private readonly string _tableName;

        public RoleEntityTypeConfiguration(string tableName = "Identity_Roles")
        {
            _tableName = tableName;
        }

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.HasPartitionKey(_ => _.Id);
            builder.Property(_ => _.ConcurrencyStamp).IsETagConcurrency();

            builder.ToContainer(_tableName);
        }
    }
}