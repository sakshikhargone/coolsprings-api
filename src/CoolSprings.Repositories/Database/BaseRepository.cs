


namespace CoolSprings.Repository;


    public abstract class BaseRepository
    {
       protected IDbConnection Connect()
        {
            try
            {
                string connectstring = Environment.GetEnvironmentVariable("WebAppDb");
                connectstring.Replace("$DATABASE_NAME$", "ShreeWaterPark");
                IDbConnection connection = new SqlConnection(connectstring);
                return connection;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;

            }

        }
    }

