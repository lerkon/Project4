using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.PersonService;

namespace WebClient
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["person"] == null)
                infoFrame.Style.Add("display", "");
            else
            {
                if (!Page.IsPostBack)
                {
                    Person p = (Person)Session["person"];
                    address.Text = p.address;
                    email.Text = p.email;
                    login.Text = p.login;
                    name.Text = p.name;
                    password.Text = p.password;
                    phone.Text = p.phone;
                    surname.Text = p.surname;
                    zipCode.Text = p.zipCode.ToString();
                    if (p.company != null)
                    {
                        companyName.Text = p.company.name;
                        website.Text = p.company.link;
                        description.Text = p.company.description;
                        checkBox.Checked = true;
                        box.Style.Add("display", "");
                    }
                }
                updateFrame.Style.Add("display", "");
            }
        }

        protected void update(object sender, EventArgs e)
        {
            labelBox.Style.Add("display", "none");
            string message = null;
            Person p = (Person)Session["person"];
            p.address = address.Text;
            p.city = "aaa";
            p.email = email.Text;
            p.login = login.Text;
            p.name = name.Text;
            p.password = password.Text;
            p.phone = phone.Text;
            p.surname = surname.Text;
            p.zipCode = int.Parse(zipCode.Text);
            if (checkBox.Checked)
            {
                p.company = new Company();
                p.company.name = companyName.Text;
                p.company.link = website.Text;
                p.company.description = description.Text;
            }
            else
                p.company = null;
            bool ok = new PersonServiceClient().updatePerson(p, ref message);
            if (ok)
            {
                Session["person"] = p;
                label.Text = "Changed";
                labelBox.Style.Add("display", "");
            }
            else
            {
                label.Text = message;
                labelBox.Style.Add("display", "");
            }
        }

        protected void tick(object sender, EventArgs e)
        {
            if (checkBox.Checked)
                box.Style.Add("display", "");
            else
                box.Style.Add("display", "none");
        }
    }
}