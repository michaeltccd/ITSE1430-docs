using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section1
{
    class Program
    {
        static void Main( string[] args )
        {
            bool notQuit;
            do
            {
                notQuit = DisplayMenu();
            } while (notQuit);

            //PlayWithStrings();
        }

        private static void PlayWithStrings()
        {
            string hoursString = "10A";

            //From string
            //int hours = Int32.Parse(hoursString);
            //int hours;
            //bool result = Int32.TryParse(hoursString, out hours);
            //bool result = Int32.TryParse(hoursString, out int hours);

            //To string
            //hoursString = hours.ToString();
            //4.75.ToString();
            //457.ToString();
            //Console.ReadLine().ToString();

            string message = "Hello\tworld";
            string filePath = "C:\\Temp\\Test";

            //Verbatim strings
            filePath = @"C:\Temp\Test";

            //Concat
            string firstName = "Bob";
            string lastName = "Smith";
            string name = firstName + " " + lastName;

            //Strings are immutable - this produces a new string
            //name = "Hello " + name;
            Console.WriteLine("Hello " + name);  // Approach 1
            Console.WriteLine("Hello {0} {1}", firstName, lastName); //Approach 2
            string str = String.Format("Hello {0} {1}", firstName, lastName); //Approach 3
            Console.WriteLine(str);

            //Approach 4
            Console.WriteLine($"Hello {firstName} {lastName}");

            //Null vs empty
            string missing = null;
            string empty = "";
            string empty2 = String.Empty;

            //Checking for empty strings
            //if (firstName.Length == 0)
            //if (firstName != null && firstName != "")
            if (!String.IsNullOrEmpty(firstName))
                Console.WriteLine(firstName);

            //Other stuff
            string upperName = firstName.ToUpper();
            string lowerName = firstName.ToLower();

            //Comparison
            bool areEqual = firstName == lastName;
            areEqual = firstName.ToLower() == lastName.ToLower();
            areEqual = String.Compare(firstName, lastName, true) == 0;

            bool startsWithA = firstName.StartsWith("A");
            bool endsWithA = firstName.EndsWith("A");
            bool hasA = firstName.IndexOf("A") >= 0;
            string subset = firstName.Substring(4);

            //Clean up
            string cleanMe = firstName.Trim(); //TrimStart, TrimEnd
            string makeLonger = firstName.PadLeft(20); //PadRight
        }

        private static bool DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("A)dd Movie");
                Console.WriteLine("E)dit Movie");
                Console.WriteLine("D)elete Movie");
                Console.WriteLine("V)iew Movies");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine();
                switch (input[0])
                {
                    case 'a':
                    case 'A': AddMovie(); return true;

                    case 'e':
                    case 'E': EditMovie(); return true;

                    case 'd':
                    case 'D': DeleteMovie(); return true;

                    case 'v':
                    case 'V': ViewMovies(); return true;

                    case 'q':
                    case 'Q': return false;

                    default:
                        Console.WriteLine("Please enter a valid value.");
                        break;
                };
            };
        }

        private static void DeleteMovie()
        {
            Console.WriteLine("DeleteMovie");
        }

        private static void ViewMovies()
        {
            Console.WriteLine("ViewMovies");
        }

        private static void EditMovie()
        {
            Console.WriteLine("EditMovie");
        }

        private static void AddMovie()
        {
            Console.WriteLine("AddMovie");
        }
    }
}
