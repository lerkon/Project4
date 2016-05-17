using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["person"] == null)
            {
                Log.Text = "  Login";
                RegisterProfile.Text = "  Register";
            }
            else
            {
                Log.Text = "  Logout";
                RegisterProfile.Text = "  Profile";
                boughtt.Style.Add("display", "");
                selll.Style.Add("display", "");
                soldd.Style.Add("display", "");
            }
        }
    }
}