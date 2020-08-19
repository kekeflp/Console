namespace IocDemo
{
    public class SMSHelper : ISendable
    {
        public void Send(string msg)
        {
            System.Console.WriteLine($"From SMS: {msg}");
        }
    }
}