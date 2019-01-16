using System;

namespace Monads.Either.Unsafe
{
    public static class UnsafeMaybeExtension
    {
        private const string ErrorMessage = "Value can not be null.";

        public static Either<TLeft, TRight> RightOrDefault<TLeft, TRight>(this Either<TLeft, TRight> source)
        {
            return source.Right;
        }

        public static Either<TLeft, TRight> LeftOrDefault<TLeft, TRight>(this Either<TLeft, TRight> source)
        {
            return source.Left;
        }

        public static  TRight Right<TLeft, TRight>(this Either<TLeft, TRight> source)
        {
            return GetOrFail(source.Right, ErrorMessage);
        }

        public static TLeft Left<TLeft, TRight>(this Either<TLeft, TRight> source)
        {
            return GetOrFail(source.Left, ErrorMessage);
        }

        public static Either<TLeft, TRight> RightOrFail<TLeft, TRight>(
            this Either<TLeft, TRight> source,
            string message)
        {
            return GetOrFail(source.Right, message);
        }

        public static Either<TLeft, TRight> RightOrFail<TLeft, TRight>(
            this Either<TLeft, TRight> source,
            Func<string> message)
        {
            return GetOrFail(source.Right, message());
        }

        public static Either<TLeft, TRight> LeftOrFail<TLeft, TRight>(
            this Either<TLeft, TRight> source,
            string message)
        {
            return GetOrFail(source.Right, message);
        }

        public static Either<TLeft, TRight> LeftOrFail<TLeft, TRight>(
            this Either<TLeft, TRight> source,
            Func<string> message)
        {
            return GetOrFail(source.Right, message());
        }

        private static TResult GetOrFail<TResult>(TResult right, string message)
        {
            return right != null ? right : throw new InvalidOperationException(message);
        }
    }
}
