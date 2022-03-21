using System;
using System.Text;

namespace Ex01_02
{
   public class Program
    {
        static void Main()
        {
            printHourGlass();
        }
        public static void printHourGlass()
        {
            StringBuilder hourGlassStr = new StringBuilder();
            const int k_Height = 5;
            GenerateHourGlassWithInput(hourGlassStr, 0, k_Height);
            Console.WriteLine(hourGlassStr);
        }
        public static void GenerateHourGlassWithInput(StringBuilder io_hourGlassStr, int i_row, int i_height)
        {
            string msg, msgSpace, msgStar;
            if (i_row == i_height)
            {
                return;
            }
            if (i_row < i_height / 2)
            {
                msgSpace = new string(' ', i_row);
                msgStar = new string('*', i_height - (2 * i_row));
                msg =
                    string.Format(
                        "{0}{1}",
                    msgSpace, msgStar);
                io_hourGlassStr.AppendLine(msg);
            }
            else
            {
                msgSpace = new string(' ', i_height - i_row - 1);
                msgStar = new string('*', (2 * i_row) - i_height + 2);
                msg =
                    string.Format(
                        "{0}{1}",
                    msgSpace, msgStar);
                io_hourGlassStr.AppendLine(msg);
            }
            GenerateHourGlassWithInput(io_hourGlassStr, i_row + 1, i_height);

        }
    }
}
