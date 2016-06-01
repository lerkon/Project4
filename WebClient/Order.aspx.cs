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
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string message = null;
            Item item = new Item() { id = Int32.Parse((string)Session["productDetails"]) };
            new ItemServiceClient().getOrders(ref item, ref message);
            if (item.orders != null)
            {
                foreach (var i in item.orders)
                {
                    addToTable(i.id.ToString(), i.amount.ToString(), i.totalPrice.ToString(),
                        i.buyDay.ToShortDateString(), i.buyer.name+" "+i.buyer.surname,
                        i.buyer.phone+" "+i.buyer.email, i.buyer.address+" "+i.buyer.city+" "+i.buyer.zipCode);
                }
            }
        }

        private void addToTable(string id, string amount, string totalPrice,
            string buyDay, string customer, string telMail, string address)
        {
            HtmlGenericControl tr1 = new HtmlGenericControl("tr");
            addCell.Controls.Add(tr1);
            HtmlGenericControl td1 = new HtmlGenericControl("td");
            td1.InnerHtml = id;
            tr1.Controls.Add(td1);
            HtmlGenericControl td2 = new HtmlGenericControl("td");
            td2.InnerHtml = amount;
            tr1.Controls.Add(td2);
            HtmlGenericControl td3 = new HtmlGenericControl("td");
            td3.InnerHtml = totalPrice;
            tr1.Controls.Add(td3);
            HtmlGenericControl td4 = new HtmlGenericControl("td");
            td4.InnerHtml = buyDay;
            tr1.Controls.Add(td4);
            HtmlGenericControl td5 = new HtmlGenericControl("td");
            td5.InnerHtml = customer;
            tr1.Controls.Add(td5);
            HtmlGenericControl td6 = new HtmlGenericControl("td");
            td6.InnerHtml = telMail;
            tr1.Controls.Add(td6);
            HtmlGenericControl td7 = new HtmlGenericControl("td");
            td7.InnerHtml = address;
            tr1.Controls.Add(td7);
        }
    }
}