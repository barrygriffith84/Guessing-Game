using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.TextWriter
{
    internal class TextWriter
    {

        private readonly string _fullPath;

        //File path must end with a forward slash.
        internal TextWriter(string filePath, string fileName)
        {
            _fullPath = filePath + fileName;
        }


        internal void WriteText(string stringToWrite)
        { 
                using (StreamWriter writer = File.AppendText(_fullPath))
                {
                    writer.WriteLine(stringToWrite);
                }
        }

        internal List<string> GetAllLines()
        {
            List<string> allLines = File.ReadAllLines(_fullPath).ToList();

            return allLines;
        }

        internal int GetNumberOfLinesFromTextFile()
        {
            int numberOfLines = 0;

            using (StreamReader reader = new StreamReader(_fullPath))
            {
                string line;
                
                while ((line = reader.ReadLine()) != null)
                {
                    numberOfLines++;
                }
            }

            return numberOfLines;
        }
    }
}
