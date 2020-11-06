using System;
using Familee.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Familee.Persistence.Configuration
{
    public class FamilyMemberConfiguration : IEntityTypeConfiguration<FamilyMember>
    {
        public void Configure(EntityTypeBuilder<FamilyMember> builder)
        {
            builder.ToTable("FamilyMembers");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(250);
            
            builder.Property(e => e.LastName)
                .HasMaxLength(250);

            builder.Property(e => e.Gender)
                .IsRequired()
                .HasConversion(
                    gender => gender == Gender.Male ? "M" : "F",
                    dbValue =>
                        dbValue.Equals("F", StringComparison.OrdinalIgnoreCase)
                            ? Gender.Female
                            : Gender.Male);

            builder.Property(e => e.ImagePath)
                .HasMaxLength(1000)
                .IsRequired(false);
        }
    }

    
}