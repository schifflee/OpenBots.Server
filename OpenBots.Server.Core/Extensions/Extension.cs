using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Core.Extensions
{
    public static class Extension
    {
        public static Guid ToGuid(this Guid? source)
        {
            return source ?? Guid.Empty;
        }

        // more general implementation 
        public static T ValueOrDefault<T>(this Nullable<T> source) where T : struct
        {
            return source ?? default;
        }
    }
}
