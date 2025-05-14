using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBot_PROGP2
{
    public class TypingEffect
    {// Adds a human-like typing effect to the chatbot's responses
        public void Display(string message, int speed = 30)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(speed);  // Delay to Simulate typing
            }
            Console.WriteLine();
        }

        // Simulate typing with a prefix like Becky Bot:
        public void DisplayWithPrefix(string prefix, string message, int speed = 30)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(prefix);
            Console.ResetColor();
            Display(message, speed);
        }
    }
}

