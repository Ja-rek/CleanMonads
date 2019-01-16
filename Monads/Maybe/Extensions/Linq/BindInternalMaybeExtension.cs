using System;
using static Monads.Maybe.MaybeFactory;

namespace Monads.Maybe.Linq
{
    internal static class BindInternalMaybeExtension
    {
        public static Maybe<TResult> Bind<TSome, TResult>(
            this Maybe<TSome> maybe,
            Func<TSome, TResult> predicate)
        {
            return maybe.HasValue() ? predicate(maybe.Value) : (Maybe<TResult>)MaybeFactory.Nothing;
        }

        public static Maybe<TResult> Bind<TSome, TResult>(
            this Maybe<TSome> maybe,
            Func<TSome, Maybe<TResult>> predicate)
        {
            return maybe.HasValue() ? predicate(maybe.Value) : (Maybe<TResult>)MaybeFactory.Nothing;
        }
    }
}
