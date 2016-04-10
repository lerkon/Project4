using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.PersonService;

namespace WebClient
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["person"] != null)
            {
                Session.Abandon();//Response.Redirect("~/Login.aspx");
                Response.Redirect(Request.RawUrl);
            }
        }

        [WebMethod]
        public static string login(string username, string password)
        {
            string message = null;
            Person p = new PersonServiceClient().login(username, password, ref message);
            if (p != null)
                new Login().savePerson(p);
            return message;
        }

        protected void savePerson(Person p)
        {
            Session["person"] = p;
        }
    }
}