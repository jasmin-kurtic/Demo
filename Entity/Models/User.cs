using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Token { get; set; }

        public virtual ICollection<Order> Orders { get; } = new HashSet<Order>();
    }
}
