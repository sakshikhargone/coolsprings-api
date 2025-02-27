


namespace CoolSprings.Repository;


    public abstract class BaseRepository
    {
       public  IDbConnection Connect()
        {
            try
            {
                string connectstring = Environment.GetEnvironmentVariable("WebAppDb");
                 var _connection = connectstring.Replace("$DATABASE_NAME$", "ShreeWaterPark");
                IDbConnection connection = new SqlConnection(_connection);
                return connection;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;

            }

        }
    }

