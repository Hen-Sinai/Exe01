using System;


namespace Ex01_05
{
    class Program
    {
        static int numOfDigits = 7;

        static void Main()
        {
            sevenDigitsNumber();
        }
        private static void sevenDigitsNumber()
        {
            string sevenDigitsNum = getSevenDigitsInput();
            int sevenDigitsInt = int.Parse(sevenDigitsNum);
            string msg;
            float avg;
            msg =
                string.Format(
@"The smallest digit is: {0}.
The average of the digits is: {1}.
The amount of digits divided by two is: {2}.
The amount of digits that are smaller from the unity digit is: {3}.",
                 findMinDigit(sevenDigitsNum), findAvgDigits(sevenDigitsInt,out avg),
                 amountOfDigitsDividedByTwo(sevenDigitsInt), amountOfDigitsSmallerThanUnityDigit(sevenDigitsNum));
            Console.WriteLine(msg);
        }
        private static char findMinDigit(string i_sevenDigits)
        {
            char minDigit = i_sevenDigits[0];
            for (int i = 1; i < numOfDigits; i++)
            {
                if (minDigit > i_sevenDigits[i])
                {
                    minDigit = i_sevenDigits[i];
                }
            }

            return minDigit;
        }
        private static string getSevenDigitsInput()
        {
            string sevenDigitsNummber;
            do
            {
                Console.WriteLine("Please enter a number with 7 digits");
                sevenDigitsNummber = Console.ReadLine();
            } while (!ValidSevenDigitsNum(sevenDigitsNummber));

            return sevenDigitsNummber;
        }
        private static bool ValidSevenDigitsNum(string i_number)
        {
            int numberRes;    
            bool v_sevenDigitsNum = (i_number.Length == numOfDigits &&
                                        int.TryParse(i_number, out numberRes) && numberRes >= 0);
            if (!v_sevenDigitsNum)
            {
                Console.WriteLine("Wrong input, please enter another number");
            }
            return v_sevenDigitsNum;
        }
        private static float findAvgDigits(int i_sevenDigitsNum, out float o_avg)
        {
            float sumOfDigits = i_sevenDigitsNum % 10;
            while(i_sevenDigitsNum>0)
            {
                i_sevenDigitsNum /= 10;
                sumOfDigits += i_sevenDigitsNum % 10;
            }
            o_avg = sumOfDigits / numOfDigits;
            return (sumOfDigits / numOfDigits);
        }
        private static int amountOfDigitsDividedByTwo(int i_sevenDigits)
        {
            int amountOfDigitsDividedBy2 = numOfDigits;
            while (i_sevenDigits != 0)
            {
                if ((i_sevenDigits % 10) % 2 != 0)
                {
                    amountOfDigitsDividedBy2--;
                }
                i_sevenDigits /= 10;
            }

            return (amountOfDigitsDividedBy2);
        }
        private static int amountOfDigitsSmallerThanUnityDigit(string i_sevenDigits)
        {
            int unityDigit = i_sevenDigits[0];
            int amountSmallerFromeUnity = 0;
            for (int i = 1; i < numOfDigits; i++)
            {            
                if (i_sevenDigits[i] < unityDigit)
                {
                    amountSmallerFromeUnity++;
                }
            }

            return (amountSmallerFromeUnity);
        }
    }
}
