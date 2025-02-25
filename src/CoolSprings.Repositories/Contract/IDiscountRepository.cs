
namespace CoolSprings.Repository.Contract;

 public interface IDiscountRepository
    {
        Task<bool> AddDiscount(Discount discount);
    }

