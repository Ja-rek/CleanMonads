using System;

namespace Monads.Extensions.Unsafe
{
    public static class UnsafeMaybeExtension
    {
        public static TSome ValueOrDefault<TSome>(this Maybe<TSome> source)
        {
            return source.ForceValue;
        }

        public static TSome? NullableValue<TSome>(this Maybe<TSome> source) where TSome : struct
        {
            return source.ForceValue;
        }

        public static TSome Value<TSome>(this Maybe<TSome> source)
        {
            var value = source.ForceValue;

            if (value == null) 
            {
                throw new InvalidOperationException("Value can not be null.");
            }

            return value;
        }

        public static TSome ValueOrFail<TSome>(this Maybe<TSome> source, string message)
        {
            var value = source.ForceValue;

            if (value == null) 
            {
                throw new InvalidOperationException(message);
            }

            return value;
        }
    }
}
