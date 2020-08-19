using System;

namespace IocDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = "v1qwertyuiopasdfghjklzxcvb";
            GreetMessageService service = new GreetMessageService();
            service.Greet(msg);
        }
    }
}
