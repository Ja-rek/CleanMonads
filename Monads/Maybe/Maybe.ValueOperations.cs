using System;

namespace Monads
{
    public partial struct Maybe<TData> 
    {
        public Maybe<TResult> Map<TResult>(Func<TData, TResult> predicate)
        {
            if (this.HasValue()) return predicate(this.value);

            return new Maybe<TResult>(false);
        }

        public Maybe<TResult> FlatMap<TResult>(Func<TData, Maybe<TResult>> predicate)
        {
            if (this.HasValue()) return predicate(this.value);

            return new Maybe<TResult>(false);
        }

        public Maybe<TData> Filter(Func<TData, bool> condition)
        {
            return this.HasValue() | condition(this.value)
                ? this.value
                : new Maybe<TData>(false);
        }
    }
}
