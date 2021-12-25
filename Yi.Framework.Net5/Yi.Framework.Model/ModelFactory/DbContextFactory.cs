using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Yi.Framework.Common.Enum;
using Yi.Framework.Common.IOCOptions;

namespace Yi.Framework.Model.ModelFactory
{
    public class DbContextFactory : IDbContextFactory
    {

        private DbContext _Context = null;

        private DbConnOptions _readAndWrite = null;

        public static bool MutiDB_Enabled = false;
        //private static int _iSeed = 0;//应该long

        /// <summary>
        ///能把链接信息也注入进来
        ///需要IOptionsMonitor
        /// </summary>
        /// <param name="context"></param>
        public DbContextFactory(DbContext context, IOptionsMonitor<DbConnOptions> options)
        {
            _readAndWrite = options.CurrentValue;
            this._Context = context;
        }
        public DbContext ConnWriteOrRead(WriteAndReadEnum writeAndRead)
        {
            //判断枚举，不同的枚举可以创建不同的Context 或者更换Context链接；
            if (MutiDB_Enabled)
            {
                switch (writeAndRead)
                {
                    case WriteAndReadEnum.Write:
                        ToWrite();
                        break;  //选择链接//更换_Context链接   //选择链接
                    case WriteAndReadEnum.Read:
                        ToRead();
                        break;  //选择链接//更换_Context链接
                    default:
                        break;
                }
            }
            else
            {
                ToWrite();
            }

            return _Context;
        }

        /// <summary>
        /// 更换成主库连接
        /// </summary>
        /// <returns></returns>
        private void ToWrite()
        {
            string conn = _readAndWrite.WriteUrl;
            //_Context.Database.GetDbConnection().;
            _Context.ToWriteOrRead(conn);
        }


        private static int _iSeed = 0;

        /// <summary>
        /// 更换成主库连接
        /// 
        /// ///策略---数据库查询的负载均衡
        /// </summary>
        /// <returns></returns>
        private void ToRead()
        {
            string conn = string.Empty;
            {
                // //随机
                //int Count=  _readAndWrite.ReadConnectionList.Count;
                //int index=  new Random().Next(0, Count);
                //conn = _readAndWrite.ReadConnectionList[index];
            }
            {
                //来一个轮询
                conn = this._readAndWrite.ReadUrl[_iSeed++ % this._readAndWrite.ReadUrl.Count];//轮询;  
            }
            {
                ///是不是可以直接配置到配置文件里面
            }
            _Context.ToWriteOrRead(conn);
        }

        //public DbContext CreateContext()
        //{ 

        //}
    }
}
