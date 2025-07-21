using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolSprings.DTO.Res
{
    public class TicketDetail
    {
        private DateTime _validFrom;

        [Required]
        public DateTime ValidFrom
        {
            get { return _validFrom; }
            set { _validFrom = value; }
        }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public Guid TicketId { get; set; }
    }
}