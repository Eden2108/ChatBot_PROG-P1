using System;
using System.IO;
using System.Media;

namespace ChatBot_PROGP2
{
    public class VoiceGreeting
    {
        public VoiceGreeting()
        {
            // Constructor can be used for logging or initial checks if needed
        }

        public void PlayVoiceGreeting(string fileName)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.Combine(basePath, fileName);

            if (!File.Exists(fullPath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Error] Audio file not found: {fullPath}");
                Console.ResetColor();
                return;
            }

            try
            {
                using (SoundPlayer player = new SoundPlayer(fullPath))
                {
                    player.PlaySync();  // Play to completion before continuing
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] Could not play sound: {ex.Message}");
            }
        }
    }
}
