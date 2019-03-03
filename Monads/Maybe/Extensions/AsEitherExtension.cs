namespace Monads
{
    public static class AsEitherExtension
    {
        public static Either<TLeft, TRight> AsEither<TLeft, TRight>(this Maybe<TRight> source, TLeft left)
        {
            if (source.HasValue()) return source.ForceValue;

            return left;
        }
    }
}
