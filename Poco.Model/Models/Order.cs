using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Poco.Model.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public long TrackingNumber { get; set; }
        public virtual ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}