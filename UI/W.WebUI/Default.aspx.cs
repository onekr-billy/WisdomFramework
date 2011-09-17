using System;
using System.Collections.Generic;
using W.Service;
using System.Text;
using W.Entity.Mall;
using W.DataBase;

namespace W.WebUI
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<B2cproduct> list = WeedService.GET<IMall>().GetProductByClassId();
            StringBuilder sbr = new StringBuilder();
            list.ForEach(delegate(B2cproduct _item)
            {
                sbr.AppendFormat("<p>{0}</p>", _item.Goodstitle);
            });
            Response.Write(sbr);
        }
    }
}
