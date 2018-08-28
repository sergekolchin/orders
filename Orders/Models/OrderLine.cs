using System.ComponentModel.DataAnnotations;
using Microsoft.Net.Http.Headers;

namespace Orders.Models
{
    public class OrderLine
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Quantity { get; set; }
    }
}