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
            Add();
        }

        private void Add()
        {
            Item[] items = new ItemServiceClient().latestAdded();

        }
    }
}