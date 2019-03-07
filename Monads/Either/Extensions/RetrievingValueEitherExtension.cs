namespace Monads
{
    public static class RetrievingValueEitherExtension
    {
        public static TData RightOrLeft<TData>(this Either<TData, TData> source) 
        { 
            return source.IsRight() ? source.ForceRight : source.ForceLeft ;
        }

        public static int RightOrZero<TLeft>(this Either<TLeft, int> source) 
        { 
            return source.RightOr(0);
        }

        public static string RightOrEmpty<TLeft>(this Either<TLeft, string> source) 
        { 
            return source.RightOr(string.Empty);
        }

        public static int LeftOrZero<TRight>(this Either<int, TRight> source) 
        { 
            return source.LeftOr(0);
        }

        public static string LeftOrEmpty<TRight>(this Either<string, TRight> source) 
        { 
            return source.LeftOr(string.Empty);
        }
    }
}
