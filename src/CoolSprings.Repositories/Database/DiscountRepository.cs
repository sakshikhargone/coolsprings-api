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

        public async Task<bool> AddDiscount(Discount discount)
        {
            try
            {
                using(var db = Connect())
                {
                    return true;
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
