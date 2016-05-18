using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            if (!ClientScript.IsStartupScriptRegistered("addCell") && list != null)
            {
                string cell = "";
                foreach (var i in list)
                {
                    string base64String = null;
                    if (i.img != null)
                        base64String = Convert.ToBase64String(i.img[0], 0, i.img[0].Length);
                    cell += string.Format("addCell('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", i.name, i.price.ToString(),
                        i.stockRemained + "/" + i.stock, i.startAuction.ToShortDateString(), i.endAuction.ToShortDateString(),
                        "data:image/png;base64," + base64String, i.category);
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), null, cell, true);
            }
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
    }
}