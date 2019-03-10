using System;

namespace Monads
{
    public partial struct Maybe<TData> 
    {
        public Maybe<TResult> Map<TResult>(Func<TData, TResult> predicate)
        {
            if (this.hasValue) return predicate(this.value);

            return new Maybe<TResult>(false);
        }

        public Maybe<TResult> FlatMap<TResult>(Func<TData, Maybe<TResult>> predicate)
        {
            if (this.hasValue) return predicate(this.value);

            return new Maybe<TResult>(false);
        }

        public Maybe<TData> Filter(Func<TData, bool> condition)
        {
            if (this.hasValue && condition(this.value))
            {
                return this.value;
            }

            return new Maybe<TData>(false);
        }

        public Maybe<TData> Or(Maybe<TData> alternative)
        { 
            return !this.hasValue ? alternative : this;
        }

        public Maybe<TData> Or(Func<Maybe<TData>> alternativeFactory)
        {
            return this.Or(alternativeFactory());
        }
    }
}
