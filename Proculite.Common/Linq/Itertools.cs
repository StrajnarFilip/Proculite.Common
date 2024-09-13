using System;
using System.Collections.Generic;
using System.Linq;

namespace Proculite.Common.Linq
{
    /// <summary>
    /// Static methods that provide the same functionality as functions within Python's
    /// <see href="https://docs.python.org/3/library/itertools.html">itertools</see> module.
    /// </summary>
    public static class Itertools
    {
        public static IEnumerable<int> Count(int start = 0, int step = 1)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<TSource> Cycle<TSource>(this IEnumerable<TSource> source)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<TSource> Repeat<TSource>(TSource source, int? times = null)
        {
            throw new NotImplementedException();
        }
    }
}
