namespace CoolSprings.Repository
{
    public class BaseRepository
    {
        public virtual IDbConnection Connect()
        {
            try
            {
                string connectionstring = Environment.GetEnvironmentVariable("WebAppDb");
                connectionstring = connectionstring.Replace("$DATABASE_NAME$", "ShreeWaterPark");
                var connection = new SqlConnection(connectionstring);
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}