using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value bigger than {1}"), DataType("decimal(18,2)")]
        public decimal Price { get; set; }
    }
}