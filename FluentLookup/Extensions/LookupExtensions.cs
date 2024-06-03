using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentLookup.Extensions
{
    public static class LookupExtensions
    {
        public static IEnumerable<TModel> Except<TModel>(this IEnumerable<TModel> range, Func<TModel, bool> func)
        {
            return range
                .Where(x => !func.Invoke(x));
        }
    }
}