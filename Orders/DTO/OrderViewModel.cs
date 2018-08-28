using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.DTO
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<OrderLineViewModel> Lines { get; set; }
    }
}
