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
            string[] binarySeriesArr = new string[s_NumberOfSeries];
            Console.WriteLine("Please enter 3 numbers");
            for (int i = 0; i < s_NumberOfSeries; i++)
            {
                binarySeriesArr[i] = Console.ReadLine();
                if (!isBinaryNumberValid(binarySeriesArr[i]))
                {
                    i--;
                    Console.WriteLine("Wrong input, please enter another number");
                }
            }

            return binarySeriesArr;
        }

        private static bool isBinaryNumberValid(string i_binaryNumber)
        {
            bool v_VaildNumber;
            char currentDigit;
            v_VaildNumber = i_binaryNumber.Length == s_NumberLen;
            if (v_VaildNumber)
            {
                for (int i = 0; i < s_NumberLen; i++)
                {
                    currentDigit = i_binaryNumber[i];
                    if (currentDigit != (char)eBinaryDigits.Zero && currentDigit != (char)eBinaryDigits.One)
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
            for (int i = 0; i < s_NumberLen; i++)
            {
                if (i_binaryNumber[i] == (char)eBinaryDigits.One)
                {
                    amountOfZeros++;
                }
            }

            return amountOfZeros;
        }

        private static void calculateAvgDigitApperiences(string[] i_binaryNumber, out float o_avgOfZeros, out float o_avgOfOne)
        {
            float amountOfZeros = 0;
            float amountOfOne;
            int k_AmountOfAllDigits = s_NumberOfSeries * s_NumberLen;
            for (int i = 0; i < s_NumberOfSeries; i++)
            {
                amountOfZeros += apperiencesOfZero(i_binaryNumber[i]);
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

        private static void avgDigitApperiences(string[] i_binaryNumber)
        {
            float avgOfZeros, avgOfOne;
            calculateAvgDigitApperiences(i_binaryNumber, out avgOfZeros, out avgOfOne);
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

        private static int amountOfExpTwoNumbers(int[] i_decNumber)
        {
            int counterOfExpOfTwoNumbers = 0;
            for (int i = 0; i < s_NumberOfSeries; i++)
            {
                if (Math.Log(i_decNumber[i], 2) % 1 == 0)
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

        private static void expOfTwoNumbers(int[] i_decNumber)
        {
            int counterOfExpOfTwoNumbers;
            counterOfExpOfTwoNumbers = amountOfExpTwoNumbers(i_decNumber);
            printAmountOfExpTwoNumbers(counterOfExpOfTwoNumbers);
        }

        private static bool isPolindrom(string i_decNumber)
        {
            bool v_polindrom = true;
            int numberLen = i_decNumber.Length;
            for (int i = 0; i < numberLen / 2 && v_polindrom; i++)
            {
                if (i_decNumber[i] != i_decNumber[(numberLen - 1) - i * 2])
                {
                    v_polindrom = !v_polindrom;
                }
            }

            return v_polindrom;
        }

        private static int amountOfPlindromNumbers(int[] i_decNumber)
        {
            int counterOfPlindromNumbers = 0;
            for (int i = 0; i < s_NumberOfSeries; i++)
            {
                if (isPolindrom(i_decNumber[i].ToString()))
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

        private static void plindromNumbers(int[] i_decNumber)
        {
            int countOfPlindromNumbers;
            countOfPlindromNumbers = amountOfPlindromNumbers(i_decNumber);
            printAmountOfPlindromNumbers(countOfPlindromNumbers);
        }

        private static bool isDecimalNumberDigitsIncrease(int i_decNumber)
        {
            bool v_NumberDigitsIncrease = true;
            int lastModuloTen = i_decNumber % 10;
            i_decNumber /= 10;
            while (i_decNumber > 0 && v_NumberDigitsIncrease)
            {
                if (i_decNumber % 10 >= lastModuloTen)
                {
                    v_NumberDigitsIncrease = !v_NumberDigitsIncrease;
                }
                lastModuloTen = i_decNumber % 10;
                i_decNumber /= 10;
            }

            return v_NumberDigitsIncrease;
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