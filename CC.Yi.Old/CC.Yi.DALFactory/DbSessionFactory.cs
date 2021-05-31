using CC.Yi.IDAL;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CC.Yi.DALFactory
{
    public class DbSessionFactory
    {
        public static IDbSession GetCurrentDbSession()
        {
            IDbSession db = CallContext.GetData("DbSession") as IDbSession;
            if (db == null)
            {
                db = new DbSession();
                CallContext.SetData("DbSession", db);
            }
            return db;
        }

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
