using System;
using System.Linq.Expressions;

namespace BlubLib
{
    public static class FastActivator<T>
    {
        private static readonly Lazy<Func<T>> s_func = new Lazy<Func<T>>(() => CreateExpression().Compile());
        private static readonly Lazy<Func<int, T[]>> s_arrayFunc = new Lazy<Func<int, T[]>>(() => CreateArrayExpression().Compile());

        public static T Create()
        {
            return s_func.Value();
        }

        public static T[] CreateArray(int length)
        {
            return s_arrayFunc.Value(length);
        }

        private static Expression<Func<T>> CreateExpression()
        {
            var @new = Expression.New(typeof(T));
            return Expression.Lambda<Func<T>>(@new);
        }

        private static Expression<Func<int, T[]>> CreateArrayExpression()
        {
            var param = Expression.Parameter(typeof(int), "length");
            var newArray = Expression.NewArrayBounds(typeof(T), param);

            return Expression.Lambda<Func<int, T[]>>(newArray, param);
        }
    }
}
