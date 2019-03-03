using System;
using System.Text.RegularExpressions;

namespace Monads.Integrations.Regex
{
    public partial class Regex
    {
        public string[] GetGroupNames()
        {
            return this.regex.GetGroupNames();
        }

        public int[] GetGroupNumbers()
        {
            return this.regex.GetGroupNumbers();
        }

        public string GetGroupNumbers(int i)
        {
            return this.regex.GroupNameFromNumber(i);
        }

        public int GetGroupNumbers(string name)
        {
            return this.regex.GroupNumberFromName(name);
        }
    }
}
