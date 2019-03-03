using System;
using System.Text.RegularExpressions;

namespace Monads.Integrations.Regex
{
    public partial class Regex
    {
        public string[] Split(string input)
        {
            return regex.Split(input);
        }

        public string[] Split(string input, int count)
        {
            return regex.Split(input, count);
        }

        public string[] Split(string input, int count, int startat)
        {
            return regex.Split(input, count, startat);
        }

        public static string[] Split(string input, string pattern)
        {
            return System.Text.RegularExpressions.Regex.Split(input, pattern);
        }

        public static string[] Split(string input, string pattern, RegexOptions options)
        {
            return System.Text.RegularExpressions.Regex.Split(input, pattern, options);
        }

        public static string[] Split(string input, string pattern, RegexOptions options, TimeSpan matchTimeout)
        {
            return System.Text.RegularExpressions.Regex.Split(input, pattern, options, matchTimeout);
        }
    }
}
