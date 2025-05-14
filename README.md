# ChatBot_PROG P1 🚀🔒💻

## **Project Overview** 🎯🛡️💬
The Chatbot is a **console-based chatbot** that is designed to educate users about **cybersecurity best practices**. The chatbot provides information on topics such as **password safety, phishing, ransomware, and safe browsing**. It also enhances user engagement with **ASCII art, voice greetings, and a simulated typing effect**. 🎨🔊💻

## **Features** 🎙️🖥️✨
- **Interactive Chat System:** Enables users to ask questions related to cybersecurity, and BeckyBot responds with predefined answers.
- **Typing Effect:** Simulates real-time typing for a more engaging experience.
- **Voice Greeting:** Plays an audio greeting upon startup.
- **ASCII Art:** Displays a padlock image in ASCII format to enhance the visual appeal.
- **Keyword-Based Response Matching:** Uses keywords to determine appropriate responses.
- **Simple and User-Friendly Interface:** A console-based chatbot that is easy to interact with.

---

## **Installation and Setup** ⚙️💾📥
### **Prerequisites:**
- Windows OS (for SoundPlayer compatibility)
- .NET Framework (C# Development Environment) version 4.7.2 or 4.8

### **Steps to Run the Chatbot:**
1. Clone or download the repository.
2. Open the project in **Visual Studio** or any compatible C# IDE.
3. Make sure `greeting.wav` and `padlock logo.png` are in the project directory.
4. Build and run the project using `Program.cs`.
5. The chatbot will initialize, play a voice greeting, and display ASCII art.
6. Start interacting by asking cybersecurity-related questions! 🎤🖥️🔑

---

## **Code Structure** 📂📜🔧
```
BeckyBot/
│── Program.cs          # Entry point for the chatbot
│── Chatbot.cs          # Main chatbot logic (handles user input and responses)
│── TypingEffect.cs     # Simulates typing effect for responses
│── VoiceGreeting.cs    # Plays a greeting sound
│── AsciiArt.cs         # Converts and displays an image in ASCII format
```

---

## **How It Works** 🔄🤖🎯
1. **Startup Sequence:**
   - Displays ASCII art.
   - Plays an audio greeting.
   - Initializes chatbot responses.
   - Prompts user for their name and welcomes them. 🎤📜💬

2. **User Interaction:**
   - The chatbot continuously listens for user input.
   - It matches input against predefined **keywords** (e.g., "password safety").
   - If a keyword is found, the chatbot provides a relevant response.
   - If the input is not recognized, the chatbot asks the user to rephrase. 💡🔍💬

3. **Exit Condition:**
   - Typing "exit" or "quit" will end the chatbot session. 🚪👋💻

---

## **Design Decisions & Trade-offs** ⚖️💡🛠️
### **1. Keyword-Based Response Matching**
**Decision:** Uses `.Contains()` to check for keywords in user input.
- **Pros:** Simple and easy to implement.
- **Cons:** Limited accuracy; false positives may occur.
- **Improvement:** Using **regular expressions** or an NLP library (like Microsoft's LUIS) for better intent recognition. 📊🔍🧠

### **2. Using `ArrayList` for Responses**
**Decision:** Stores chatbot responses in an `ArrayList`.
- **Pros:** Quick to implement and easy to modify.
- **Cons:** Inefficient for larger datasets.
- **Improvement:** Switching to a `Dictionary<string, string>` for faster lookups. 🔄📂💡

### **3. `Thread.Sleep()` for Typing Effect**
**Decision:** Delays output to simulate typing.
- **Pros:** Enhances user engagement.
- **Cons:** Blocks execution; chatbot is unresponsive during typing.
- **Improvement:** Using `Task.Delay()` for an **asynchronous approach**. ⏳⚡🔄

### **4. Using `SoundPlayer` for Audio**
**Decision:** Plays a `.wav` file at startup.
- **Pros:** Simple and effective for basic sound playback.
- **Cons:** Limited to `.wav` format and blocks execution.
- **Improvement:** Using **NAudio** for broader file support and non-blocking playback. 🎵🔄🎧

### **5. ASCII Art Conversion**
**Decision:** Converts an image into ASCII.
- **Pros:** Enhances visual appeal and branding.
- **Cons:** Large images may reduce performance.
- **Improvement:** Preprocessing images to optimize for ASCII conversion. 🎨🖼️🔢

---

## **Future Improvements** 🚀🔧📈
- **Implement AI-powered responses** with NLP for a smarter chatbot.
- **Improve efficiency** by replacing `ArrayList` with `Dictionary`.
- **Add database support** to store and learn from past interactions. 🧠📊💾

---

## **Conclusion** 🏁🤖🔐
The ChatBot is a simple but effective cybersecurity awareness chatbot. The project demonstrates key programming concepts like **string matching, console interaction, file handling, multithreading (for effects), and basic image processing (ASCII conversion)**. While it works well for small-scale use, **future enhancements** can make it **more scalable, intelligent, and interactive**. 🚀🎓💡

