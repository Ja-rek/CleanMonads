using System;
using System.Text.RegularExpressions;

namespace Monads.Integrations.Regex
{
    public partial class Regex
    {
        private System.Text.RegularExpressions.Regex regex;

        public Regex(string pattern)
        {
            regex = new System.Text.RegularExpressions.Regex(pattern);
        }

        public Regex(string pattern, RegexOptions regexOptions)
        {
            regex = new System.Text.RegularExpressions.Regex(pattern, regexOptions);
        }

        public TimeSpan MatchTimeout 
        { 
            get => regex.MatchTimeout;
        }

        public RegexOptions Options
        { 
            get => regex.Options;
        }

        public bool RightToLeft
        { 
            get => regex.RightToLeft;
        }

        public static int CacheSize
        { 
            get => System.Text.RegularExpressions.Regex.CacheSize;
        }

        public static TimeSpan InfiniteMatchTimeout
        { 
            get => System.Text.RegularExpressions.Regex.InfiniteMatchTimeout;
        }

        public override bool Equals(object obj)
        {
            return regex.Equals(obj);
        }

        public override int GetHashCode()
        {
            return regex.GetHashCode();
        }

        public static string Escape(string str)
        {
            return System.Text.RegularExpressions.Regex.Escape(str);
        }

        public static string Unescape(string str)
        {
            return System.Text.RegularExpressions.Regex.Unescape(str);
        }
    }
}
