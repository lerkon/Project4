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

        public List<ItemLocal> getItemsCart(int[] idList)
        {
            return new ItemDB().getItemsCart(idList);
        }

        public bool setOrders(List<ItemLocal> orders, ref string message)
        {
            bool ok = false;
            try
            {
                ok = new ItemDB().setOrders(orders);
            }
            catch (Exception)
            {
                message = "Try once again.";
            }
            return ok;
        }

        public void bought(ref PersonLocal person)
        {
            new ItemDB().bought(ref person);
        }

        public ItemLocal[] latestAdded()
        {
            return new ItemDB().latestAdded();
        }
    }
}