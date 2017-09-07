/*
 * Your Name
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nile.Host 
{
    class Program 
    {
        // A single line comment
        static void Main( string[] args )
        {
            int hours = 5;
            hours = 10;

            //+ - * / %
            //hours = (4 + 5) * 7.25 / 4;            
            //hours = Math.Min(hours, 56);

            string name = "John";

            //Concat
            name = name + " Williams";

            //Copy
            name = "Hello";

            bool areEqual = name == "Hello";
            bool areNotEqual = name != "Hello";

            //Verbatim string - no escape sequences
            string path = @"C:\Temp\test.txt";

            //Option 1
            string names = "John" + " William" + " Murphy" + " Charles" + " Henry";

            //Option 2
            StringBuilder builder = new StringBuilder();
            builder.Append("John");
            builder.Append(" William");
            string names2 = builder.ToString();

            //Option 3
            string names3 = String.Concat("John", " William", " Murphy", " Charles", " Henry");

            //String formatting
            //John worked 10 hours
            string format1 = name + " worked " + hours.ToString() + " hours";

            string format2 = String.Format("{0} worked for {1} hours", name, hours);
        }
    }
}
