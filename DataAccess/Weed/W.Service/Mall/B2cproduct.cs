using System.Collections.Generic;

using W.Model;
using W.Entity.Mall;
using W.Model.Mall;

namespace W.Service
{
    //所有方法测试通过
    internal partial class MallService : IMall
    {
        public List<B2cproduct> GetProductByClassId()
        {
            B2cproductM bm = new B2cproductM();
            List<B2cproduct> list = new List<B2cproduct>();
            list = bm.Select<B2cproduct>(11);
            return list;
        }   

    }
}
