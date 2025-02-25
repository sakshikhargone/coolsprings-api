using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolSprings.Model
{
    public class Discount
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public int DiscountValue { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
