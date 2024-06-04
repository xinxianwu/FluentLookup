using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentLookup.Extensions
{
    public static class LookupExtensions
    {
        public static IEnumerable<TModel> Except<TModel>(this IEnumerable<TModel> source, Func<TModel, bool> func)
        {
            return source
                .Where(x => !func.Invoke(x));
        }

        /// <summary>
        /// exclude items based on the key selector
        /// </summary>
        /// <param name="source"></param>
        /// <param name="exclusionSet"></param>
        /// <param name="selector"></param>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TAnotherModel"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TModel> Difference<TModel, TAnotherModel>(this IEnumerable<TModel> source, ISet<TAnotherModel> exclusionSet, Func<TModel, TAnotherModel> selector)
        {
            return source
                .Where(x => !exclusionSet.Contains(selector(x)));
        }

        public static KeyLookupChain<TKey, TValue> BeginKeyLookupChain<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return new KeyLookupChain<TKey, TValue>(dictionary);
        }
    }
}