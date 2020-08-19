namespace IocDemo
{
    public class EmailHelper
    {
        public void Send(string msg)
        {
            System.Console.WriteLine($"From Email: {msg}");
        }
    }
}