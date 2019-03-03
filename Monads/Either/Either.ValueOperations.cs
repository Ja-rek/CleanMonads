using System;
using Monads.Utils;

namespace Monads
{
    public partial class Either<TLeft, TRight>
    {
        public Either<TLeft, TResult> FlatMap<TResult>(Func<TRight, Either<TLeft, TResult>> predicate)
        {
            return this.Map(x => predicate(x).right);
        }

        public Either<TLeft, TResult> Map<TResult>(Func<TRight, TResult> predicate)
        {
            if (this.IsRight()) 
            {
                Assert.ArgumentIsNotNull(predicate(this.right), nameof(predicate));

                return predicate(this.right);
            }

            return left;
        }

        public Either<TLeft, TRight> Filter(Func<TRight, bool> condition, Func<TLeft> leftFactory)
        {
            return this.Filter(condition, leftFactory());
        }

        public Either<TLeft, TRight> Filter(Func<TRight, bool> condition, TLeft left)
        {
            if (this.IsRight() && condition(this.right)) 
            {
                return this.right;
            }
            
            return left;
        }
    }
}
