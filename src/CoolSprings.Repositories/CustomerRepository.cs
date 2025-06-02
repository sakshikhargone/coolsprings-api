using CoolSprings.Contract.Repository;

namespace CoolSprings.Repository;

public class CustomerRepository : BaseRepository, ICustomerRepository
{
    public async Task AddCustomer(Customer newCustomer)
    {
        try
        {
            var query = @"INSERT INTO Customer(CustomerId, CustomerName, CustomerPhone,  CreatedAt)
                              VALUES(@CustomerId, @CustomerName, @CustomerPhone,  @CreatedAt)";
            using var db = Connect();
            await db.ExecuteAsync(query, new
            {
                CustomerId = newCustomer.CustomerId,
                CustomerName = newCustomer.CustomerName,
                CustomerPhone = newCustomer.CustomerPhone,
                CreatedAt = newCustomer.CreatedAt
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<Customer> GetCustomer(string customerPhone)
    {
        try
        {
            var sql = """
                      SELECT * FROM Customer
                      WHERE CustomerPhone = @customerPhone
                      """;
            using var db = Connect();
            var customer = await db.QueryFirstOrDefaultAsync<Customer>(sql, new { customerPhone });
            return customer;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task UpdateCustomer(TokenCredential credential)
    {
        try
        {
            var sql = """
                      UPDATE  Customer
                      SET CustomerEmail = @CustomerEmail, CustomerPassword = @CustomerPassword
                      WHERE CustomerPhone = @CustomerPhone
                      """;
            using var db = Connect();
            await db.ExecuteAsync(sql, new
            {
                CustomerEmail = credential.CustomerEmail,
                CustomerPassword = credential.CustomerPassword,
                CustomerPhone = credential.CustomerPhone
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<CustomerHistoryDTO> GetCustomerHistory(Guid customerId)
    {
        var customerQuery = """
                            SELECT CustomerName, CustomerPhone FROM Customer
                            WHERE CustomerId = @customerId;
                            """;
        var bookingQuery = """
                           SELECT NumOfTickets, PaymentMode, ActualAmount,PaidAmount,ValidFrom,ExpiryDate FROM Booking
                           WHERE CustomerId = '75E10B58-C31E-4F35-BB76-3557537E92A5';
                           """;
        using var db = Connect();
        var customerDetail = await db.QueryFirstOrDefaultAsync<CustomerHistoryDTO>(customerQuery, new { customerId });
        var bookingDetail = await db.QueryAsync<BookingDetail>(bookingQuery, customerId);
        if (customerDetail != null)
        {
            customerDetail.Booking = bookingDetail;
        }
        return customerDetail;
    }

    public async Task<Customer> GetCustomerByBookingId(Guid bookingId)
    {
        try
        {
            var sql = """
                  SELECT C.*
                  FROM Customer C
                  JOIN Booking B ON C.CustomerId = B.CustomerId
                  WHERE B.BookingId = @bookingId
                  """;
            using var db = Connect();
            var customer = await db.QueryFirstOrDefaultAsync<Customer>(sql, new { bookingId });
            return customer;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}