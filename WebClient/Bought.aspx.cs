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
    public partial class Bought : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string message = null;
            Person p = translate();
            new ItemServiceClient().bought(ref p, ref message);
            foreach (var item in p.itemsBought)
            {
                string img = null;
                if (item.img != null)
                    img = "data:image/png;base64," + Convert.ToBase64String(item.img[0], 0, item.img[0].Length);
                foreach (var o in item.orders)
                {
                    addRow(item.id.ToString(), item.name, o.buyDay.ToShortDateString(), item.category,
                        o.amount.ToString(), item.price.ToString(), o.totalPrice.ToString(), img);
                }
            }
        }

        private void addRow(string id, string name, string boughtDay, string category,
            string amount, string price, string total, string img)
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
            tr1.Controls.Add(td2);
            LinkButton l = new LinkButton();
            l.Click += new EventHandler(redirect);
            l.Text = name;
            l.CommandArgument = id;
            td2.Controls.Add(l);
            HtmlGenericControl td3 = new HtmlGenericControl("td");
            td3.InnerHtml = boughtDay;
            tr1.Controls.Add(td3);
            HtmlGenericControl td4 = new HtmlGenericControl("td");
            td4.InnerHtml = category;
            tr1.Controls.Add(td4);
            HtmlGenericControl td5 = new HtmlGenericControl("td");
            td5.InnerHtml = amount;
            tr1.Controls.Add(td5);
            HtmlGenericControl td6 = new HtmlGenericControl("td");
            td6.InnerHtml = price;
            tr1.Controls.Add(td6);
            HtmlGenericControl td7 = new HtmlGenericControl("td");
            td7.InnerHtml = total;
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
            Response.Redirect("./ProductDetails.aspx");
        }
    }
}