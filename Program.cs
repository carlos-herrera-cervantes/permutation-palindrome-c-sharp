using System;

namespace PalindromePermutationConsoleApp
{
    class Program
    {
        #region snippet_Helpers

        /// <summary>Validates if the char is between a and z</summary>
        /// <param name="c">Character</param>
        /// <returns>The subtract of character minus character a</returns>
        static int GetCharNumber(char c)
        {
            int a = Convert.ToInt32('a');
            int z = Convert.ToInt32('z');
            int val = Convert.ToInt32(c);

            if (a <= val && val <= z) return val - a;

            return -1;
        }

        #endregion

        #region snippet_BruteForce

        /// <summary>Verifies if the table contains and odd number</summary>
        /// <param name="table">Array of numbers</param>
        /// <returns>If table contains and odd number returns true otherwise false</returns>
        static bool CheckMaxOneOdd(int[] table)
        {
            bool foundOdd = false;

            foreach (int count in table)
            {
                if (count % 2 == 1)
                {
                    if (foundOdd) return false;
                    foundOdd = true;
                }
            }

            return foundOdd;
        }

        /// <summary>Construct the table with occurrence of characters</summary>
        /// <param name="phrase">String</param>
        /// <returns>Array of numbers</returns>
        static int[] BuildCharFrequencyTable(string phrase)
        {
            int[] table = new int[Convert.ToInt32('z') - Convert.ToInt32('a') + 1];

            foreach (char c in phrase.ToCharArray())
            {
                int x = GetCharNumber(c);
                if (x != -1) table[x]++;
            }

            return table;
        }

        /// <summary>Verifies if string is palindrome permutation. This is a good solution but it can improve.</summary>
        /// <param name="phrase">String</param>
        /// <returns>If the string is palindrome permutation returns true otherwise false</returns>
        static bool IsPermutationOfPalindromeBruteForce(string phrase)
        {
            int[] table = BuildCharFrequencyTable(phrase);
            return CheckMaxOneOdd(table);
        }

        #endregion

        #region snippet_Optimize

        /// <summary>Verifies if string is palindrome permutation. This is better solution
        /// than the first but not the best solution that can it exists.
        /// </summary>
        /// <param name="phrase">String</param>
        /// <returns>If the string is palindrome permutation returns true otherwise false</returns>
        static bool IsPermutationOfPalindromeOptimized(string phrase)
        {
            int countOdd = 0;
            int[] table = new int[Convert.ToInt32('z') - Convert.ToInt32('a') + 1];

            foreach (char c in phrase.ToCharArray())
            {
                int x = GetCharNumber(c);

                if (x != -1)
                {
                    table[x]++;

                    if (table[x] % 2 == 1)
                    {
                        countOdd++;
                    }
                    else
                    {
                        countOdd--;
                    }
                }
            }

            return countOdd <= 1;
        }

        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("THIS PROGRAM TAKES A STRING AND VERIFIES WHETHER IS PALINDROME PERMUTATION");
            Console.Write("Enter the string: ");
            
            string phrase = Console.ReadLine();
            bool result = IsPermutationOfPalindromeOptimized(phrase);
            
            Console.WriteLine($"Is a palindrome permutation? : {result}");
        }
    }
}
