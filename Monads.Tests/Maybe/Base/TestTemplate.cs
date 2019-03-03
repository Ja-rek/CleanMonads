using System.Collections.Generic;
using System.Linq;
using static Monads.MaybeFactory;

namespace Monads.Tests.Maybe
{
    internal class TestTemplate
    {
        protected static Maybe<int> int_Nothing = Nothing;
        protected static Maybe<int> maybeInt_Default = default(int);
        protected static Maybe<int> maybeInt_10 = 10;
        protected static Maybe<int> maybeInt_20 = 20;
        protected static Maybe<int> maybeInt_Any = 69;
        protected static Maybe<string> str_Nothing = Nothing;
        protected static Maybe<string> maybeStr_Default= default(string);
        protected static Maybe<string> maybeStr_10 = "10";
        protected static Maybe<string> maybeStr_20 = "20";
        protected static Maybe<string> maybeStr_Any = "69";

        protected static IEnumerable<Maybe<int>> emptyListOfMaybes = 
            Enumerable.Empty<Maybe<int>>();

        protected static IEnumerable<Maybe<int>> listOfMaybes = 
            Enumerable.Repeat(Just(1), 2);

        protected static IEnumerable<Maybe<int>> listOfMaybesThatIsNull = null;

        protected static IEnumerable<int> emptyList = Enumerable.Empty<int>();

        protected static IEnumerable<int> listOf_1_2 = 
            new int[] { 1, 2 };

        protected static IEnumerable<Maybe<int>> listOf_Just1_Just2 = 
            new Maybe<int>[] { Just(1), Just(2) };

        protected static IEnumerable<int> listOf_1 = 
            new int[] { 1 };

        protected static IEnumerable<int> listOf_1_2_3_4 = 
            new int[] { 1, 2, 3, 4 };

        protected static IEnumerable<int> listIsNull = null;

        protected static string str_Any = "69";
        protected static string str_10 = "10";
        protected static string str_20 = "20";

        protected static int int_10 = 10;
        protected static int? nullableInt_10 = 10;
        protected static int? nullableInt_Null = null;
        protected static int int_20 = 20;
        protected static int int_Any = 69;
    }
}
