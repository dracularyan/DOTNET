using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Yzy.Lib.Expressions
{
    /// <summary>
    /// lamada表达式连接工具。
    /// </summary>
    public class LambdaConcatTools
    {
        public static Expression<Func<T, bool>> OrElse<T>(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            if (left == null || right == null)
            {
                throw new ArgumentNullException();
            }

            ParameterExpression parameter = Expression.Parameter(typeof(T), "p");
            BinaryExpression result = Expression.OrElse(left.Body, right.Body);

            return Expression.Lambda<Func<T, bool>>(result, parameter);
        }

        public static Expression<Func<T, bool>> AndAlso<T>(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            if (left == null || right == null)
            {
                throw new ArgumentNullException();
            }

            ParameterExpression parameter = Expression.Parameter(typeof(T), "p");
            BinaryExpression result = Expression.AndAlso(left.Body, right.Body);

            return Expression.Lambda<Func<T, bool>>(result, parameter);
        }

        public static Expression<Func<T, bool>> WhereKeyIn<T, TKey>(Expression<Func<T, TKey>> keySelector, IEnumerable<TKey> keySet)
        {
            if (keySelector == null || keySet == null)
            {
                throw new ArgumentNullException();
            }

            Expression<Func<T, bool>> lambda = null;

            foreach (var item in keySet)
            {
                BinaryExpression equal = Expression.Equal(keySelector.Body, Expression.Constant(item));

                if (lambda == null)
                {
                    lambda = Expression.Lambda<Func<T, bool>>(equal, keySelector.Parameters);
                }
                else
                {
                    lambda = Expression.Lambda<Func<T, bool>>(Expression.OrElse(lambda.Body, equal), keySelector.Parameters);
                }
            }

            return lambda;
        }
    }
}
