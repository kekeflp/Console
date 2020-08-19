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
            // GreetMessageService service = new GreetMessageService(SendToolType.Telephone);
            // service.Greet(msg);
            #endregion

            #region V3.0
            // 想怎么发,就new相应的对象;后台只管发,不管你前台用什么工具来发
            // GreetMessageService service1 = new GreetMessageService(new TelephoneHelper());
            // service1.Greet(msg);
            // GreetMessageService service2 = new GreetMessageService(new SMSHelper());
            // service2.Greet(msg);
            #endregion

           
        }
    }
}
