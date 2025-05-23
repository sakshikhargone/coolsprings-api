namespace CoolSprings.Contract.Repository;

public interface IDiscountRepository
{
    Task AddDiscount(Discount newDiscount);
    Task<Discount> GetDiscount(string discountCode );
}