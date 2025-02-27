
namespace CoolSprings.Repository.Contract;

 public interface IDiscountRepository
    {
    Task AddDiscount(string discountCode, Guid Id);
    }

