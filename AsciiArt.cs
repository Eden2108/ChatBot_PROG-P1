using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;


namespace ChatBot_PROGP2
{ 
    public class AsciiArt
    { //constructor 

        // ASCII characters from dark to light
        private readonly string asciiChars = "@%#*+=-:. ";
        private string asciiArt = ""; // Stores ASCII result


        public AsciiArt()
        {
            // get the full path 
            string path_project = AppDomain.CurrentDomain.BaseDirectory;

            // replace the bin\\Debug\\
            string new_path_project = path_project.Replace("bin\\Debug\\", "");

            // Combine the project full path and image name with the format
            string full_Path = Path.Combine(new_path_project, "padlock logo.png");

            //check if the file exists
            if (!File.Exists(full_Path))
            {
                Console.WriteLine($"Error: Image file does not exist at {full_Path}");
                return;
            }

            //Convert the image into ASCII
            ConvertImageToAscii(full_Path);
        }


        private void ConvertImageToAscii(string full_Path)
        {
            //Start working on the logo with ASCII 
            Bitmap image = new Bitmap(full_Path);
            image = new Bitmap(image, new Size(60, 50));

            // Use for loop to get the height of the image
            for (int height = 0; height < image.Height; height++)
            {
                // Work on the width
                for (int width = 0; width < image.Width; width++)
                {

                    Color pixelColor = image.GetPixel(width, height);
                    int brightness = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int asciiIndex = brightness * (asciiChars.Length - 1) / 255;
                    asciiArt += asciiChars[asciiIndex]; // Append ASCII char
                }
                asciiArt += "\n"; // New line for next row
            }
        }


        // New Method: Display ASCII Art
        public void DisplayArt()
        {
            Console.WriteLine(asciiArt);

        }

    }
}








