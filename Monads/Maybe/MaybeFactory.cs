using System;

namespace Monads
{
    public static class MaybeFactory
    {
        public static Maybe<TData> Just<TData>(TData value)
        {
            Assert.ArgumentIsNotNull(value, nameof(value));

            return value;
        }

        public static Maybe<TData> MaybeOf<TData>(TData value) 
        {
            return value;
        }

        public static Maybe<TData> MaybeOf<TData>(Func<TData> value) 
        {
            return value();
        }

        public static Maybe<TData> MaybeOf<TData>(TData? value) where TData : struct 
        {
            if (value.HasValue) return value.Value;

            return Nothing;
        }

        public static Maybe<TData> MaybeOf<TData>(Func<TData?> value) where TData : struct
        {
            return MaybeOf(value());
        }

        public static Maybe<NotDefined> Nothing 
        { 
            get => new Maybe<NotDefined>(false); 
        }

        public static Maybe<TResult> NothingOf<TResult>() 
        { 
            return new Maybe<TResult>(false); 
        }
    }
}
