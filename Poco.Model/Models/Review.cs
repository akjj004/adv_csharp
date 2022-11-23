using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poco.Model.Models
{
    public class Review
    {
        public int Id { get; set; }
        public String? Title { get; set; }
        public String? Text { get; set; }
    }
}