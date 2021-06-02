using CC.Yi.Common.mongodb.model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.Yi.Common.mongodb
{
    public  class mongodbContext
    {
        private readonly IMongoDatabase _database = null;
        public mongodbContext()
        {
            //连接服务器名称 mongo的默认端口27017
            var client = new MongoClient("mongodb://.......:27017");
            if (client != null)
                //连接数据库
                _database = client.GetDatabase("数据库名");
        }

        public IMongoCollection<student> Province
        {
            get
            {
                return _database.GetCollection<student>("Province");
            }
        }
    }
}
