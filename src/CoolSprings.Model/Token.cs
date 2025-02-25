using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolSprings.Model
{
    public class Token
    {
        public Guid TokenId { get; set; }
        public string TokenValue { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime ValidFrom{ get; set; }
        public DateTime ExpireAt { get; set; }
        public bool IsActive { get; set; }


    }
}
