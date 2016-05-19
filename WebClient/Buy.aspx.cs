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
    public partial class Buy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string message = null;
            var list = new ItemServiceClient().getItemsCategory((string)Session["category"], ref message);
            category.InnerHtml = (string)Session["category"];
            string s = null;
            if (list == null)
                s = "<small class='pull-right'>available products: 0</small>";
            else
                s = "<small class='pull-right'>Available products: " + list.Count() + "</small>";
            category.Controls.Add(new LiteralControl(s));
            if (list != null)
            {
                foreach (var i in list)
                {
                    string base64String = "data:image/png;base64,";
                    if (i.img != null)
                        base64String += Convert.ToBase64String(i.img[0], 0, i.img[0].Length);
                    addItem(base64String, i.name, i.description, i.price, i.stockRemained, i.stock, i.id);
                }
            }
        }

        private void addItem(string pic, string name, string description, int price, int stockRemained, int stock, int id)
        {
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes.Add("class", "row");
            addProduct.Controls.Add(div1);
            HtmlGenericControl div2 = new HtmlGenericControl("div");
            div2.Attributes.Add("class", "span2");
            div1.Controls.Add(div2);
            HtmlGenericControl img1 = new HtmlGenericControl("img");
            img1.Attributes.Add("src", pic);
            div2.Controls.Add(img1);
            HtmlGenericControl div3 = new HtmlGenericControl("div");
            div3.Attributes.Add("class", "span4");
            div1.Controls.Add(div3);
            HtmlGenericControl h1 = new HtmlGenericControl("h3");
            h1.InnerHtml = name;
            div3.Controls.Add(h1);
            HtmlGenericControl p1 = new HtmlGenericControl("p");
            p1.InnerHtml = description;
            div3.Controls.Add(p1);
            HtmlGenericControl div4 = new HtmlGenericControl("div");
            div4.Attributes.Add("class", "btn btn-small pull-right");
            div4.InnerHtml = "View Details";
            div3.Controls.Add(div4);
            HtmlGenericControl br = new HtmlGenericControl("br");
            br.Attributes.Add("class", "clr");
            div3.Controls.Add(br);
            HtmlGenericControl div5 = new HtmlGenericControl("div");
            div5.Attributes.Add("class", "span3 alignR");
            div1.Controls.Add(div5);
            HtmlGenericControl h2 = new HtmlGenericControl("h3");
            h2.InnerHtml = price.ToString();
            div5.Controls.Add(h2);
            HtmlGenericControl p2 = new HtmlGenericControl("p");
            p2.InnerHtml = "Stock: "+ stockRemained + "/"+ stock;
            div5.Controls.Add(p2);
            LinkButton lb = new LinkButton();
            lb.Click += new EventHandler(addProductCart);
            lb.CssClass = "btn btn-large btn-primary";
            lb.Text = "Add to cart";
            lb.CommandArgument = id.ToString();
            div5.Controls.Add(lb);
        }

        protected void addProductCart(object sender, EventArgs e)
        {
            if (Session["productId"] == null)
                Session["productId"] = new List<string>();
            LinkButton l = (LinkButton)(sender);
            Session["productId"] = l.CommandArgument;
            //Response.Redirect("./Buy.aspx");
            ((MasterPage)this.Master).changeCart();
        }
    }
}