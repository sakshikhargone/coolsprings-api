using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolSprings.Model;

public class Booking
{
    public Guid BookingId { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerName { get; set; }
    public Guid DiscountId { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public int NumOfTickets { get; set; }
    public string PaymentMode { get; set; }
    public float ActualAmount { get; set; }
    public float PaidAmount { get; set; }
    public string UPITxnRefNumber { get; set; }
    public DateTime? CreatedAt { get; set; }
}