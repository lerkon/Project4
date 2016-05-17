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
    public partial class Sell : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bigPicture.ImageUrl = "~/Icons/Picture.png";
            smallPicture1.ImageUrl = "~/Icons/Picture.png";
            smallPicture2.ImageUrl = "~/Icons/Picture.png";
            smallPicture3.ImageUrl = "~/Icons/Picture.png";
        }

        protected void sell(object sender, EventArgs e)
        {
            string message = null;
            Person p = translate();
            Item i = new Item();
            i.description = description.Text;
            i.name = name.Text;
            i.price = int.Parse(price.Text);
            i.stock = int.Parse(amount.Text);
            i.stockRemained = i.stock;
            i.endAuction = Convert.ToDateTime(date.Text);//Convert.ToDateTime(date.Text.Substring(3, 2) + "/" + date.Text.Substring(0, 2) + "/" + date.Text.Substring(6, 4));
            i.startAuction = DateTime.Today;
            i.category = category.Text;
            if (Session["pics"] != null)
            {
                i.img = (byte[][])Session["pics"];
                Session["pics"] = null;
            }
            p.itemsSold = new Item[1] { i };
            bool ok = new ItemServiceClient().setItem(p, ref message);
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

        protected void uploadFile_Click(object sender, EventArgs e)
        {
            if (UploadImages.HasFiles)
            {//uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/"), uploadedFile.FileName));
                byte[][] list = new byte[UploadImages.PostedFiles.Count][];
                Image[] frames = new Image[] { smallPicture1, smallPicture2, smallPicture3 };
                int ii = 0;
                foreach (HttpPostedFile uploadedFile in UploadImages.PostedFiles)
                {
                    Stream fs = uploadedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    list[ii] = bytes;
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    frames[ii].ImageUrl = "data:image/png;base64," + base64String;
                    ii++;
                }
                bigPicture.ImageUrl = smallPicture1.ImageUrl;
                Session["pics"] = list;
            }
        }
    }
}