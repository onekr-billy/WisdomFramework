using System;
using System.Collections.Generic;
using System.Text;

namespace W.DataBase
{
    /// <summary>
    /// 索引定义代理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    /// <returns></returns>
    public delegate int IndexExpressHandler<T>(T t);

    /// <summary>
    /// 数据列表(List T + Total)
    /// 
    /// 介绍WCF的发布考虑，不采用 ref 和 out参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DList<T> : List<T>
    {
        #region List<T>
        /// <summary>
        /// 
        /// </summary>
        public DList() : base() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        public DList(int capacity) : base(capacity) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        public DList(IEnumerable<T> collection) : base(collection) {
            this.Total = this.Count;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="total"></param>
        public DList(IEnumerable<T> collection, int total): base(collection)
        {
            this.Total = total;
        }

       
        /// <summary>
        /// 记录总数
        /// </summary>
        public int Total;

        /// <summary>
        /// 所属者ID[默认为0]
        /// </summary>
        public int MasterID { get; set; }

        /// <summary>
        /// 所属者[默认为null]
        /// </summary>
        public object Master { get; set; }

        /// <summary>
        /// 填充,将数据分解给 list 和 total
        /// </summary>
        /// <param name="total"></param>
        /// <returns></returns>
        public DList<T> Fill(out int total)
        {
            total = this.Total;

            return this;
        }
        #endregion

        /// <summary>
        /// 添加一批内容
        /// </summary>
        /// <typeparam name="Q"></typeparam>
        /// <param name="list"></param>
        public void AddRange1<Q>(IEnumerable<Q> list) where Q : T
        {
            foreach (Q q in list)
                this.Add(q);
        }

        /// <summary>
        /// 取前多少条
        /// </summary>
        /// <returns></returns>
        public List<T> Top(int top)
        {
            if (top > this.Count)
                return this;
            else
                return this.GetRange(0, top);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="start">从0开始</param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<T> SubList(int start, int count)
        {
            int len = this.Count;

            if (len <= start)
                return new List<T>();
            else
            {
                if (len <= (start + count))
                    count = len - start;

                if (count <= 0)
                    return new List<T>();
                else
                    return this.GetRange(start, count);
            }
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="index">索引定义代理</param>
        public void Sort(IndexExpressHandler<T> index)
        {
            this.Sort((a, b) =>
            {
                return index(a) - index(b);
            });
        }
    }
}
