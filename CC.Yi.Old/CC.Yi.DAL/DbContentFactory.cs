using CC.Yi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Threading;


namespace CC.Yi.DAL
{
    public class DbContentFactory
    {
        private static DataContext Webcontext;
        private static object myLock = new object();

        public static void Initialize(DataContext webContext)
        {

            Monitor.Enter(myLock);
            {
                Webcontext = webContext;
            }
        }
        public static DataContext GetCurrentDbContent()
        {

            DataContext db = CallContext.GetData("DbContext") as DataContext;

            if (db == null)//线程在数据槽里面没有此上下文
            {
                db = Webcontext;
                CallContext.SetData("DbContext", db);//放到数据槽中去,DbContext是key，db是value
            }

            try
            {
                    Monitor.Exit(myLock);
            }
            catch
            {
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
