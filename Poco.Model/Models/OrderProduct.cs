using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poco.Model.Models
{
    public class OrderProduct
    {

        [ForeignKey("ProductId")]
        // nav
        public virtual Product? Product { get; set; }
        [Key]
        public int ProductId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}