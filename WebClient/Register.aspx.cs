using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.PersonService;

namespace WebClient
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerr(object sender, EventArgs e)
        {
            string message = null;
            Person p = new Person();
            p.login = login.Text;
            p.name = name.Text;
            p.password = password.Text;
            p.phone = phone.Text;
            p.surname = surname.Text;
            p.zipCode = int.Parse(zipCode.Text);
            p.city = "aaa";
            p.address = address.Text;
            p.email = email.Text;
            if (!string.IsNullOrWhiteSpace(companyName.Text))
            {
                Company c = new Company();
                c.name = companyName.Text;
                c.description = description.Text;
                c.link = website.Text;
                p.company = c;
            }
            Person p2 = new PersonServiceClient().setPerson(p, ref message);
        }
    }
}