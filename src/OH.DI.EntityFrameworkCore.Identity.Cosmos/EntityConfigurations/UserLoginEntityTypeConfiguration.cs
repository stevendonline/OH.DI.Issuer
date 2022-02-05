﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OHDI.EntityFrameworkCore.Identity.Cosmos.EntityConfigurations
{
    public class UserLoginEntityTypeConfiguration : IEntityTypeConfiguration<IdentityUserLogin<string>>
    {
        private readonly string _tableName;

        public UserLoginEntityTypeConfiguration(string tableName = "Identity_Logins")
        {
            _tableName = tableName;
        }

        public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
        {
            builder
                .UseETagConcurrency()
                .HasPartitionKey(_ => _.ProviderKey);
            
            builder.ToContainer(_tableName);
        }
    }
}