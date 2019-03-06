using System;

namespace Monads
{
    public partial struct Maybe<TData> 
    {
        public TResult Adjust<TResult>(
            Func<TData, TResult> just, 
            Func<TResult> nothing)
        {
            return Adjust(just, nothing());
        }

        public TResult Adjust<TResult>(Func<TData, TResult> just, TResult nothing)
        {
            if (this.HasValue())
            {
                Assert.ArgumentIsNotNull(just(this.value));

                return just(this.value);
            }
            else
            {
                Assert.ArgumentIsNotNull(nothing);

                return nothing;
            }
        }

        public void Do(Action<TData> just, Action nothing)
        {
            DoWhenHasValue(just);
            DoWhenHasNoValue(nothing);
        }

        public void DoWhenHasNoValue(Action nothing) 
        {
            if (!this.HasValue()) nothing();
        }

        public void DoWhenHasValue(Action<TData> just) 
        {
            if (this.HasValue()) just(this.value);
        }

        public TData ValueOr(TData alternative)
        { 
            Assert.ArgumentIsNotNull(alternative);

            return !this.HasValue() ? (TData)alternative : this.value;
        }

        public TData ValueOr(Func<TData> alternativeFactory)
        {
            return this.ValueOr(alternativeFactory());
        }

        public Maybe<TData> Or(Maybe<TData> alternative)
        { 
            return !this.HasValue() ? alternative : this;
        }

        public Maybe<TData> Or(Func<Maybe<TData>> alternativeFactory)
        {
            return this.Or(alternativeFactory());
        }
    }
}
