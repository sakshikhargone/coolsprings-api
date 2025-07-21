using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolSprings.DTO.Req
{
    public class TokenCredential
    {

        public string CustomerPhone { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPassword { get; set; }
    }


}
