using CoolSprings.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolSprings.Repository.Database
{
    public class DiscountRepository : BaseRepository, IDiscountRepository
    {

        public async Task AddDiscount(string discountCode, Guid Id)
        {
            try
            {
                var Discount = new Discount();
                {
                    Discount.Id = Id;
                    Discount.Code = discountCode;
                }
                var query = @"Insert into Discount(Id, Code, DiscountValue, ActivationDate, ExpiryDate) values(@Id, @Code, @DiscountValue, @ActivationDate, @ExpiryDate )";
                using(var db = Connect())
                {
                    await db.ExecuteAsync(query, new
                    {
                        Id = Id,
                        Code = discountCode,
                        DiscountValue = "10",
                        ActivationDate = DateTime.Now,
                        ExpiryDate = DateTime.Now.AddDays(7)
                    });
                }

                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
