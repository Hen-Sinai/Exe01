﻿using System;

namespace Ex01_04
{
    class Program
    {
        static int s_StringLen = 8;
        static public void Main()
        {
            stringAnalyser();
        }

        private static void stringAnalyser()
        {
            string inputStr;
            int number;
            inputStr = getUserStringInput();
            printIsPolindrom(inputStr);
            if (int.TryParse(inputStr, out number))
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
            bool v_validStr, isStringContainDigit = false, isStringContainLetter = false, isStringContainSymbol = false;
            int number;
            v_validStr = int.TryParse(i_str, out number) && i_str.Length == s_StringLen;
            if (!v_validStr)
            {
                isStringContainDigit = checkStringContainDigit(i_str);
                isStringContainLetter = checkStringContainLetter(i_str);
                isStringContainSymbol = checkStringContainSymbol(i_str);
                v_validStr = !(isStringContainDigit && isStringContainLetter) && !isStringContainSymbol;
            }

            return v_validStr;
        }

        private static bool checkStringContainDigit(string i_str)
        {
            bool isCharDigit = false;
            int number;
            for (int i = 0; i < i_str.Length && !isCharDigit; i++)
            {
                isCharDigit = int.TryParse(i_str[i].ToString(), out number);
            }

            return isCharDigit;
        }

        private static bool checkStringContainLetter(string i_str)
        {
            bool isCharLetter = false;
            for (int i = 0; i < i_str.Length && !isCharLetter; i++)
            {
                isCharLetter = checkEnglishLetter(i_str[i]);
            }

            return isCharLetter;
        }

        private static bool checkStringContainSymbol(string i_str)
        {
            bool isCharSymbol = false;
            int number;
            for (int i = 0; i < i_str.Length && !isCharSymbol; i++)
            {
                isCharSymbol = !(checkEnglishLetter(i_str[i])) && !int.TryParse(i_str[i].ToString(), out number);
            }

            return isCharSymbol;
        }

        private static bool checkPolindrom(string i_str, int i_margin)
        {
            bool isPolindrom = true;
            if (i_str.Length - i_margin == 0)
            {
                return isPolindrom;
            }
            if (i_str[0] != i_str[i_str.Length - (i_margin + 1)])
            {
                return !isPolindrom;
            }

            return checkPolindrom(i_str.Substring(1), i_margin + 1); ;
        }

        private static void printIsPolindrom(string i_str)
        {
            string msg;
            msg = string.Format(
             "Is the number a polindrom: {0}", checkPolindrom(i_str, 0));
            Console.WriteLine(msg);
        }
        private static bool checkDividedByThree(string i_str)
        {
            int number;
            return int.TryParse(i_str, out number) && number % 3 == 0;
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
            return i_letter == Char.ToLower(i_letter);
        }

        private static bool checkEnglishLetter(char i_letter)
        {
            return (i_letter >= 'A' && i_letter <= 'Z') || (i_letter >= 'a' && i_letter <= 'z');
        }

        private static int countLowercaseLetters(string i_str)
        {
            int countLowerCaseLetters = 0;
            for (int i = 0; i < i_str.Length; i++)
            {
                if (checkLowercase(i_str[i]))
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