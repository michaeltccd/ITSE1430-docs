/*
 * ITSE 1430
 * 
 * Section 1
 */
using System;

namespace Nile.Host
{
    class Program
    {
        static void Main( string[] args )
        {
            bool quit = false;
            while (!quit)
            {
                //Display menu
                char choice = DisplayMenu();

                //Process menu selection
                switch (choice)
                {
                    case 'l':
                    case 'L': ListProducts(); break;

                    case 'a':
                    case 'A': AddProduct(); break;

                    case 'q':
                    case 'Q': quit = true; break;
                };
            };
        }

        //Add a product
        static void AddProduct()
        {
            //Get name
            _name = ReadString("Enter name: ", true);

            //Get price
            _price = ReadDecimal("Enter price: ", 0);

            //Get description
            _description = ReadString("Enter optional description: ", false);
        }

        //Read a decimal value
        private static decimal ReadDecimal ( string message, decimal minValue )
        {
            do
            {
                Console.Write(message);

                string value = Console.ReadLine();

                //if (Decimal.TryParse(value, out decimal result) && result >= minValue)
                //    return result;

                if (Decimal.TryParse(value, out decimal result))
                {
                    //If not required or not empty
                    if (result >= minValue)
                        return result;
                };

                Console.WriteLine("Value must be >= {0}", minValue);
            } while (true);
        }

        //Read a string
        private static string ReadString( string message, bool isRequired )
        {
            do
            {
                Console.Write(message);

                string value = Console.ReadLine();

                //If not required or not empty
                if (!isRequired || value != "")
                    return value;

                Console.WriteLine("Value is required");
            } while (true);
        }

        private static char DisplayMenu()
        {
            do
            {
                Console.WriteLine("L)ist Products");
                Console.WriteLine("A)dd Product");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine();

                if (input == "L" || input == "l")
                    return input[0];
                else if (input == "A" || input == "a")
                    return input[0];
                else if (input == "Q" || input == "q")
                    return input[0];
                
                Console.WriteLine("Please choose a valid option");
            } while (true);            
        }

        //List the products
        static void ListProducts ()
        {
            //Are there any products?
            if (_name != null && _name != "")
            {
                //Display a product
                Console.WriteLine(_name);
                Console.WriteLine(_price);
                Console.WriteLine(_description);
            } else
                Console.WriteLine("No products");
        }

        //Data for a product
        static string _name;
        static decimal _price;
        static string _description;

        static void PlayingWithPrimitives ()
        {
            //Primitive
            decimal unitPrice = 10.5M;

            //Real declaration
            //System.Decimal unitPrice2 = 10.5M;
            Decimal unitPrice2 = 10.5M;

            //Current time
            DateTime now = DateTime.Now;

            System.Collections.ArrayList items;
        }

        static void PlayingWithVariables ()
        {
            //Single decls
            int hours = 0;
            //Don't
            //int hours;
            //hours = 0;

            double rate = 10.25;

            //Still not assigned
            //if (false)
            //    hours = 0;

            int hours2 = hours;

            //Multiple decls
            string firstName, lastName;

            //string @class;

            //Single assignment
            firstName = "Bob";
            lastName = "Miller";

            //Multiple assignment
            firstName = lastName = "Sue";

            //Math ops
            int x = 0, y = 10;
            int add = x + y;
            int subtract = x - y;
            int multiply = x * y;
            int divide = x / y;
            int modulos = x % y;

            //x = x + 10;
            x += 10;
            double ceiling = Math.Ceiling(rate);
            double floor = ceiling;

        }
    }
}
