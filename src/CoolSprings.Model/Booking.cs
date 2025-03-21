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

    [Required(AllowEmptyStrings = false, ErrorMessage = "CustomerPhone is required")]
    [StringLength(10, ErrorMessage = "CustomerPhone must be exactly 10 digits")]
    [RegularExpression(pattern: @"^[6-9]{1}[\d]{9}$", ErrorMessage = "CustomerPhone is invalid")]
    public string CustomerPhone { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage ="CustomerName is required")]
    [RegularExpression(pattern: @"^[A-Za-z]+( [A-Za-z]+)*$", ErrorMessage ="CustomerName is invalid")]
    [MinLength(3)]
    public string CustomerName { get; set; }

    public string? DiscountCode { get; set; }

    public Guid? DiscountId { get; set; }
    
    public DateTime ValidFrom { get; set; }
    
    public DateTime ExpiryDate { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "No. of tickets is required ")]
    [Range(1, int.MaxValue, ErrorMessage = "Number of tickets must be at least 1.")]
    public int NumOfTickets { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Payment mode is requird")]
    public string PaymentMode { get; set; }

    [Required (AllowEmptyStrings = false, ErrorMessage = "Actual amount is required")]
    
    public float? ActualAmount { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Paid amount is required")]
    public float? PaidAmount { get; set; }
    public string? UPITxnRefNumber { get; set; }
    public DateTime CreatedAt { get; set; }
}