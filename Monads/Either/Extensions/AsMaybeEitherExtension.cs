using static Monads.MaybeFactory;

namespace Monads
{
    public static class AsMaybeEitherExtension
    {
        public static Maybe<TRight> AsMaybe<TLeft, TRight>(this Either<TLeft, TRight> source)
        {
            return source.Adjust(
                left => Nothing, 
                right => Just(right));
        }
    }
}
