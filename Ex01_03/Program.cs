using System;
using Ex01_02;
using System.Text;


namespace Ex01_03
{
    class Program
    {
        static public void Main()
        {
            advancedHourGlass();
        }
        private static bool validHourGlassInput(string i_height)
        {
            bool v_validHeight;
            int number;
            v_validHeight = int.TryParse(i_height, out number) && number > 0;
            if(!v_validHeight)
            {
                Console.WriteLine("Wrong input, please enter another number");
            }
            return v_validHeight;
        }
        private static void advancedHourGlass()
        {
            int validHeight;
            StringBuilder hourGlassStr = new StringBuilder();
            validHeight = getUserHeightInput();
            if (validHeight % 2 ==0)
            {
                validHeight += 1;
            }
            Ex01_02.Program.GenerateHourGlassWithInput(hourGlassStr, 0, validHeight);
            Console.WriteLine(hourGlassStr);
        }

        private static int getUserHeightInput()
        {
            string inputHeight;
            do
            {
                Console.WriteLine("Please enter a number:");
                inputHeight = Console.ReadLine();

            } while (!validHourGlassInput(inputHeight));

            return (int.Parse(inputHeight));
        }

    }
}