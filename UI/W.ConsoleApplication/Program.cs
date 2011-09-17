using System;
using System.Collections.Generic;
using System.Text;
using W.Service;
using W.Entity.Mall;
using W.DataBase;
using Weed.SDQ;
using System.IO;
using MongoDB;
using System.Data;

namespace W.ConsoleApplication
{
    class Program
    {
        private static readonly string _conString = "Server=127.0.0.1";
        private static readonly string _dbName = "Mall";

        static void Main(string[] args)
        {
            #region MyRegion
            //List<B2cproduct> list = WeedService.GET<IMall>().GetProductByClassId();
            //StringBuilder sbr = new StringBuilder();

            //list.ForEach(delegate(B2cproduct _item)
            //{
            //    Console.Write("{0}\n", _item.Goodstitle);
            //});

            //Customer doc = new Customer() { Address = "上海", ContactName = "张斌", CustomerID = "1", CustomerName = "电脑" };
            //Insert(doc);

            //add();

            //int l_d1 = 0;

            //int l1 = 1;
            //int l2 = 2;
            //int l3 = 4;
            //int l4 = 8;
            //int l5 = 16;
            //int l6 = 32;
            //int l7 = 64;
            //int l8 = 128;

            //Console.WriteLine(l_d1 & l1);
            //Console.WriteLine(l_d1 | l1);

            //Console.Write(Convert.ToInt32("0011", 2));
            //Console.Write(Math.Pow(2, 3)); 
            #endregion



            Console.ReadKey();
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="doc"></param>
        private static void Insert(Customer doc)
        {
            doc.CustomerID = Guid.NewGuid().ToString("N");

            // 首先创建一个连接
            using (Mongo mongo = new Mongo(_conString))
            {
                //打开连接
                mongo.Connect();
                //打开数据库
                var db = mongo.GetDatabase(_dbName);
                //根据类型获取相应集合
                IMongoCollection<Customer> collection = db.GetCollection<Customer>();
                //插入数据
                collection.Insert(doc);
            }
        }

        private static void add()
        {

            using (MongoDB.Mongo mongo = new Mongo(_conString))
            {
                mongo.Connect();
                MongoDB.IMongoDatabase database = mongo.GetDatabase(_dbName);
                MongoDB.IMongoCollection<Document> doc = database.GetCollection<Document>("order");

                //插入
                //Document doc1 = new Document();
                //doc1["aa"] = "a1";
                //doc1["bb"] = "b1";

                //Document doc2 = new Document();
                //Document doc3 = new Document();
                //doc1.CopyTo(doc2);
                //doc1.CopyTo(doc3);
                //doc1["cc"] = doc3;

                //IEnumerable<Document> list = new List<Document>() { doc1, doc2 };
                //doc.Insert(list);

                //更新
                //Document wh = new Document();
                //wh["aa"] = "a1";
                //Document info = doc.FindOne(wh);
                //info["bb"] = DateTime.Now;
                //doc.Update(info);



            }

        }



    }

    /// <summary>
    /// entity
    /// </summary>
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
    }

}
