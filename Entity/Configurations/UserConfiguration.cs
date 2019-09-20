using Entity.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Configurations
{
    public class UserConfiguration
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(o => o.Username).IsRequired();
            builder.Property(o => o.PasswordHash).IsRequired();
            builder.Property(o => o.PasswordSalt).IsRequired();
        }
    }
}
