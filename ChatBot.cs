using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ChatBot_PROGP2
{ 
    public class Chatbot
    {
        // Chatbot components
        private VoiceGreeting voiceGreeting;
        private TypingEffect typingEffect;
        private AsciiArt asciiArt;

        // Memory and response handling
        private Dictionary<string, List<string>> responses;
        private Dictionary<string, int> responseIndexes = new Dictionary<string, int>();
        private List<string> userInterests = new List<string>();
        private string userName;
        private string lastSuggestedTopic = "";
        private bool awaitingFollowUp = false;  // Tracks if the bot is waiting for a topic confirmation



        // Constructor
        public Chatbot()
        {
            voiceGreeting = new VoiceGreeting();
            typingEffect = new TypingEffect();
            asciiArt = new AsciiArt();
            InitializeResponses();
        }

        // Start chatbot interaction
        public void Start()
        {
            Console.Title = "CYBERSECURITY AWARENESS CHATBOT";
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            // Display the visuals and sound
            voiceGreeting.PlayVoiceGreeting("greeting.wav");
            asciiArt.DisplayArt();
            InitializeChatbot();

            // Prompt the user to enter their name
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n" + new string('=', 100));
            Console.Write("Please enter your name: ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            userName = Console.ReadLine();
            Console.ResetColor();

            if (string.IsNullOrEmpty(userName)) userName = "User";

            // Welcome message
            Console.ForegroundColor = ConsoleColor.Cyan;
            typingEffect.Display($"Hello, {userName}! I am your Cybersecurity Awareness Chatbot. How can I assist you today?");
            typingEffect.Display("You can ask me about password safety, phishing, ransomware, or safe browsing.");
            Console.ResetColor();

            // Main chat loop
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\n{userName}: ");
                Console.ResetColor();

                // User input in White
                Console.ForegroundColor = ConsoleColor.Magenta;
                string userInput = Console.ReadLine().ToLower().Trim();
                Console.ResetColor();

                if (userInput == "exit" || userInput == "quit")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    typingEffect.Display("Goodbye! Stay safe online.");
                    Console.ResetColor();
                    break;
                }

                // Bot is awaiting a response "yes" or "no"
                if (awaitingFollowUp)
                {
                    string followUpResponse = HandleFollowUpTopic(userInput);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Becky Bot: ");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Gray;
                    typingEffect.Display(followUpResponse);
                    Console.ResetColor();

                    continue; // Skip rest of loop to avoid normal response flow
                }

                // Normal chatbot flow
                DetectAndStoreInterest(userInput);
                string botResponse = GetResponse(userInput);

                // Becky Bot's reply
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Becky Bot: ");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Gray;
                typingEffect.Display(botResponse);
                Console.ResetColor();
            }
        }

        // Loading animation
        private static void InitializeChatbot()
        {
            Console.Write("Initializing security protocols: ");
            for (int i = 0; i <= 100; i += 5)
            {
                Console.Write($"\rInitializing security protocols: {i}% [");
                Console.Write(new string('#', i / 5));
                Console.Write(new string(' ', 20 - (i / 5)));
                Console.Write("]");
                Thread.Sleep(100);
            }
            Console.WriteLine("\nSystem ready!\n");
        }

        // Initialize responses 
        private void InitializeResponses()
        {
            responses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "how are you", new List<string> {
                    "I'm just a chatbot, but thanks for asking!",
                    "I'm functioning properly and ready to help you with cybersecurity tips."
                } },
                { "what's your purpose", new List<string> {
                    "To help you stay safe online by providing cybersecurity awareness.",
                    "I'm here to teach and answer your cybersecurity-related questions."
                } },
                { "what can i ask you about", new List<string> {
                    "You can ask about password safety, phishing, ransomware, or safe browsing.",
                    "Feel free to ask about anything related to cybersecurity!"
                } },
                { "password", new List<string> {
                    "Use strong passwords with 10+ characters, symbols, and numbers.",
                    "Never reuse passwords for different sites.",
                    "Avoid using common passwords like '123456' or 'password'.",
                    "Consider using a password manager to store complex passwords."
                } },
                { "phishing", new List<string> {
                    "Phishing tricks people into clicking malicious links. Always verify the sender's email address!",
                    "Don't trust emails asking for personal info—check the URL.",
                    "Be cautious of messages with urgent or threatening language.",
                    "Use two-factor authentication to add an extra layer of security."
                } },
                { "safe browsing", new List<string> {
                    "Ensure you're visiting secure websites (look for HTTPS).",
                    "Avoid downloading from untrusted sources.",
                    "Use a reliable antivirus and ad blocker."
                } },
                { "ransomware", new List<string> {
                    "Ransomware is a type of malware that encrypts a victim's files the attacker then demands a ransom from the victim to restore access to the data upon payment",
                    "Back up your data regularly to avoid data loss.",
                    "Keep your software up to date to avoid vulnerabilities."
                } }
            };
        }

        // Detect user interests and add to memory
        private void DetectAndStoreInterest(string input)
        {
            string[] topics = { "password", "phishing", "ransomware", "safe browsing", "privacy" };

            foreach (var topic in topics)
            {
                if (input.Contains(topic) && !userInterests.Contains(topic))
                {
                    userInterests.Add(topic);
                }
            }
        }

        // Main response logic
        private string GetResponse(string userInput)
        {
            string sentimentReply = CheckSentiment(userInput);
            if (sentimentReply != null)
                return sentimentReply;

            foreach (var entry in responses)
            {
                if (userInput.Contains(entry.Key))
                {
                    var replyList = entry.Value;
                    if (!responseIndexes.ContainsKey(entry.Key))
                        responseIndexes[entry.Key] = 0;

                    int index = responseIndexes[entry.Key];
                    string response = replyList[index];

                    responseIndexes[entry.Key] = (index + 1) % replyList.Count;
                    return response;
                }
            }

            if (userInterests.Count > 0)
            {
                var random = new Random();
                string topic = userInterests[random.Next(userInterests.Count)];

                if (topic != lastSuggestedTopic)
                {
                    lastSuggestedTopic = topic;
                    awaitingFollowUp = true;
                    return $"Earlier you mentioned {topic}. Would you like tips on that?";
                }
            }

            return "I'm sorry, I didn't quite understand that. Could you rephrase or ask something cybersecurity-related?";
        }

        private string HandleFollowUpTopic(string input)
        {
            awaitingFollowUp = false;

            if (input.Contains("yes") || input.Contains("sure") || input.Contains("ok"))
            {
                if (responses.ContainsKey(lastSuggestedTopic))
                {
                    var tips = responses[lastSuggestedTopic];
                    var index = responseIndexes.ContainsKey(lastSuggestedTopic) ? responseIndexes[lastSuggestedTopic] : 0;
                    string tip = tips[index];

                    responseIndexes[lastSuggestedTopic] = (index + 1) % tips.Count;
                    return tip;
                }
                else
                {
                    return "Sorry, I don't have detailed tips on that topic yet.";
                }
            }
            else if (input.Contains("no") || input.Contains("not really") || input.Contains("maybe later"))
            {
                return "No problem! Let me know if you change your mind or want help with something else.";
            }
            else
            {
                return GetResponse(input);
            }
        }


        // Sentiment detection and empathy
        private string CheckSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("anxious"))
            {
                return "It's okay to feel that way. Cybersecurity can be overwhelming, but I'm here to help you step by step.";
            }
            else if (input.Contains("confused") || input.Contains("lost"))
            {
                return "No worries! I can explain things more clearly. What topic is confusing you?";
            }
            else if (input.Contains("thank you") || input.Contains("thanks"))
            {
                return $"You're welcome! I'm glad I could help. Let me if you need more assistance {userName}";
            }

            return null;
        }
    }
}
