using Telegram.Bot;
using Telegram.Bot.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            
           if (this.CanHandle(message) || chainData.userPostionHandler.ContainsKey(from))
           {
            if ( message.Text == "/registrarme")
            {
                Console.WriteLine("va por nombre");
                chainData.userPostionHandler[from].Add(message.Text);
                response = "Ingrese nombre usuario:";
                return true;                
            }
           
             if(chainData.userPostionHandler[from][0]=="/registrarme")
                { 
                    Console.WriteLine("va por apellido");
                    chainData.userPostionHandler[from].Add(message.Text);
                    response = "Ingrese apellido usuario:";
                    

                    return true;
                }
                if (chainData.userPostionHandler[from][0].Equals("/registrarme") && chainData.userPostionHandler[from].Count==2)
                {
                    response = $"{message.Text}{chainData.userPostionHandler[from][1]}FUNCA";
                    return true;
                }
            

           }
            response = "adios";
            return false;
       

        }
    }
}