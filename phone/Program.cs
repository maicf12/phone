using System;
using System.Text;

namespace Phone
{
    class Program
    {

        public static string Phonepad(string input)
        {
            StringBuilder output = new StringBuilder();
            char previous = '\0'; // previous key
            int press = 0;  //this is for the iterations of keys

            foreach (char c in input)
            {
                if (c == '#')
                {
                    break;  //breaks with a #
                }
                if (c == '*')
                {
                    if (output.Length > 0)
                    {
                        output.Length = output.Length - 1; // removes last one with a *
                        continue;
                    }
                }

                if (char.IsDigit(c) && c != '0' && c != '1')
                {
                    if (c == previous)
                    {
                        press = press + 1; //same key is pressed, iterations go up by 1
                    }
                    else
                    {
                        if (previous != '\0') //if the same key is pressed, processes the last one
                        {
                            output.Append(GetChar(previous, press));
                        }
                        previous = c;
                        press = 1;
                    }
                }
            }

            if (previous != '\0') //processes last key if wasn't added yet
            {
                output.Append(GetChar(previous, press));
            }

            return output.ToString();
        }

        private static char GetChar(char key, int press)
        {
            switch(key) //I used a switch for the pressed keys
            {
                case '2':
                    return GetCharString("ABC", press);
                case '3':
                    return GetCharString("DEF", press);
                case '4':
                    return GetCharString("GHI", press);
                case '5':
                    return GetCharString("JKL", press);
                case '6':
                    return GetCharString("MNO", press);
                case '7':
                    return GetCharString("PQRS", press);
                case '8':
                    return GetCharString("TUV", press);
                case '9':
                    return GetCharString("WXYZ", press);
                default:
                    return ' '; // returns space if not valid key
            }
        }

        private static char GetCharString(string letter, int press)
        {
            int index = (press - 1) % letter.Length; //get the index from the key presses
            return letter[index];
        }
        public

        static void Main(string[] args)
        {
            string input = " ";
            string output = " ";
            //this while asks for input till the user puts a # at the end
            do
            {
                Console.WriteLine("Enter keys and press # at the end: ");
                input = Console.ReadLine();
            }
            while (!input.EndsWith("#"));
            output = Phonepad(input); //process the keys
            Console.WriteLine(output); //prints
        }
    }
}