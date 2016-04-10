using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.ItemService;
using WebClient.PersonService;

public partial class Sell : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["person"] == null)
            infoFrame.Style.Add("display", "");
        else
            sellFrame.Style.Add("display", "");
    }

    protected void sell(object sender, EventArgs e)
    {
        string message = null;
        Person p = (Person)Session["person"];
        Item i = new Item();
        i.description = description.Text;
        i.name = name.Text;
        i.price = int.Parse(price.Text);
        i.stock = int.Parse(amount.Text);
        i.endAuction = Convert.ToDateTime(date.Text);
        i.startAuction = DateTime.Today;
        //i.img
        p.itemsSold = new Item[1] { i };
        bool ok = new ItemServiceClient().setItem(p, ref message);
    }
}