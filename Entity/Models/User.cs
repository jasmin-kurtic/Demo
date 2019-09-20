using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public virtual ICollection<Order> Orders { get; } = new HashSet<Order>();
    }
}
