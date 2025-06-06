namespace CoolSprings.Repository
{
    public class BaseRepository
    {
        protected int commandTimeoutSeconds =
                                            #if DEBUG
                                                5000;
                                            #else
                                                3000;
                                            #endif
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