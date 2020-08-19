using System;

namespace IocDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = "v1qwertyuiopasdfghjklzxcvb";
            #region V1.0
            // GreetMessageService service = new GreetMessageService();
            // service.Greet(msg);
            #endregion

            #region V2.0
            GreetMessageService service = new GreetMessageService(SendToolType.Telephone);
            service.Greet(msg);
            #endregion

        }
    }
}
