using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.ItemService;

namespace WebClient
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Add();
            }
            catch (Exception){}
        }

        private string translate(byte[] b)
        {
            return "data:image/png;base64," + Convert.ToBase64String(b, 0, b.Length);
        }

        private void Add()
        {
            string message = null;
            Item[] items = new ItemServiceClient().latestAdded(ref message);
            imgLatest1.ImageUrl = translate(items[0].img[0]);
            linkLatest1.CommandArgument = items[0].id.ToString();
            nameLatest1.InnerHtml = items[0].name;
            stockLatest1.InnerHtml = "Stock: " + items[0].stockRemained + "/" + items[0].stock;
            cartLatest1.CommandArgument = items[0].id + ";" + items[0].price;
            priceLatest1.InnerHtml = items[0].price + " DKK";

            imgLatest2.ImageUrl = translate(items[1].img[0]);
            linkLatest2.CommandArgument = items[1].id.ToString();
            nameLatest2.InnerHtml = items[1].name;
            cartLatest2.CommandArgument = items[1].id + ";" + items[1].price;
            stockLatest2.InnerHtml = "Stock: " + items[1].stockRemained + "/" + items[1].stock;
            priceLatest2.InnerHtml = items[1].price + " DKK";

            imgLatest3.ImageUrl = translate(items[2].img[0]);
            linkLatest3.CommandArgument = items[2].id.ToString();
            nameLatest3.InnerHtml = items[2].name;
            cartLatest3.CommandArgument = items[2].id + ";" + items[2].price;
            stockLatest3.InnerHtml = "Stock: " + items[2].stockRemained + "/" + items[2].stock;
            priceLatest3.InnerHtml = items[2].price + " DKK";

            imgLatest4.ImageUrl = translate(items[3].img[0]);
            linkLatest4.CommandArgument = items[3].id.ToString();
            nameLatest4.InnerHtml = items[3].name;
            cartLatest4.CommandArgument = items[3].id + ";" + items[3].price;
            stockLatest4.InnerHtml = "Stock: " + items[3].stockRemained + "/" + items[3].stock;
            priceLatest4.InnerHtml = items[3].price + " DKK";

            imgLatest5.ImageUrl = translate(items[4].img[0]);
            linkLatest5.CommandArgument = items[4].id.ToString();
            nameLatest5.InnerHtml = items[4].name;
            cartLatest5.CommandArgument = items[4].id + ";" + items[4].price;
            stockLatest5.InnerHtml = "Stock: " + items[4].stockRemained + "/" + items[4].stock;
            priceLatest5.InnerHtml = items[4].price + " DKK";

            imgLatest6.ImageUrl = translate(items[5].img[0]);
            linkLatest6.CommandArgument = items[5].id.ToString();
            nameLatest6.InnerHtml = items[5].name;
            cartLatest6.CommandArgument = items[5].id + ";" + items[5].price;
            stockLatest6.InnerHtml = "Stock: " + items[5].stockRemained + "/" + items[5].stock;
            priceLatest6.InnerHtml = items[5].price + " DKK";
        }

        protected void redirect(object sender, EventArgs e)
        {
            Session["productDetails"] = ((LinkButton)(sender)).CommandArgument;
            Response.Redirect("./ProductDetails.aspx");
        }

        protected void addProductCart(object sender, EventArgs e)
        {
            string[] arg = ((LinkButton)(sender)).CommandArgument.Split(';');
            if (Session["productId"] == null)
                Session["productId"] = new List<int[]>();
            var amount = ((List<int[]>)Session["productId"]).FindAll(x => x[0] == Int32.Parse(arg[0]));
            if (amount.SingleOrDefault() != null)
            {
                amount.Single()[1] = amount.Single()[1] * 2;
                amount.Single()[2]++;
            }
            else//id,price,amount
                ((List<int[]>)Session["productId"]).Add(new int[3] { Int32.Parse(arg[0]), Int32.Parse(arg[1]), 1 });
            ((MasterPage)this.Master).changeCart();
        }
    }
}