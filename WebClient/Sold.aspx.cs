using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebClient.ItemService;

namespace WebClient
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string message = null;
            var list = new ItemServiceClient().itemsSold(translate(), ref message);
            if (!ClientScript.IsStartupScriptRegistered("addCell") && list != null && false)
            {
                string cell = "";
                foreach (var i in list)
                {
                    string base64String = null;
                    if (i.img != null)
                        base64String = Convert.ToBase64String(i.img[0], 0, i.img[0].Length);
                    cell += string.Format("addCell('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", i.name, i.price.ToString(),
                        i.stockRemained + "/" + i.stock, i.startAuction.ToShortDateString(), i.endAuction.ToShortDateString(),
                        "data:image/png;base64," + base64String, i.category, i.id);
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), null, cell, true);
            }
            if (list != null)
            {
                foreach (var i in list)
                {
                    string pic = null;
                    if (i.img != null)
                        pic = "data:image/png;base64," + Convert.ToBase64String(i.img[0], 0, i.img[0].Length);
                    addToTable(i.name, i.price.ToString(), i.stockRemained + "/" + i.stock, i.startAuction.ToShortDateString(),
                        i.endAuction.ToShortDateString(), i.category, i.id.ToString(), pic);
                }
            }
        }

        private void addToTable(string name, string price, string stock, string startAuction, string endAuction, string category, string id, string pic)
        {
            HtmlGenericControl tr1 = new HtmlGenericControl("tr");
            addCell.Controls.Add(tr1);
            HtmlGenericControl td1 = new HtmlGenericControl("td");
            tr1.Controls.Add(td1);
            HtmlGenericControl img1 = new HtmlGenericControl("img");
            img1.Attributes.Add("src", pic);
            img1.Attributes.Add("width", "60");
            td1.Controls.Add(img1);
            HtmlGenericControl td2 = new HtmlGenericControl("td");
            tr1.Controls.Add(td2);
            LinkButton l = new LinkButton();
            l.Click += new EventHandler(redirect);
            l.Text = name;
            l.CommandArgument = id;
            td2.Controls.Add(l);
            HtmlGenericControl td3 = new HtmlGenericControl("td");
            td3.InnerHtml = price;
            tr1.Controls.Add(td3);
            HtmlGenericControl td4 = new HtmlGenericControl("td");
            td4.InnerHtml = stock;
            tr1.Controls.Add(td4);
            HtmlGenericControl td5 = new HtmlGenericControl("td");
            td5.InnerHtml = startAuction;
            tr1.Controls.Add(td5);
            HtmlGenericControl td6 = new HtmlGenericControl("td");
            td6.InnerHtml = endAuction;
            tr1.Controls.Add(td6);
            HtmlGenericControl td7 = new HtmlGenericControl("td");
            td7.InnerHtml = category;
            tr1.Controls.Add(td7);
        }

        private Person translate()
        {
            PersonService.Person person = (PersonService.Person)Session["person"];
            Person p = new Person();
            p.address = person.address;
            p.city = person.city;
            p.email = person.email;
            p.id = person.id;
            p.login = person.login;
            p.name = person.name;
            p.password = person.password;
            p.phone = person.phone;
            p.surname = person.surname;
            p.zipCode = person.zipCode;
            if (person.company != null)
            {
                p.company = new Company();
                p.company.name = person.company.name;
                p.company.description = person.company.description;
                p.company.link = person.company.link;
            }
            return p;
        }

        protected void redirect(object sender, EventArgs e)
        {
            Session["productDetails"] = ((LinkButton)(sender)).CommandArgument;
            Response.Redirect("./Order.aspx");
        }
    }
}