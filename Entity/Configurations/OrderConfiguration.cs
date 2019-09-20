using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(p => p.CreatedBy)
                .WithMany(p => p.Orders)
                .HasForeignKey(p=>p.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(p => p.CreatedById).IsRequired();
        }
    }
}
