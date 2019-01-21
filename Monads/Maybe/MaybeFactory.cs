using System;

namespace Monads.Maybe
{
    public static class MaybeFactory
    {
        public static Maybe<TData> Just<TData>(TData value)
        {
            return value;
        }

        public static Maybe<TData> MaybeFrom<TData>(TData value) 
        {
            return value;
        }

        public static Maybe<TData> MaybeFrom<TData>(Func<TData> value) 
        {
            return value();
        }

        public static Maybe<TData> MaybeFrom<TData>(TData? value) where TData : struct 
        {
            if (value.HasValue) return value.Value;

            return Nothing;
        }

        public static Maybe<TData> MaybeFrom<TData>(Func<TData?> value) where TData : struct
        {
            return MaybeFrom(value());
        }

        public static Maybe<INothing> Nothing 
        { 
            get => new Maybe<INothing>(false); 
        }
    }
}
