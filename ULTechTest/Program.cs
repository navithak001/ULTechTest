using System;

namespace ProgrammingSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const string _alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string _vowels = "aeiou";

            //===========Process single Input===================
            //Console.WriteLine("Programming Test!");
            //Console.WriteLine("1) Next Letter: Please enter a string to convert.");            
            //string _input = Console.ReadLine();
            //string _nextLetter = NextLetter(_input);
            //Console.WriteLine("Output: " +_nextLetter);
            //Console.WriteLine("2) Starred Letters: Please enter a string to validate.");
            //string _input2 = Console.ReadLine();
            //bool _res = StarredLetters(_input2);
            //Console.WriteLine("Output: " +_res);
            //Console.ReadLine();

            //============Process Multiple Inputs dynamically====
            Console.WriteLine("Programming Test!");
            while (true)
            {
                Console.WriteLine("Please enter N to test NextLetter, enter S to test Starred Letters");
                Console.WriteLine("To stop the programme, enter 'exit'");
                string userInput = Console.ReadLine();
                if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                if (userInput.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("1) Next Letter: Please enter a string to convert.");
                    string _input3 = Console.ReadLine();
                    string _nextLetter1 = NextLetter(_input3);
                    Console.WriteLine("Output: " + _nextLetter1);
                }
                else if (userInput.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("2) Starred Letters: Please enter a string to validate.");
                    string _input4 = Console.ReadLine();
                    bool _res1 = StarredLetters(_input4);
                    Console.WriteLine("Output: " + _res1);
                }
            }

            string NextLetter(string input)
            {
                string _result = string.Empty;
                if (!string.IsNullOrEmpty(input))
                {
                    char[] _inputCharArray = input.ToCharArray();
                    foreach (char ch in _inputCharArray)
                    {
                        if (ch >= 'a' && ch <= 'z' || ch >= 'A' && ch <= 'Z')
                        {
                            int alphabetIndex = _alphabets.IndexOf(ch.ToString(), StringComparison.InvariantCultureIgnoreCase);
                            int new_index = (alphabetIndex + 2) % _alphabets.Length;
                            char newChar = _alphabets[new_index];
                            newChar = char.IsLower(ch) ? char.ToLower(newChar) : newChar;
                            bool isVowel = _vowels.IndexOf(newChar.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0;
                            if (isVowel)
                            {
                                _result = _result.Insert(_result.Length, newChar.ToString().ToUpper());
                                
                            }
                            else
                            {
                                _result = _result.Insert(_result.Length, newChar.ToString());
                            }
                        }
                        else
                        {
                            _result = _result.Insert(_result.Length, ch.ToString());
                        }

                    }
                }

                return _result;
            }

            bool StarredLetters(string input)
            {
                if (!string.IsNullOrEmpty(input))
                {
                    char[] inputarray = input.ToCharArray();
                    foreach (char ch in inputarray)
                    {
                        if (ch >= 'a' && ch <= 'z' || ch >= 'A' && ch <= 'Z')
                        {
                            int letterIndex = input.IndexOf(ch, StringComparison.InvariantCultureIgnoreCase);
                            if (letterIndex == 0 || letterIndex == (input.Length - 1))
                                return false;
                            else
                            {
                                if (!(input[letterIndex - 1].Equals('*') && input[letterIndex + 1].Equals('*')))
                                {
                                    return false;
                                }
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }
    }
}