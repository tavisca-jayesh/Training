using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Tavisca.Templar.Contract;

namespace CustomWidget
{
    public partial class Header : System.Web.UI.UserControl, IWidget
    {
        IWidgetHost Host = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Host.CurrentPageMode != PageMode.Design)
            {
                HeaderPanel.Visible = true;
            }
        }

        public void HideSettings()
        {
            HeaderPanel.Visible = false;
        }

        public new void Init(IWidgetHost host)
        {
            Host = host;
        }

        public void ShowSettings()
        {
            HeaderPanel.Visible = true;
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            //Clear Cookie
        }
    }
}