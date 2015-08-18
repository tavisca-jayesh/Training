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
    public partial class Footer : System.Web.UI.UserControl,IWidget
    {
        IWidgetHost Host = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Host.CurrentPageMode != PageMode.Design)
            {
                FooterPanel.Visible = true;
            }
        }

        public void HideSettings()
        {
            FooterPanel.Visible = false;
        }

        public new void Init(IWidgetHost host)
        {
            Host = host;
        }

        public void ShowSettings()
        {
            FooterPanel.Visible = true;
        }
    }
}