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
            changeCart();
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

        protected void category(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)(sender);
            Session["category"] = l.Text;
            Response.Redirect("./Buy.aspx");
        }

        public void changeCart()
        {
            myCart.Controls.Clear();
            if(Session["productId"] == null)
            {
                myCart.Controls.Add(new LiteralControl(
                "<img src='themes/images/ico-cart.png' alt='cart'>0 Items in your cart <span class='badge badge-warning pull-right'>0 KR</span>"
                ));
            }
            else
            {
                var price = ((List<int[]>)Session["productId"]).Sum(x => x[1]);
                myCart.Controls.Add(new LiteralControl(
                "<img src='themes/images/ico-cart.png' alt='cart'>"
                + ((List<int[]>)Session["productId"]).Count() +
                " Items in your cart  <span class='badge badge-warning pull-right'>"+price+" KR</span>"
                ));
            }
        }
    }
}