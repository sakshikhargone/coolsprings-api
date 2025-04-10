using Newtonsoft.Json;

namespace CoolSprings.API.Services
{
    public interface IEncoding
    {
         string Encoding(TokenCredential crendial);
    }
    
    public class EncodingService : IEncoding
    {
        
        public  string Encoding([FromBody]TokenCredential credential)
        {
            var token = JsonConvert.SerializeObject(credential);
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(token);
            return System.Convert.ToBase64String(plainTextBytes);

        }
    }
}
