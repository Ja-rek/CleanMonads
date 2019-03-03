using System;
using System.Text.RegularExpressions;

namespace Monads.Integrations.Regex
{
    public partial class Regex
    {
        public bool IsMatch(string input)
        {
            return this.regex.IsMatch(input);
        }

        public bool IsMatch(string input, int startat)
        {
            return this.regex.IsMatch(input, startat);
        }

        public Maybe<Match> Match(string input)
        {
            var mached = regex.Match(input);

            if (mached.Success) return mached;

            return null;
        }

        public Maybe<Match> Match(string input, int beginning, int length)
        {
            var mached = regex.Match(input, beginning, length);

            if (mached.Success) return mached;

            return null;
        }

        public Maybe<Match> Match(string input, int startat)
        {
            var mached = regex.Match(input, startat);

            if (mached.Success) return mached;

            return null;
        }

        public MatchCollection Matches(string input)
        {
            return regex.Matches(input);
        }

        public MatchCollection Matches(string input, int startat)
        {
            return regex.Matches(input, startat);
        }

        public static bool IsMatch(string input, string pattern)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, pattern);
        }

        public static bool IsMatch(string input, string pattern, RegexOptions options)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, pattern, options);
        }

        public static bool IsMatch(string input, string pattern, RegexOptions options, TimeSpan matchTimeout)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, pattern, options, matchTimeout);
        }


        public static Maybe<Match> Match(string input, string pattern)
        {
            var mached = System.Text.RegularExpressions.Regex.Match(input, pattern);

            if (mached.Success) return mached;

            return null;
        }

        public static Maybe<Match> Match(string input, string pattern, RegexOptions options)
        {
            var mached = System.Text.RegularExpressions.Regex.Match(input, pattern, options);

            if (mached.Success) return mached;

            return null;
        }

        public static Maybe<Match> Match(string input, string pattern, RegexOptions options, TimeSpan matchTimeout)
        {
            var mached = System.Text.RegularExpressions.Regex.Match(input, pattern, options, matchTimeout);

            if (mached.Success) return mached;

            return null;
        }

        public static MatchCollection Matches(string input, string pattern)
        {
            return System.Text.RegularExpressions.Regex.Matches(input, pattern);
        }

        public static MatchCollection Matches(string input, string pattern, RegexOptions options)
        {
            return System.Text.RegularExpressions.Regex.Matches(input, pattern, options);
        }

    }
}
