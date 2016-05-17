using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ModelLayer;
using ControlLayer;

namespace ServiceLayer
{
    public class ItemService : IItemService
    {
        public Item itemLocalToItem(ItemLocal item)
        {
            Item i = new Item();
            i.id = item.id;
            i.description = item.description;
            i.endAuction = item.endAuction;
            i.name = item.name;
            i.price = item.price;
            i.startAuction = item.startAuction;
            i.stock = item.stock;
            i.stockRemained = item.stockRemained;
            i.rowVersion = item.rowVersion;
            i.img = item.img;
            i.category = item.category;
            return i;
        }

        public ItemLocal itemLocalFromItem(Item item)
        {
            ItemLocal i = new ItemLocal();
            i.id = item.id;
            i.description = item.description;
            i.endAuction = item.endAuction;
            i.name = item.name;
            i.price = item.price;
            i.startAuction = item.startAuction;
            i.stock = item.stock;
            i.stockRemained = item.stockRemained;
            i.rowVersion = item.rowVersion;
            i.img = item.img;
            i.category = item.category;
            return i;
        }

        public Item getItem(int id, ref string message)
        {
            throw new NotImplementedException();
        }

        public bool setItem(Person person, ref string message)
        {
            PersonLocal p = new PersonService().personLocalFromPerson(person);
            p.itemsSold = new List<ItemLocal>();
            p.itemsSold.Add(itemLocalFromItem(person.itemsSold.First()));
            return new ItemControl().setItem(ref p, ref message);
        }

        public List<Item> itemsSold(Person person, ref string message)
        {
            PersonLocal p = new PersonService().personLocalFromPerson(person);
            new ItemControl().itemsSold(ref p, ref message);
            if(p.itemsSold != null)
            {
                List<Item> list = new List<Item>();
                foreach (var item in p.itemsSold)
                    list.Add(itemLocalToItem(item));
                return list;
            }
            return null;
        }
    }
}
