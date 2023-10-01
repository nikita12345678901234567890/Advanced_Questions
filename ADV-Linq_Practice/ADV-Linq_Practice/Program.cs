using System.Collections;
using System.Linq;

namespace ADV_Linq_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            1 liner
            use => (expression bodied member)
            Built-in LINQ (no loop, etc)
            re-use functions you just made
            write all extension methods


            -[string].isPalindrome
            -[string].isAnagram
            -[char].IsBinaryPalindrome

            Hints:
            Enumerable
            Efficiency is NOT a thing


            FollowUp:
            Efficient palindrome
            1 loop, no if statements
            */
            bool yeet1 = isAnagram("cat", "not cat");
            bool yeet2 = isAnagram("not cat", "cat");
            bool yeet3 = isAnagram("cat", "tac");

            bool yeet4 = isPalindrome("cat");
            bool yeet5 = isPalindrome("fishhsif");

            bool yeet6 = isBinaryPalindrome('B');
            bool yeet7 = isBinaryPalindrome('C');
            bool yeet8 = isBinaryPalindrome('f');
            bool yeet9 = isBinaryPalindrome('g');

        }

        static bool isPalindrome(string input) => input == string.Concat(input.Reverse());

        static bool isAnagram(string input, string other) => input.Except(other).Count() == 0 && other.Except(input).Count() == 0;

        static bool isBinaryPalindrome(char input) => Convert.ToInt32(new String(Convert.ToString(input, 2).Reverse().ToArray()), 2) == Convert.ToInt32(new String(Convert.ToString(input, 2).ToArray()), 2) >> 1;
    }
}