using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W.WebUI
{
    public partial class HeadImport : System.Web.UI.UserControl
    {
        private string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}