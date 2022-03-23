using System;

namespace Ex01_01
{
    public enum eBinaryDigits
    {
        Zero = '0',
        One = '1'
    }

    class Program
    {
        static int s_NumberOfSeries = 3;
        static int s_NumberLen = 8;

        static void Main()
        {
            binarySeries();
        }

        private static void binarySeries()
        {
            string[] binaryNumArry = getBinarySeriesInput();
            int[] decimalNumArry = parseStringArrToIntArr(binaryNumArry);
            avgDigitApperiences(binaryNumArry);
            expOfTwoNumbers(decimalNumArry);
            plindromNumbers(decimalNumArry);
            minNumber(decimalNumArry);
            maxNumber(decimalNumArry);
        }

        private static string[] getBinarySeriesInput()
        {
            int numberIndex = 0;
            string[] binarySeriesArr = new string[s_NumberOfSeries];
            Console.WriteLine("Please enter 3 numbers");
            while (numberIndex != s_NumberOfSeries)
            {
                binarySeriesArr[numberIndex] = Console.ReadLine();
                if (!isBinaryNumberValid(binarySeriesArr[numberIndex]))
                {
                    Console.WriteLine("Wrong input, please enter another number");
                }
                else
                {
                    numberIndex++;
                }
            }

            return binarySeriesArr;
        }

        private static bool isBinaryNumberValid(string i_binaryNumber)
        {
            bool v_VaildNumber;
            v_VaildNumber = i_binaryNumber.Length == s_NumberLen;
            if (v_VaildNumber)
            {
                foreach (char digit in i_binaryNumber)
                {
                    if (digit != (char)eBinaryDigits.Zero && digit != (char)eBinaryDigits.One)
                    {
                        v_VaildNumber = !v_VaildNumber;
                        break;
                    }
                }
            }

            return v_VaildNumber;
        }

        private static int apperiencesOfZero(string i_binaryNumber)
        {
            int amountOfZeros = 0;
            foreach (char digit in i_binaryNumber)
            {
                if (digit == (char)eBinaryDigits.Zero)
                {
                    amountOfZeros++;
                }
            }

            return amountOfZeros;
        }

        private static void calculateAvgDigitApperiences(string[] i_binaryNumbers, out float o_avgOfZeros, out float o_avgOfOne)
        {
            float amountOfZeros = 0;
            float amountOfOne;
            int k_AmountOfAllDigits = s_NumberOfSeries * s_NumberLen;
            foreach (string binaryNumber in i_binaryNumbers)
            {
                amountOfZeros += apperiencesOfZero(binaryNumber);
            }

            amountOfOne = k_AmountOfAllDigits - amountOfZeros;
            o_avgOfZeros = amountOfZeros / k_AmountOfAllDigits;
            o_avgOfOne = amountOfOne / k_AmountOfAllDigits;
        }

        private static void printAvgApperiences(float i_avgOfZeros, float i_avgOfOne)
        {
            string msg;
            msg =
                string.Format(
@"The average number of '0' digits in the binary number is {0}.
The average number of '1' digits in the binary number is {1}.",
                i_avgOfZeros, i_avgOfOne);
            Console.WriteLine(msg);
        }

        private static void avgDigitApperiences(string[] i_binaryNumbers)
        {
            float avgOfZeros, avgOfOne;
            calculateAvgDigitApperiences(i_binaryNumbers, out avgOfZeros, out avgOfOne);
            printAvgApperiences(avgOfZeros, avgOfOne);
        }

        private static int convertBinaryNumberToDec(string i_binaryNumber)
        {
            int decNumber = 0;
            int currentDigit;
            for (int i = 0; i < s_NumberLen; i++)
            {
                currentDigit = charToInt(i_binaryNumber[s_NumberLen - i - 1]);
                if (currentDigit == charToInt((char)eBinaryDigits.One))
                {
                    decNumber += (int)Math.Pow(2, i);
                }
            }

            return decNumber;
        }

