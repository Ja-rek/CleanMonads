using System;
using System.Text.RegularExpressions;

namespace Monads.Integrations.Regex
{
    public partial class Regex
    {
        public string Replace(string input, MatchEvaluator evaluator)
        {
            return regex.Replace(input, evaluator);
        }

        public string Replace(string input, MatchEvaluator evaluator, int count)
        {
            return regex.Replace(input, evaluator, count);
        }

        public string Replace(string input, string replacement)
        {
            return regex.Replace(input, replacement);
        }

        public string Replace(string input, string replacement, int count)
        {
            return regex.Replace(input, replacement, count);
        }

        public string Replace(string input, string replacement, int count, int startat)
        {
            return regex.Replace(input, replacement, count, startat);
        }

        public static string Replace(string input, string pattern, MatchEvaluator evaluator)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, pattern, evaluator);
        }

        public static string Replace(string input, string pattern, MatchEvaluator evaluator, RegexOptions options)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, pattern, evaluator, options);
        }

        public static string Replace(
            string input, 
            string pattern, 
            MatchEvaluator evaluator, 
            RegexOptions options, 
            TimeSpan matchTimeout)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, pattern, evaluator, options, matchTimeout);
        }

        public static string Replace(string input, string pattern, string replacement)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, pattern, replacement);
        }

        public static string Replace(string input, string pattern, string replacement, RegexOptions options)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, pattern, replacement, options);
        }

        public static string Replace(string input, string pattern, string replacement, RegexOptions options, TimeSpan matchTimeout)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, pattern, replacement, options, matchTimeout);
        }
    }
}
