using System;
using Monads.Common;

namespace Monads.Maybe
{
    public static class MatchMaybeExtension
    {
        public static TData Match<TData>(
            this Maybe<TData> source, 
            Func<TData, TData> just, 
            Func<TData> nothing)
        {
            return source.Match(just, nothing());
        }

        public static TData Match<TData>(
            this Maybe<TData> source, 
            Func<TData, TData> just, 
            TData nothing)
        {
            if (source.HasValue())
            {
                Assert.ArgumentIsNotNull(just(source.Value));

                return just(source.Value);
            }
            else
            {
                Assert.ArgumentIsNotNull(nothing);

                return nothing;
            }
        }
   }
}
