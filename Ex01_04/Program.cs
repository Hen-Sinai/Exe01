using System;

namespace Ex01_04
{
    class Program
    {
        private static int s_StringLen = 8;

        static public void Main()
        {
            stringAnalyser();
        }

        private static void stringAnalyser()
        {
            string inputStr;
            inputStr = getUserStringInput();
            printIsPolindrom(inputStr);
            if (int.TryParse(inputStr, out int number))
            {
                printIsDividedByThree(inputStr);
            }
            else
            {
                lowercaseLetters(inputStr);
            }
        }

        private static string getUserStringInput()
        {
            string inputStr;
            do
            {
                Console.WriteLine("Please enter a string that contains only letters or digits");
                inputStr = Console.ReadLine();
            } while (!validStringInput(inputStr));

            return inputStr;
        }

        private static bool validStringInput(string i_str)
        {
            bool v_validStr, isStringContainDigit = false,
                 isStringContainLetter = false, isStringContainSymbol = false;
            v_validStr = int.TryParse(i_str, out int number) && i_str.Length == s_StringLen;
            if (!v_validStr)
            {
                isStringContainDigit = checkStringContainDigit(i_str);
                isStringContainLetter = checkStringContainLetter(i_str);
                isStringContainSymbol = checkStringContainSymbol(i_str);
                v_validStr = !(isStringContainDigit && isStringContainLetter) && !isStringContainSymbol && i_str.Length == s_StringLen;
            }

            return v_validStr;
        }

        private static bool checkStringContainDigit(string i_str)
        {
            bool isCharDigit = false;
            foreach (char character in i_str)
            {
                isCharDigit = int.TryParse(character.ToString(), out int number);
                if (isCharDigit)
                {
                    break;
                }
            }

            return isCharDigit;
        }

        private static bool checkStringContainLetter(string i_str)
        {
            bool isCharLetter = false;
            foreach (char character in i_str)
            {
                isCharLetter = Char.IsLetter(character);
                if (isCharLetter)
                {
                    break;
                }
            }

            return isCharLetter;
        }

        private static bool checkStringContainSymbol(string i_str)
        {
            bool isCharSymbol = false;
            foreach (char character in i_str)
            {
                isCharSymbol = !(Char.IsLetter(character)) &&
                    !int.TryParse(character.ToString(), out int number);
                if (isCharSymbol)
                {
                    break;
                }
            }

            return isCharSymbol;
        }

        private static bool checkPolindrom(string i_str, int i_margin)
        {
            bool isPolindrom = true;
            int offset = 1;
            if (i_str.Length - i_margin != 0)
            {
                if (i_str[0] != i_str[i_str.Length - (i_margin + 1)])
                {
                    isPolindrom = !isPolindrom;
                }

                checkPolindrom(i_str.Substring(offset), i_margin + offset); ;
            }

            return isPolindrom;
        }

        private static void printIsPolindrom(string i_str)
        {
            string msg;
            msg = string.Format(
             "Is the string a polindrom: {0}", checkPolindrom(i_str, 0));
            Console.WriteLine(msg);
        }

        private static bool checkDividedByThree(string i_str)
        {
            int number;
            bool isDIvidedByThree = int.TryParse(i_str, out number) && number % 3 == 0;
            
            return isDIvidedByThree;
        }

        private static void printIsDividedByThree(string i_str)
        {
            string msg;
            msg = string.Format(
             "Is the number divided by three: {0}", checkDividedByThree(i_str));
            Console.WriteLine(msg);
        }

        private static bool checkLowercase(char i_letter)
        {
            bool isLetterLowerCase;
            isLetterLowerCase = i_letter == Char.ToLower(i_letter);

            return isLetterLowerCase;
        }

        private static int countLowercaseLetters(string i_str)
        {
            int countLowerCaseLetters = 0;
            foreach (char character in i_str)
            {
                if (checkLowercase(character))
                {
                    countLowerCaseLetters++;
                }
            }

            return countLowerCaseLetters;
        }

        private static void printAmountOfLowercaseLetters(int i_amountOfLowerCaseLetters)
        {
            string msg;
            msg = string.Format(
             "The amount of lowercase letters is: {0}", i_amountOfLowerCaseLetters);
            Console.WriteLine(msg);
        }

        private static void lowercaseLetters(string i_str)
        {
            int countLowerCaseLetters = countLowercaseLetters(i_str);
            printAmountOfLowercaseLetters(countLowerCaseLetters);
        }
    }
}