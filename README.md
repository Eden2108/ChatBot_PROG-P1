# ChatBot_PROG P1
# BeckyBot: Cybersecurity Awareness Chatbot 🚀🔒💻

## **Project Overview** 🎯🛡️💬
BeckyBot is a **console-based chatbot** designed to educate users about **cybersecurity best practices**. The chatbot provides information on topics such as **password safety, phishing, ransomware, and safe browsing**. It also enhances user engagement with **ASCII art, voice greetings, and a simulated typing effect**. 🎨🔊💻

## **Features** 🎙️🖥️✨
- **Interactive Chat System:** Users can ask questions related to cybersecurity, and BeckyBot responds with predefined answers.
- **Typing Effect:** Simulates real-time typing for a more engaging experience.
- **Voice Greeting:** Plays an audio greeting upon startup.
- **ASCII Art:** Displays a padlock image in ASCII format to enhance the visual appeal.
- **Keyword-Based Response Matching:** Uses keywords to determine appropriate responses.
- **Simple and User-Friendly Interface:** A console-based chatbot that is easy to interact with.

---

## **Installation and Setup** ⚙️💾📥
### **Prerequisites:**
- Windows OS (for SoundPlayer compatibility)
- .NET Framework (C# Development Environment)

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

## **Possible Questions from Lecturer & Answers** 🎤🎓❓
### **1. Why did you choose `.Contains()` for keyword matching instead of an NLP approach?**
**Answer:** Since this is a simple chatbot, `.Contains()` provides a quick and easy way to match keywords. However, for a more advanced chatbot, I would consider **regular expressions or an NLP framework** for better intent recognition. 📚🧠💡

### **2. How does the chatbot handle incorrect user input?**
**Answer:** If the input doesn't match any keywords, the chatbot provides a default response: *"I'm sorry, I didn't quite understand that. Can you please rephrase?"* This ensures a smooth user experience. 🔄🤖📜

### **3. Why did you use `ArrayList` instead of a `Dictionary`?**
**Answer:** `ArrayList` was chosen for simplicity, but a `Dictionary` would be more efficient for **fast lookups**. If scalability were a concern, I would refactor this. 📊🔄⚡

### **4. What improvements would you make if this chatbot needed to handle more complex conversations?**
**Answer:**
- **Switch from keyword-matching to an NLP-based model.**
- **Use a more structured chatbot framework** (like Microsoft Bot Framework).
- **Implement user session memory** to track ongoing conversations.
- **Add multi-turn conversations** for better interactions. 🧠💡🔄

### **5. How does the chatbot play the audio greeting?**
**Answer:** It uses the `SoundPlayer` class to play a `.wav` file from the project directory. If the file is missing, it prints an error message. 🎵🔍📜

---

## **Future Improvements** 🚀🔧📈
- **Implement AI-powered responses** with NLP for a smarter chatbot.
- **Improve efficiency** by replacing `ArrayList` with `Dictionary`.
- **Make it cross-platform** by using .NET Core.
- **Use a GUI instead of a console** for a better user experience.
- **Add database support** to store and learn from past interactions. 🧠📊💾

---

## **Conclusion** 🏁🤖🔐
BeckyBot is a simple but effective cybersecurity awareness chatbot. The project demonstrates key programming concepts like **string matching, console interaction, file handling, multithreading (for effects), and basic image processing (ASCII conversion)**. While it works well for small-scale use, **future enhancements** can make it **more scalable, intelligent, and interactive**. 🚀🎓💡

