using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebClient.ItemService;

namespace WebClient
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string message = null;
            //Item item = new ItemServiceClient().getItem(Int32.Parse((string)Session["productDetails"]), ref message);
            fillOutFields();
        }

        private void fillOutFields(string name, string description, string dateAuction,
            string stock, string price, string category)
        {

        }

        private void fillOutFields()
        {
            string aaa = "aaa";
            name.InnerHtml = aaa;
            descriptin.InnerHtml = aaa;
            HtmlGenericControl p1 = new HtmlGenericControl("p");
            p1.InnerHtml = "<b>Price: </b>" + aaa + " DKK";
            content.Controls.Add(p1);
            HtmlGenericControl p2 = new HtmlGenericControl("p");
            p2.InnerHtml = "<b>Auction period: </b>" + aaa;
            content.Controls.Add(p2);
            HtmlGenericControl p3 = new HtmlGenericControl("p");
            p3.InnerHtml = "<b>Stock: </b>" + aaa;
            content.Controls.Add(p3);
            HtmlGenericControl p4 = new HtmlGenericControl("p");
            p4.InnerHtml = "<b>Category: </b>" + aaa;
            content.Controls.Add(p4);
        }
    }
}