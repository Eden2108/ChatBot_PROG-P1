using System;
using System.IO;
using System.Media;

namespace ChatBot_PROGP1
{ //Handles the voice greeting sound played when the chatbot starts
    public class VoiceGreeting
    { //Constructor 
        public VoiceGreeting()
        {
            //Get the full path of the project
            string project_location = AppDomain.CurrentDomain.BaseDirectory;

            //Check if it is getting the Directory
            Console.WriteLine($"Project Directory: {project_location}");

        }//End of Constructor

        //Method to play the greeting sound
        public void Play_wav(string full_path)
        {
            // try and catch 
            try
            {
                using (SoundPlayer player = new SoundPlayer(full_path)) //Play the sound
                {
                    player.PlaySync(); //To Play the sound till end of use
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }//end of try and catch
        }
        // Public method to play a greeting file
        public void PlayVoiceGreeting(string file_Name)
        {
            string projectLocation = AppDomain.CurrentDomain.BaseDirectory;
            string full_path = Path.Combine(projectLocation, file_Name);

            if (File.Exists(full_path))
            {
                Play_wav(full_path);
            }
            else
            {
                Console.WriteLine($"Error: File '{file_Name}' not found at {full_path}");
            }

        }
    }
}
