namespace IocDemo
{
    public class GreetMessageService
    {
        #region V1.0需求 
        /* 
        private EmailHelper greetTool;

        public GreetMessageService()
        {
            greetTool = new EmailHelper();
        }

        public void Greet(string msg)
        {
            greetTool.Send(msg);
        } 
        */
        #endregion

        #region V2.0需求-内容
        ISendable greetTool;
        public GreetMessageService(SendToolType sendToolType)
        {
            if (sendToolType == SendToolType.Email)
            {
                greetTool = new EmailHelper();
            }
            else if (sendToolType == SendToolType.Telephone)
            {
                greetTool = new TelephoneHelper();
            }
        }

        public void Greet(string message)
        {
            greetTool.Send(message);
        }
        #endregion

    }

    #region V2.0需求-内容
    public enum SendToolType
    {
        Email,
        Telephone,
    }
    #endregion
}