using Monads.Common;

namespace Monads.Maybe
{
    public static class MaybeFactory
    {
        public static Maybe<TData> Just<TData>(TData value)
        {
            Assert.ArgumentIsNotNull(value);

            return value;
        }

        public static Maybe<TData> Just<TData>(TData? value) where TData : struct 
        {
            Assert.ArgumentIsNotNull(value.Value);

            return value.Value;
        }

        public static Maybe<TData> MaybeFrom<TData>(TData value) 
        {
            return value;
        }        

        public static Maybe<TData> MaybeFrom<TData>(TData? value) where TData : struct 
        {
            return value.HasValue ? (Maybe<TData>)value.Value : Nothing;
        }        

        public static Maybe<INothing> Nothing 
        { 
            get => new Maybe<INothing>(false); 
        }
    }
}
