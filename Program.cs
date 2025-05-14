using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot_PROGP2
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Allows user to create a instance for the chatbot and the start
            Chatbot chatbot = new Chatbot();
            chatbot.Start();
        }
    }
}