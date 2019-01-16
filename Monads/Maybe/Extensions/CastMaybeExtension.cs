using System;
using static Monads.Maybe.MaybeFactory;

namespace Monads.Maybe
{
    public static class CastMaybeExtension
    {
        public static Maybe<TData> ToMaybe<TData>(this TData source)
        {
            return source;
        }

        public static Maybe<TData> ToJust<TData>(this TData source)
        {
            return Just(source);
        }

        public static Maybe<TData> ToNothing<TData>(this TData source)
        {
            return MaybeFactory.Nothing;
        }
        
        public static Maybe<TData> ToJustIf<TData>(this TData source, Func<TData, bool> condition)
        {
            return condition(source) ? Just(source) : MaybeFactory.Nothing;
        }

        public static Maybe<TData> ToNothingIf<TData>(this TData source, Func<TData, bool> condition)
        {
            return condition(source) ? MaybeFactory.Nothing : Just(source);
        }
    }
}
