using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoolSprings.Model;

public class Booking
{
    public Guid BookingId { get; set; }
    public Guid CustomerId { get; set; }
    [Required]
    public string CustomerPhone { get; set; }
    [Required]
    public string CustomerName { get; set; }
    public string DiscountCode { get; set; }
    public Guid DiscountId { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ExpiryDate { get; set; }
    [Required]
    
    public int NumOfTickets { get; set; }
    [Required]
    public string PaymentMode { get; set; }
    public float ActualAmount { get; set; }
    public float PaidAmount { get; set; }
    public string UPITxnRefNumber { get; set; }
    public DateTime? CreatedAt { get; set; }
}