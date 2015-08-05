using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TempWebFormApp
{
    public partial class HRHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
            }
        }
        protected void Page_PreRender(object sender, System.EventArgs e)
        {
            
        }
       
        public void EmployeeView(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex -= 1;
        }

        public void RemarkView(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex += 1;
        }

        

    }
}