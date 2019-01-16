namespace Monads.Either
{
    public static class LeftOrRightEitherExtension
    {
        public static TData RightOrLeft<TData>(this Either<TData, TData> source) 
        { 
            EitherAssert.LeftOrRightExist(source);

            return source.IsRight() ? source.Right : source.Left ;
        }
    }
}
