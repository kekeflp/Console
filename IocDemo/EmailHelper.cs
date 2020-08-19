
namespace IocDemo
{
    public class EmailHelper: ISendable
    {
        public void Send(string msg)
        {
            System.Console.WriteLine($"From Email: {msg}");
        }
    }
}