using System;
using System.Collections.Generic;
using System.Text;

using Weed.SDQ;

namespace W.DataBase
{
    /// <summary>
    /// 
    /// </summary>
    public class DbConfig
    {
        static DbConfig()
        {
            if (SdqSettings.Contains("Mall"))
                _Mall = SdqSettings.Get("Mall");
            else
            {
                _Mall = new SdqConfig("Mall", AccessType.Mssql9, "database=Mall;server=db01;uid=root;pwd=84E1FB063A;");
            }

            if (SdqSettings.Contains("Bill"))
                _Bill = SdqSettings.Get("Bill");
            else
            {
                _Bill = new SdqConfig("Bill", AccessType.Mssql9, "database=MicroPayment_ProductStock;server=db02;uid=carhome;pwd=8D102E41AD;");
            }
        }
   
        private static SdqConfig _Bill;
        /// <summary>
        /// 订单中心
        /// </summary>
        public static SdqConfig Bill
        {
            get { return _Bill; }
        }
        private static SdqConfig _Mall;
        /// <summary>
        /// B2C商城
        /// </summary>
        public static SdqConfig Mall
        {
            get { return _Mall; }
        }

    }
}
