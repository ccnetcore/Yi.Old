using CC.Yi.DAL;
using CC.Yi.IDAL;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CC.Yi.DALFactory
{
    public partial class StaticDalFactory
    {
        private static class CallContext
        {
            static ConcurrentDictionary<string, AsyncLocal<object>> state = new ConcurrentDictionary<string, AsyncLocal<object>>();

            public static void SetData(string name, object data) =>
                state.GetOrAdd(name, _ => new AsyncLocal<object>()).Value = data;

            public static object GetData(string name) =>
                state.TryGetValue(name, out AsyncLocal<object> data) ? data.Value : null;
        }
    }
}
