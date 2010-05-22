using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

public static class BounsLevelMerge
{
    public static string Merge<TSource>(this IEnumerable<TSource> source, Func<TSource, string> selector)
    {
        StringBuilder builder = new StringBuilder();
        foreach (TSource local in source)
        {
            if (builder.ToString() != "")
            {
                builder.Append(",");
            }
            builder.Append(selector(local));
        }
        return builder.ToString();
    }
}

