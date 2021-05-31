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
        public static IstudentDal GetstudentDal()
        {
            IstudentDal Data = CallContext.GetData("studentDal") as IstudentDal;
            if (Data == null)
            {
                Data = new studentDal();
                CallContext.SetData("studentDal", Data);
            }
            return Data;
        }

    }
}