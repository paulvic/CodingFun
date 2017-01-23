using System.Collections.Generic;

namespace CommonProblems
{
    public class BalancedBraces
    {
        // Demonstrates using the properties of a stack to parse a string for balanced braces
        public static bool CheckBraces(string s)
        {
            List<char> leftBraces = new List<char> { '(', '{', '[', '<'};
            List<char> rightBraces = new List<char> { ')', '}', ']', '>' };

            Stack<int> bracesEncountered = new Stack<int>();

            for (int i = 0; i < s.Length; i++)
            {
                char character = s[i];
                int foundLeftIndex = leftBraces.IndexOf(character);
                if (foundLeftIndex > -1)
                {
                    bracesEncountered.Push(foundLeftIndex);
                }
                else
                {
                    int foundRightIndex = rightBraces.IndexOf(character);
                    if (foundRightIndex > -1)
                    {
                        if (!((bracesEncountered.Count > 0) &&
                           (bracesEncountered.Pop() == foundRightIndex)))
                        {
                            // There isn't a matching left brace
                            return false;
                        }
                    }
                }
            }

            return (bracesEncountered.Count == 0); // no remaining unbalanced braces
        }
    }
}
