using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public virtual User CreatedBy { get; set; }
        public int CreatedById { get; set; }
        public virtual ICollection<OrderItem> Items { get; } = new HashSet<OrderItem>();
    }
}