        private static int amountOfExpTwoNumbers(int[] i_decimalNumbers)
        {
            int counterOfExpOfTwoNumbers = 0;
            foreach (int binaryNumber in i_decimalNumbers)
            {
                if (Math.Log(binaryNumber, 2) % 1 == 0)
                {
                    counterOfExpOfTwoNumbers++;
                }
            }

            return counterOfExpOfTwoNumbers;
        }

        private static void printAmountOfExpTwoNumbers(int i_amountOfExpTwoNumbers)
        {
            string msg;
            msg = string.Format(
                "The amount of numbers that are exponent of two are: {0}",
                i_amountOfExpTwoNumbers);
            Console.WriteLine(msg);
        }

        private static void expOfTwoNumbers(int[] i_decNumbers)
        {
            int counterOfExpOfTwoNumbers;
            counterOfExpOfTwoNumbers = amountOfExpTwoNumbers(i_decNumbers);
            printAmountOfExpTwoNumbers(counterOfExpOfTwoNumbers);
        }

        private static bool isPolindrom(string i_decimalNumber)
        {
            bool v_polindrom = true;
            int numberLen = i_decimalNumber.Length;
            for (int i = 0; i < numberLen / 2 && v_polindrom; i++)
            {
                if (i_decimalNumber[i] != i_decimalNumber[(numberLen - 1) - i * 2])
                {
                    v_polindrom = !v_polindrom;
                }
            }

            return v_polindrom;
        }

        private static int amountOfPlindromNumbers(int[] i_decimalNumbers)
        {
            int counterOfPlindromNumbers = 0;
            foreach (int binaryNumber in i_decimalNumbers)
            {
                if (isPolindrom(binaryNumber.ToString()))
                {
                    counterOfPlindromNumbers++;
                }
            }

            return counterOfPlindromNumbers;
        }

        private static void printAmountOfPlindromNumbers(int i_amountOfPlindromNumbers)
        {
            string msg;
            msg = string.Format(
              "The amount of polindrom numbers are: {0}", i_amountOfPlindromNumbers);
            Console.WriteLine(msg);
        }

        private static void plindromNumbers(int[] i_decNumbers)
        {
            int countOfPlindromNumbers;
            countOfPlindromNumbers = amountOfPlindromNumbers(i_decNumbers);
            printAmountOfPlindromNumbers(countOfPlindromNumbers);
        }

        private static int[] parseStringArrToIntArr(string[] i_Numbers)
        {
            int[] DecimalNumbersSeriesArr = new int[s_NumberOfSeries];
            for (int i = 0; i < s_NumberOfSeries; i++)
            {
                DecimalNumbersSeriesArr[i] = convertBinaryNumberToDec(i_Numbers[i]);
            }

            return DecimalNumbersSeriesArr;
        }

        private static int findMinNumber(int[] i_decNumbers)
        {
            int minNumber = i_decNumbers[0];
            for (int i = 1; i < s_NumberOfSeries; i++)
            {
                if (i_decNumbers[i] < minNumber)
                {
                    minNumber = i_decNumbers[i];
                }
            }

            return minNumber;
        }

        private static void printMinNumber(int i_minNumber)
        {
            string msg;
            msg = string.Format(
             "The minimum number is: {0}", i_minNumber);
            Console.WriteLine(msg);
        }

        private static void minNumber(int[] i_decNumbers)
        {
            int minNumber;
            minNumber = findMinNumber(i_decNumbers);
            printMinNumber(minNumber);
        }

        private static int findMaxNumber(int[] i_decNumbers)
        {
            int maxNumber = i_decNumbers[0];
            for (int i = 1; i < s_NumberOfSeries; i++)
            {
                if (i_decNumbers[i] > maxNumber)
                {
                    maxNumber = i_decNumbers[i];
                }
            }

            return maxNumber;
        }

        private static void printMaxNumber(int i_maxNumber)
        {
            string msg;
            msg = string.Format(
             "The maximum number is: {0}", i_maxNumber);
            Console.WriteLine(msg);
        }

        private static void maxNumber(int[] i_decNumbers)
        {
            int maxNumber;
            maxNumber = findMaxNumber(i_decNumbers);
            printMaxNumber(maxNumber);
        }

        private static int charToInt(char i_char)
        {
            return (int)(i_char - '0');
        }
    }
}