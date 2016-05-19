using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DBLayer;
using DataLayer;

namespace ControlLayer
{
    public class ItemControl
    {
        public ItemLocal getItem(int id, ref string message)
        {
            ItemLocal i = new ItemDB().getItem(id);
            if (i == null)
                message = "Try once again.";
            return i;
        }

        public bool setItem(ref PersonLocal person, ref string message)
        {
            bool ok = new ItemDB().setItem(ref person);
            if (ok == false)
                message = "Try once again.";
            return ok;
        }

        public void itemsSold(ref PersonLocal person, ref string message)
        {
            new ItemDB().itemsSold(ref person);
        }

        public List<ItemLocal> getItemsCategory(string category)
        {
            return new ItemDB().getItemsCategory(category);
        }
    }
}