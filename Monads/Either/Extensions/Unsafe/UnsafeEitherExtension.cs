using System;

namespace Monads.Extensions.Unsafe
{
    public static class UnsafeEitherExtension
    {
        private const string ErrorMessage = "Value can not be null.";

        public static Either<TLeft, TRight> RightOrDefault<TLeft, TRight>(this Either<TLeft, TRight> source)
        {
            return source.ForceRight;
        }

        public static Either<TLeft, TRight> LeftOrDefault<TLeft, TRight>(this Either<TLeft, TRight> source)
        {
            return source.ForceLeft;
        }

        public static  TRight Right<TLeft, TRight>(this Either<TLeft, TRight> source)
        {
            return GetOrFail(source.ForceRight, ErrorMessage);
        }

        public static TLeft Left<TLeft, TRight>(this Either<TLeft, TRight> source)
        {
            return GetOrFail(source.ForceLeft, ErrorMessage);
        }

        public static Either<TLeft, TRight> RightOrFail<TLeft, TRight>(
            this Either<TLeft, TRight> source,
            string message)
        {
            return GetOrFail(source.ForceRight, message);
        }

        public static Either<TLeft, TRight> RightOrFail<TLeft, TRight>(
            this Either<TLeft, TRight> source,
            Func<string> message)
        {
            return GetOrFail(source.ForceRight, message());
        }

        public static Either<TLeft, TRight> LeftOrFail<TLeft, TRight>(
            this Either<TLeft, TRight> source,
            string message)
        {
            return GetOrFail(source.ForceLeft, message);
        }

        public static Either<TLeft, TRight> LeftOrFail<TLeft, TRight>(
            this Either<TLeft, TRight> source,
            Func<string> message)
        {
            return GetOrFail(source.ForceRight, message());
        }

        private static TResult GetOrFail<TResult>(TResult right, string message)
        {
            return right != null ? right : throw new InvalidOperationException(message);
        }
    }
}
