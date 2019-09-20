using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Configurations
{
    public class OrderItemConfiguration
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(p => p.Order)
                .WithMany(p => p.Items)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.Name).IsRequired();
        }
    }
}
