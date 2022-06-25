using Telegram.Bot;
using Telegram.Bot.Types;
using System;

namespace Ucu.Poo.TelegramBot
{
    public class RegisterUserHandler : BaseHandler
    {
        public RegisterUserHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/registrarme" };
        }

        protected override bool InternalHandle(Message message, out string response)
        {
            ChainData chainData = ChainData.Instance; 
            string from = message.From.ToString();
            if (!chainData.userPostionHandler.ContainsKey(from)){
                chainData.userPostionHandler[from] = "2";
            }
            Console.WriteLine("hola");
            if (chainData.userPostionHandler.ContainsKey(from) && message.Text == "/registrarme")
            {
                response = "Ingrese nombre usuario:";
                chainData.userPostionHandler[from] = "regis1";
                return true;
            }
            Console.WriteLine(chainData.userPostionHandler[from]);
            if(chainData.userPostionHandler[from] == "regis1"){ 
                response = "Ingrese apellido usuario:";
                return true;
            }
            response = "adios";
            return false;
       

        }
    }
}