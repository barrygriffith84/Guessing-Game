using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.Auth
{
    internal class User
    {
        public string userName { get; set; }

        public string hashedPassword { get; set; }

        public string guid { get; set; }

        public int gamesPlayed { get; set; }

        public int totalGuesses { get; set; }

        public int wins { get; set; }

        public int losses { get; set; }

        //The line number where the user is in the text file.
        public int lineNumber { get; set; }

    }
}
