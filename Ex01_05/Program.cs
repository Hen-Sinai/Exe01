using System;


namespace Ex01_05
{
    class Program
    {
        private static int s_NumOfDigits = 7;

        static void Main()
        {
            sevenDigitsNumber();
        }

        private static void sevenDigitsNumber()
        {
            string sevenDigitsNum = getSevenDigitsInput();
            int sevenDigitsInt = int.Parse(sevenDigitsNum);
            int minDigit = findMinDigit(sevenDigitsNum);
            int amountOfDigitsDividedByTwo = countDigitsDividedByTwo(sevenDigitsInt);
            int amountOfDigitsSmallerThanUnityDigit = countDigitsSmallerThanUnityDigit(sevenDigitsNum);
            float avgOfDigits = findAvgDigits(sevenDigitsInt);
            string msg;
            msg =
                string.Format(
@"The smallest digit is: {0}.
The average of the digits is: {1}.
The amount of digits divided by two is: {2}.
The amount of digits that are smaller from the unity digit is: {3}.",
                 minDigit, avgOfDigits, amountOfDigitsDividedByTwo, amountOfDigitsSmallerThanUnityDigit);
            Console.WriteLine(msg);
        }

        private static char findMinDigit(string i_sevenDigits)
        {
            char minDigit = i_sevenDigits[0];
            for (int i = 1; i < s_NumOfDigits; i++)
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
            } while (!validSevenDigitsNum(sevenDigitsNummber));

            return sevenDigitsNummber;
        }

        private static bool validSevenDigitsNum(string i_number)
        {
            int numberRes;
            bool isSevenDigitsNumValid = i_number.Length == s_NumOfDigits &&
                                        int.TryParse(i_number, out numberRes) && numberRes > 0;
            if (!isSevenDigitsNumValid)
            {
                Console.WriteLine("Wrong input, please enter another number");
            }

            return isSevenDigitsNumValid;
        }

        private static float findAvgDigits(int i_sevenDigitsNum)
        {
            float sumOfDigits = i_sevenDigitsNum % 10;
            float digitsAvg;
            while (i_sevenDigitsNum > 0)
            {
                i_sevenDigitsNum /= 10;
                sumOfDigits += i_sevenDigitsNum % 10;
            }

            digitsAvg = sumOfDigits / s_NumOfDigits;
            
            return digitsAvg;
        }

        private static int countDigitsDividedByTwo(int i_sevenDigits)
        {
            int amountOfDigitsDividedBytwo = s_NumOfDigits;
            while (i_sevenDigits != 0)
            {
                if ((i_sevenDigits % 10) % 2 != 0)
                {
                    amountOfDigitsDividedBytwo--;
                }

                i_sevenDigits /= 10;
            }

            return amountOfDigitsDividedBytwo;
        }

        private static int countDigitsSmallerThanUnityDigit(string i_sevenDigits)
        {
            int unityDigit = i_sevenDigits[0];
            int amountSmallerFromeUnity = 0;
            for (int i = 1; i < s_NumOfDigits; i++)
            {
                if (i_sevenDigits[i] < unityDigit)
                {
                    amountSmallerFromeUnity++;
                }
            }

            return amountSmallerFromeUnity;
        }
    }
}