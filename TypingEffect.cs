using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBot_PROGP1
{ // Simulate typing animation by printing characters out one at a time with a small delay 
    public class TypingEffect
    { //Adds a human-like typing effect to the chatbot's responses
        public void Display(string message, int speed = 50)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(speed);  // Delay to simulate typing
            }
            Console.WriteLine();
        }
    }
}

