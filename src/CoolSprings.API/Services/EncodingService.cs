

namespace CoolSprings.API.Services
{
    public interface IEncoding
    {
         string Encoding(TokenCredentialDTO crendial);
    }
    
    public class EncodingService : IEncoding
    {
        
        public  string Encoding([FromBody]TokenCredentialDTO credential)
        {
            var token = JsonConvert.SerializeObject(credential);
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(token);
            return System.Convert.ToBase64String(plainTextBytes);

        }
    }
}
