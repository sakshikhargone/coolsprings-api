namespace CoolSprings.DTO;

public static class ApiEndpoint
{
    public const string ApiBase = "api/v1";

    public static class Booking
    {
        public const string BookingBase = ApiBase + "/bookings";
    }

    public static class Ticket
    {
        public const string TicketBase = ApiBase + "/tickets";
    }

    public static class Customer
    {
        public const string CustomerBase = ApiBase + "/customers";
    }

    public static class Discount
    {
        public const string DiscountBase = ApiBase + "/discounts";
    }

    public static class Enquiry
    {
        public const string EnquiryBase = ApiBase + "/enquiries";
    }
}