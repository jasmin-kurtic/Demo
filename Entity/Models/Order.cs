using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public User CreatedBy { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
