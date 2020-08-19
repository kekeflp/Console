
namespace IocDemo
{
    public class TelephoneHelper: ISendable
    {
        public void Send(string msg)
        {
            System.Console.WriteLine($"From telephone: {msg}");
        }
    }
}