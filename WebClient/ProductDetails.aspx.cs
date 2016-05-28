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
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string message = null;
            Item i = new ItemServiceClient().getItem(Int32.Parse((string)Session["productDetails"]), ref message);
            string img1 = "~/Icons/Picture.png";
            string img2 = "~/Icons/Picture.png";
            string img3 = "~/Icons/Picture.png";
            try
            {
                img1 = "data:image/png;base64," + Convert.ToBase64String(i.img[0], 0, i.img[0].Length);
            }
            catch (Exception) { }
            try
            {
                img2 = "data:image/png;base64," + Convert.ToBase64String(i.img[1], 0, i.img[1].Length);
            }
            catch (Exception){}
            try
            {
                img3 = "data:image/png;base64," + Convert.ToBase64String(i.img[2], 0, i.img[2].Length);
            }
            catch (Exception) { }
            fillOutFields(i.name, i.description, i.startAuction.ToShortDateString() + " - "+ i.endAuction.ToShortDateString(),
                i.stockRemained+"/"+i.stock, i.price.ToString(), i.category, img1, img2, img3);
        }

        private void fillOutFields(string namee, string description, string dateAuction,
            string stock, string price, string category, string img1, string img2, string img3)
        {
            bigPictureA.HRef = img1;
            bigPictureB.ImageUrl = img1;
            pic1a.HRef = img1;
            pic1b.ImageUrl = img1;
            pic2a.HRef = img2;
            pic2b.ImageUrl = img2;
            pic3a.HRef = img3;
            pic3b.ImageUrl = img3;
            name.InnerHtml = namee;
            descriptin.InnerHtml = description;
            HtmlGenericControl p1 = new HtmlGenericControl("p");
            p1.InnerHtml = "<b>Price: </b>" + price + " DKK";
            content.Controls.Add(p1);
            HtmlGenericControl p2 = new HtmlGenericControl("p");
            p2.InnerHtml = "<b>Auction period: </b>" + dateAuction;
            content.Controls.Add(p2);
            HtmlGenericControl p3 = new HtmlGenericControl("p");
            p3.InnerHtml = "<b>Stock: </b>" + stock;
            content.Controls.Add(p3);
            HtmlGenericControl p4 = new HtmlGenericControl("p");
            p4.InnerHtml = "<b>Category: </b>" + category;
            content.Controls.Add(p4);
        }
    }
}