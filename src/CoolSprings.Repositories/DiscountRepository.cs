using CoolSprings.Contract.Repository;

namespace CoolSprings.Repository;

public class DiscountRepository : BaseRepository, IDiscountRepository
{
    public async Task AddDiscount(Discount newDiscount)
    {
        try
        {
            var sql = """
                      INSERT INTO Discount(Id,Code,DiscountValue,ExpiryDate,ActivationDate)
                      VALUES(@Id,@Code,@DiscountValue,@ExpiryDate,@ActivationDate)
                      """;
            using var db = Connect();
            await db.ExecuteAsync(sql, new
            {
                Id = newDiscount.DiscountId,
                Code = newDiscount.DiscountCode,
                DiscountValue = 10,
                ExpiryDate = DateTime.Now.AddDays(5),
                ActivationDate = DateTime.Now
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<Discount> GetDiscount(string discountCode)
    {
        try
        {
            var sql = """
                      SELECT * FROM Discount
                      WHERE Code = @discountCode
                      """;
            using var db = Connect();
            var discount = await db.QueryFirstOrDefaultAsync<Discount>(
                sql, new { discountCode }, commandTimeout: commandTimeoutSeconds
            );
            return discount;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}