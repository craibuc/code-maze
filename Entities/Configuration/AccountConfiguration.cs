using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

using Domain.Models;

namespace Domain.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData
            (
                new Account
                {
                    Id = 100,
                    DateCreated = DateTime.Now,
                    AccountType = Enumerations.AccountType.Checking,
                    OwnerId = 1
                },
                new Account
                {
                    Id = 200,
                    DateCreated = DateTime.Now,
                    AccountType = Enumerations.AccountType.Saving,
                    OwnerId = 1
                },
                new Account
                {
                    Id = 300,
                    DateCreated = DateTime.Now,
                    AccountType = Enumerations.AccountType.Checking,
                    OwnerId = 2
                }
            );
        }

    }

}
