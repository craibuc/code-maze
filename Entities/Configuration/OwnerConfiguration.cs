using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

using Domain.Models;

namespace Domain.Configuration
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasData
            (
                new Owner
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Street = "street",
                    City = "city",
                    PostalCode = "00000",
                    RegionCode = "AA"
                },
                new Owner
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Foe",
                    Street = "street",
                    City = "city",
                    PostalCode = "00000",
                    RegionCode = "AA"
                }

            );
        }
    }
}
