/*
 * Copyright © Michael Taylor (Tarrant County College District)
 * All Rights Reserved
 *
 * ITSE 1430 Sample Implementation
 */
using System; 

namespace MovieLibrary.ConsoleHost
{   
    class Program 
    {
        public Program ()
        { }

        static void Main() 
        {
            bool done = false;
            do
            {
                char option = DisplayMainMenu();

                switch (option)
                {
                    case 'A': AddMovie(); break;
                    case 'V': ViewMovie(); break;
                    case 'Q': done = true; break;

                    default: DisplayError("Unknown command"); break;
                };
               
            } while (!done);
        }

        private static char DisplayMainMenu ()
        {
            Console.WriteLine("Movie Library");  
            Console.WriteLine("".PadLeft(20, '-'));

            Console.WriteLine("A) dd Movie");
            Console.WriteLine("V) iew Movie");
            Console.WriteLine("Q) uit");

            do
            {
                string input = Console.ReadLine(); 

                switch (input)
                {
                    case "A":
                    case "a": return 'A';

                    case "Q": 
                    case "q": return 'Q';

                    case "V": 
                    case "v": return 'v';
                };

                DisplayError("Invalid option");
            } while (true);
        }

        // Get movie from user
        static void AddMovie ()
        {
            var movie = new Movie();
            
            Console.Write("Enter a title: ");
            movie.Title = Console.ReadLine();

            Console.Write("Enter an optional description: ");
            movie.Description = Console.ReadLine();

            Console.Write("Enter a release year: ");
            movie.ReleaseYear = ReadInt32(Movie.MinimumReleaseYear);

            Console.Write("Enter the run length in minutes: ");
            movie.RunLength = ReadInt32(-1);
            
            Console.Write("Enter the rating: ");
            movie.Rating = Console.ReadLine();

            Console.Write("Is a Classic (Y/N)? ");
            movie.IsClassic = ReadBoolean();

            s_movie = movie;
            ViewMovie();
        }
        
        static void ViewMovie ()
        {            
            Console.WriteLine($"{s_movie.Title} ({s_movie.ReleaseYear})");
            if (s_movie.RunLength > 0)
                Console.WriteLine($"Running Time: {s_movie.RunLength} minutes");
            if (!String.IsNullOrEmpty(s_movie.Rating))
                Console.WriteLine($"MPAA Rating: {s_movie.Rating}");

            Console.WriteLine($"Classic? {(s_movie.IsClassic ? 'Y' : 'N')}");

            if (!String.IsNullOrEmpty(s_movie.Description))
                Console.WriteLine(s_movie.Description);                                                
        }

        // Reads a boolean value from the console.
        static bool ReadBoolean ()
        {
            do
            {                
                string input = Console.ReadLine();
                
                if (String.Compare(input, "Y", true) == 0)
                    return true;
                else if (String.Compare(input, "N", true) == 0)
                    return false;

                DisplayError("Please enter either Y or N");
            } while (true);
        }

        // Reads an integer value from the console.
        static int ReadInt32 ( )
        {
            return ReadInt32(Int32.MinValue);
        }

        static int ReadInt32 ( int minimumValue )
        {            
            do
            {
                var input = Console.ReadLine();

                if (Int32.TryParse(input, out var result)) 
                {
                    //Make sure it is at least minValue
                    if (result >= minimumValue)
                        return result;
                    else
                        DisplayError("Value must be at least " + minimumValue);
                } else
                    DisplayError("Value must be numeric");
            } while (true);
        }

        private static void DisplayError ( string message )
        {
            Console.WriteLine(message);
        }

        private static Movie s_movie;
    }
}
