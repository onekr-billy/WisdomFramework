using System;
using System.Collections.Generic;
using System.Text;

using Weed;
namespace W.Service
{
    internal partial class MallService : ACacheUsingEx<IMall, MallService>, IMall
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new MallService();
        }
    }
}
