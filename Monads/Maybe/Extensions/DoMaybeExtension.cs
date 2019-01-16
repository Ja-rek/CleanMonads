using System;

namespace Monads.Maybe
{
    public static class DoMaybeExtension
    {
        public static void Do<TData>(
            this Maybe<TData> source, 
            Action<TData> just, 
            Action nothing)
        {
            source.DoWhenHasValue(just);
            source.DoWhenHasNoValue(nothing);
        }

        public static void DoWhenHasNoValue<TData>(
            this Maybe<TData> source, 
            Action nothing) 
        {
            if (!source.HasValue()) nothing();
        }

        public static void DoWhenHasValue<TData>(
            this Maybe<TData> source, 
            Action<TData> just) 
        {
            if (source.HasValue()) just(source.Value);
        }
    }
}
