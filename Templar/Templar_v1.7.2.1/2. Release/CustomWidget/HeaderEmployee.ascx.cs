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
    public partial class HeaderEmployee : System.Web.UI.UserControl, IWidget
    {
        IWidgetHost Host = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Host.CurrentPageMode != PageMode.Design)
            {
                HeaderEmpPanel.Visible = true;
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            //Clear Cookie
        }

        public void HideSettings()
        {
            HeaderEmpPanel.Visible = false;
        }

        public new void Init(IWidgetHost host)
        {
            Host = host;
        }

        public void ShowSettings()
        {
            HeaderEmpPanel.Visible = true;
        }
    }
}