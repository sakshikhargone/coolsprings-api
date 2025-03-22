using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolSprings.Model
{
    public class Enquiry : BaseModel<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }   
    }

    public abstract class BaseModel<T>
    {
        public T Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
