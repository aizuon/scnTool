using System;
using System.Linq.Expressions;

namespace BlubLib
{
    public static class DynamicCast<TTarget>
    {
        public static TTarget From<TSource>(TSource value)
        {
            return FunctionCache<TSource>.Function(value);
        }

        private static class FunctionCache<TSource>
        {
            public static Func<TSource, TTarget> Function { get; } = Generate();

            private static Func<TSource, TTarget> Generate()
            {
                var parameter = Expression.Parameter(typeof(TSource));
                var convert = Expression.ConvertChecked(parameter, typeof(TTarget));
                return Expression.Lambda<Func<TSource, TTarget>>(convert, parameter).Compile();
            }
        }
    }
}
