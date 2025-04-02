using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ChatBot_PROGP1
{ 
    public class Chatbot
    {
        //Key Features of the Chatbot
        private VoiceGreeting voiceGreeting; // Plays an introductory voice greeting sound when the chatbot starts
        private TypingEffect typingEffect; // This simulates typing responses to make the conservation feel more engaging
        private AsciiArt asciiArt; //Displays the padlock logo in ASCII format to enhance the chatbot's visual appeal
        private ArrayList responses;


        //Constructor to initialize the chatbot
        public Chatbot()
        {
            voiceGreeting = new VoiceGreeting();
            typingEffect = new TypingEffect();
            asciiArt = new AsciiArt();
            InitializeResponses(); // Load responses
        }

        public void Start()
        {
            Console.Title = "CYBERSECURITY AWARENESS CHATBOT";
            Console.ForegroundColor = ConsoleColor.Blue;

            // Display ASCII art and play voice greeting
            voiceGreeting.PlayVoiceGreeting("greeting.wav");
            asciiArt.DisplayArt();

            InitializeChatbot(); // Displays the loading effect

            // Prompts user to enter their name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + new string('=', 100));
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName)) userName = "User";
            Console.ResetColor();

            // ChatBot Welcome Message To User
            Console.ForegroundColor = ConsoleColor.Yellow;
            typingEffect.Display($"Hello, {userName}! Welcome, I am your Cybersecurity Awareness Chatbot. How can I help you today?");
            typingEffect.Display("You can ask me questions about password safety, phishing , safe browsing, or ransomware");
            Console.ResetColor();

            while (true) // Continuously prompt user for input and provide response // It is an Infinite Chat Loop
            { // User Input and Loop for Chatbot Responses
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nYou:");// Fix this part
                string userInput = Console.ReadLine().ToLower();
                Console.ResetColor();

                if (userInput == "exit" || userInput == "quit")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    typingEffect.Display("Goodbye! Stay safe online.");
                    Console.ResetColor();
                    break;
                }

                string botResponse = GetResponse(userInput);
                Console.ForegroundColor = ConsoleColor.Yellow;
                typingEffect.Display($"Becky Bot: {botResponse}");
                Console.ResetColor();
            }
        }

        private static void InitializeChatbot()
        {
            Console.Write("Initializing security protocols: ");
            for (int i = 0; i <= 100; i += 5)
            {
                Console.Write($"\rInitializing security protocols: {i}% [");
                Console.Write(new string('#', i / 5));
                Console.Write(new string(' ', 20 - (i / 5)));
                Console.Write("]");
                Thread.Sleep(100); // Simulate processing time
            }
            Console.WriteLine("\nSystem ready!\n");
        }

        private void InitializeResponses()
        {
            responses = new ArrayList
            {
                 new string[] { " how are you", " Sorry I'm just a chatbot, but thanks for asking! I'm just here to help you with cybersecurity questions." },
                 new string[] { " what's your purpose", " My purpose is to educate and help you understand cybersecurity topics to stay safe online." },
                 new string[] { " what can i ask you about", " You can ask me anything cybersecurity related." },
                 new string[] { " password safety", " Use a strong password with at least 10 characters, including numbers and symbols." },
                 new string[] { " phishing", " It is a type of attack often used to steal user data, such as login credentials and credit card numbers." },
                 new string[] { " safe browsing", " Ensure you're visiting secure websites (look for HTTPS), avoid suspicious links, and use a reliable ad blocker." },
                 new string[] { " ransomware ", "Ransomware is a type of malware that encrypts a victim's files. The attacker then demands a ransom from the victim to restore access to the data upon payment." },
            };
        }

        private string GetResponse(string userInput)
        {

            userInput = userInput.ToLower().Trim();// Convert user input to lowercase

            foreach (string[] response in responses)
            {
                string keyword = response[0];  // The keyword or phrase pattern
                string reply = response[1];    // The corresponding response

                // Check if user input contains any of the keywords or matches the pattern
                if (MatchesKeyword(userInput, keyword))
                {
                    return reply; // Return the response

                }
            }

            // Default response for invalid input
            return "I'm sorry, I didn't quite understand that. Can you please rephrase?";
        }

        private bool MatchesKeyword(string input, string keyword)
        {
            // Check if the input contains the keyword
            if (input.Contains(keyword))
            {
                return true;
            }
            // Check if the input matches the pattern
            string[] words = keyword.Split(' '); // Split the keyword into words
            foreach (string word in words)
            {
                if (!input.Contains(word))
                {
                    return false; // Return false if any word is missing
                }
            }
            return true; // Return true if all words are found
        }

    }
}