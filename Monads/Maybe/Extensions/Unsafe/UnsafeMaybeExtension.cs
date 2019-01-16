using System;

namespace Monads.Maybe.Unsafe
{
    public static class UnsafeMaybeExtension
    {
        public static TSome ValueOrDefault<TSome>(this Maybe<TSome> source)
        {
            return source.Value;
        }

        public static TSome Value<TSome>(this Maybe<TSome> source)
        {
            var value = source.Value;

            if (value == null) 
            {
                throw new InvalidOperationException("Value can not be null.");
            }

            return value;
        }

        public static TSome ValueOrFail<TSome>(this Maybe<TSome> source, string message)
        {
            var value = source.Value;

            if (value == null) 
            {
                throw new InvalidOperationException(message);
            }

            return value;
        }
    }
}
