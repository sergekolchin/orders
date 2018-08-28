using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        public virtual ICollection<OrderLine> Lines { get; set; }
    }
}
