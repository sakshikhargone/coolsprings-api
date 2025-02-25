namespace CoolSprings.API
{

    public class ExceptionHandler
    {
        public static void Log(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
