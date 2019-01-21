using System.Collections.Generic;
using System.Linq;
using Monads.Either;
using static Monads.Either.EitherFactory;

namespace Monads.Tests.Either
{
    internal class TestTemplate
    {
        protected static Either<string, int> rightInt_10 = 10;
        protected static Either<string, int> rightInt_20 = 20;
        protected static Either<string, int> rightInt_Any = 69;

        protected static Either<string, string> rightStr_10 = Right("10");
        protected static Either<string, string> rightStr_20 = Right("20");
        protected static Either<string, string> rightStr_Any = Right("69");

        protected static Either<string, string> rightStr_Default = EitherFrom("Error", default(string));
        protected static Either<string, int> rightInt_Default = EitherFrom("Error", default(int));

        protected static Either<string, int> leftStr_Error = "Error";
        protected static Either<string, int> leftStr_Any = "69";
        protected static Either<string, int> leftStr_10 = "10";
        protected static Either<string, int> leftStr_20 = "20";
        
        protected static Either<int, int> leftInt_10 = Left(10);
        protected static Either<int, int> leftInt_20 = Left(20);
        protected static Either<int, int> leftInt_Any = Left(69);
        protected static Either<int, int> leftInt_Default = Left(default(int));

        protected static IEnumerable<Either<int, int>> listOf_Right1_Right2 = 
            new Either<int, int>[] { Right(1), Right(2)};

        protected static IEnumerable<int> listOfIntsThatIsNull =  null;
        protected static IEnumerable<Either<string, int>> listOfEihtersIsNull =  null;
        protected static IEnumerable<int> emtpyList =  Enumerable.Empty<int>();

        protected static IEnumerable<int> listOf_1_2 = new int[] { 1, 2 };
        protected static IEnumerable<Either<string, int>> listOf_Right1_LeftError 
            = new Either<string, int>[] { Right(1), Left("Error") };

        protected static IEnumerable<int> listOf_1 = new int[] { 1 };

        protected static int int_10 = 10;
        protected static int? nullableInt_10 = 10;
        protected static int? nullableInt_Null = null;
        protected static int int_20 = 20;
        protected static int int_Any = 69;
        protected static int int_Default = default(int);

        protected static string str_10 = "10";
        protected static string str_20 = "20";
        protected static string str_Any = "69";
        protected static string str_Error = "Error";
        protected static string str_Default = default(string);
    }
}
