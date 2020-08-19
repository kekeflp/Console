namespace IocDemo
{
    public class GreetMessageService
    {
        private EmailHelper greetTool;

        public GreetMessageService()
        {
            greetTool = new EmailHelper();
        }

        public void Greet(string msg)
        {
            greetTool.Send(msg);
        }
    }
}