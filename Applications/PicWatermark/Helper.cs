using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace TOP.Applications.PicWatermark
{
    public static class Helper
    {
        public static IList<IWatermark> GetWatermarkList()
        {
            List<IWatermark> list = new List<IWatermark>();

            Assembly assem = Assembly.GetExecutingAssembly();
            foreach (Type type in assem.GetTypes())
            {
                if (typeof(IWatermark).IsAssignableFrom(type) && !type.IsAbstract && !typeof(IWatermark).Equals(type))
                {
                    list.Add((IWatermark)type.GetConstructor(Type.EmptyTypes).Invoke(new object[0]));
                }
            }
            return list;
        }
    }
}
