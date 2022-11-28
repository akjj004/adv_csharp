using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Poco.Model.Models
{
    public class Product
    {
        public string? Category { get; set; }
        public string? Description { get; set; }

        [Key]
        public int ProductId { get; set; }
        public byte[]? ImageBytes { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public virtual ICollection<OrderProduct>? OrderProducts { get; set; }

    }
}