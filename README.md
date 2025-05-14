# ChatBot_PROG P2 🚀🔒💻

# 🛡️ Project Overview Cybersecurity Awareness Chatbot – Becky Bot

Welcome to **Becky Bot**, a friendly and interactive console-based chatbot designed to educate users on essential **cybersecurity practices** such as password safety, phishing awareness, ransomware protection, and safe browsing habits.

This project was developed in C# as part of an academic programming module, showcasing logic handling, modular design, and creative user engagement through audio, animation, and color formatting.

---

## ✨ Features

### ✅ Educational Intelligence
- Responds accurately to common cybersecurity queries.
- Offers rotating answers for variety and engagement.
- Uses keyword detection and delegate handlers for modular design.

### 🎨 Enhanced User Interface (Console-Based)
- **Color-coded text** for:
- 🟪 **User inputs** – Magenta
  - 🟦 **Becky Bot responses** – Cyan
  - ⚪ **System prompts/instructions** – Gray


- **ASCII Art title screen** at startup for a stylized introduction.
- **Typing animation** simulates human-like response delivery.

### 🔊 Multimedia Integration
- Plays a **voice greeting** (WAV file) when the program launches, adding a personal touch.

### 🧠 Memory & Context Awareness
- **Tracks previously mentioned topics** and offers relevant follow-ups.
- Understands natural "yes/no" responses to recall prompts:
  > “Earlier you mentioned phishing. Would you like tips on that?”

### 💬 Sentiment Detection
- Recognizes and responds to emotions like:
  - Confusion 😕
  - Anxiety 😟
---

## 🧱 Code Structure

| File               | Purpose |
|--------------------|---------|
| `Program.cs`       | Starts and runs the chatbot. |
| `Chatbot.cs`       | Core logic, memory, response system, delegates, sentiment checks. |
| `TypingEffect.cs`  | Typing animation logic for bot messages. |
| `AsciiArt.cs`      | Renders decorative ASCII graphics. |
| `VoiceGreeting.cs` | Plays greeting audio using `System.Media`. |

---

## 🚀 How to Run

### Prerequisites
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
