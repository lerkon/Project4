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
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["person"] == null)
                Response.Redirect("./Login.aspx");
            else
            {
                if (Session["productId"] != null)
                {
                    string message = null;
                    int[] idList = new int[((List<int[]>)Session["productId"]).Count()];
                    for (int i = 0; i < idList.Count(); i++)
                        idList[i] = ((List<int[]>)Session["productId"]).ElementAt(i)[0];
                    var list = new ItemServiceClient().getItemsCart(idList, ref message);
                    for (int i = 0; i < list.Count(); i++)
                    {
                        byte[][] rowversions = new byte[list.Count()][];
                        rowversions[i] = list[i].rowVersion;
                        Session["rowversions"] = rowversions;
                        string img = "data:image/png;base64,";
                        if (list[i].img != null)
                            img += Convert.ToBase64String(list[i].img[0], 0, list[i].img[0].Length);
                        addRow(i, list[i].name, list[i].stockRemained + "/" + list[i].stock,
                            list[i].price.ToString(), img, (((List<int[]>)Session["productId"]).ElementAt(i)[2]).ToString());
                    }
                    buyButton.Text = "Buy - "+ ((List<int[]>)Session["productId"]).Sum(x => x[1])+" KR";
                    buyButton.Visible = true;
                }
            }
        }

        private void addRow(int index, string name, string stock, string price, string img, string amount)
        {
            HtmlGenericControl tr1 = new HtmlGenericControl("tr");
            addCell.Controls.Add(tr1);
            HtmlGenericControl td1 = new HtmlGenericControl("td");
            tr1.Controls.Add(td1);
            HtmlGenericControl img1 = new HtmlGenericControl("img");
            img1.Attributes.Add("src", img);
            img1.Attributes.Add("width", "60");
            td1.Controls.Add(img1);
            HtmlGenericControl td2 = new HtmlGenericControl("td");
            td2.InnerHtml = name;
            tr1.Controls.Add(td2);
            HtmlGenericControl td3 = new HtmlGenericControl("td");
            tr1.Controls.Add(td3);
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes.Add("class", "input-append");
            td3.Controls.Add(div1);
            TextBox t1 = new TextBox();
            t1.CssClass = "span1";
            t1.Width = 25;
            t1.Text = amount;
            t1.ID = index.ToString();
            t1.TextChanged += new EventHandler(changeAmount);
            div1.Controls.Add(t1);
            LinkButton lb1 = new LinkButton();
            lb1.Click += new EventHandler(changeAmount);
            lb1.CssClass = "btn";
            lb1.Text = "+";
            lb1.CommandArgument = index + ";" + 1;
            div1.Controls.Add(lb1);
            LinkButton lb2 = new LinkButton();
            lb2.Click += new EventHandler(changeAmount);
            lb2.CssClass = "btn";
            lb2.Text = "-";
            lb2.CommandArgument = index + ";" + -1;
            div1.Controls.Add(lb2);
            LinkButton lb3 = new LinkButton();
            lb3.Click += new EventHandler(delete);
            lb3.CssClass = "btn btn-danger";
            lb3.Text = "X";
            lb3.CommandArgument = index.ToString();
            div1.Controls.Add(lb3);
            HtmlGenericControl td4 = new HtmlGenericControl("td");
            td4.InnerHtml = stock;
            tr1.Controls.Add(td4);
            HtmlGenericControl td5 = new HtmlGenericControl("td");
            td5.InnerHtml = price;
            tr1.Controls.Add(td5);
        }

        protected void changeAmount(object sender, EventArgs e)
        {
            try
            {
                string id = null;
                TextBox t = null;
                if (sender is LinkButton)
                {
                    string[] arg = ((LinkButton)(sender)).CommandArgument.Split(';');
                    t = addCell.FindControl(arg[0]) as TextBox;
                    t.Text = (Int32.Parse(t.Text) + Int32.Parse(arg[1])).ToString();
                    id = arg[0];
                }
                else if (sender is TextBox)
                {
                    t = (TextBox)(sender);
                    id = t.ID;
                }
                var amount = ((List<int[]>)Session["productId"]).ElementAt(Int32.Parse(id));
                amount[1] = Int32.Parse(t.Text) * amount[1] / amount[2];
                amount[2] = Int32.Parse(t.Text);
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception) { }
        }

        protected void delete(object sender, EventArgs e)
        {
            if (((List<int[]>)Session["productId"]).Count == 1)
                Session["productId"] = null;
            else
                ((List<int[]>)Session["productId"]).RemoveAt(Int32.Parse(((LinkButton)(sender)).CommandArgument));
            Response.Redirect(Request.RawUrl);
        }

        protected void buy(object sender, EventArgs e)
        {
            string message = null;
            List<Item> items = new List<Item>();
            for (int i = 0; i < ((List<int[]>)Session["productId"]).Count; i++)
            {
                ItemService.Order order = new ItemService.Order();
                order.amount = ((List<int[]>)Session["productId"]).ElementAt(i)[2];
                order.buyDay = DateTime.Today;
                order.totalPrice = ((List<int[]>)Session["productId"]).Sum(x => x[1]);
                order.buyer = new Person();
                order.buyer.id = ((PersonService.Person)Session["person"]).id;
                ItemService.Order[] orders = new ItemService.Order[1];
                orders[0] = order;
                Item item = new Item();
                item.id = ((List<int[]>)Session["productId"]).ElementAt(i)[0];
                item.rowVersion = ((byte[][])Session["rowversions"])[i];
                item.orders = orders;
                items.Add(item);
            }
            bool ok = new ItemServiceClient().setOrder(items.ToArray(), ref message);
            if(ok)
            {
                Session["rowversions"] = null;
                Session["productId"] = null;
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}