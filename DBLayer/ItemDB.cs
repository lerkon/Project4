using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataLayer;

namespace DBLayer
{
    public class ItemDB
    {
        public ItemLocal getItem(int id)
        {
            using (var entity = new dmaj0914_2Sem_5Entities1())
            {
                var i = entity.Items.Where(a => a.id == id).FirstOrDefault();
                if(i != null)
                {
                    var pic = entity.Pictures.Where(a => a.itemId == id);
                    ItemLocal item = new ItemLocal();
                    if(pic.FirstOrDefault() != null)
                    {
                        item.img = item.img = new byte[pic.LongCount()][];
                        int ii = 0;
                        foreach (var img in pic)
                        {
                            item.img[ii] = img.img;
                            ii++;
                        }
                    }
                    item.id = id;
                    item.description = i.description;
                    item.endAuction = i.endAuction;
                    item.name = i.name;
                    item.price = i.price;
                    item.startAuction = i.startAuction;
                    item.stock = i.stock;
                    item.stockRemained = i.stockRemained;
                    item.category = i.category;
                    return item;
                }
            }
            return null;
        }

        public bool setItem(ref PersonLocal person)
        {
            using (var entity = new dmaj0914_2Sem_5Entities1())
            {
                ItemLocal item = person.itemsSold.First();
                Item i = new Item() {
                    description = item.description,
                    endAuction = item.endAuction,
                    name = item.name,
                    price = item.price,
                    startAuction = item.startAuction,
                    stock = item.stock,
                    stockRemained = item.stockRemained,
                    personId = person.id,
                    category = item.category,
                };
                entity.Items.Add(i);
                if (entity.SaveChanges() == 1)
                {
                    if (item.img != null)
                    {
                        foreach (byte[] pp in item.img)
                        {
                            Picture p = new Picture();
                            p.img = pp;
                            p.itemId = i.id;
                            entity.Pictures.Add(p);
                        }
                        if (entity.SaveChanges() == 0)
                            return false;
                    }
                    person.itemsSold.Last().id = i.id;
                    return true;
                }
            }
            return false;
        }

        public void itemsSold(ref PersonLocal person)
        {
            using (var entity = new dmaj0914_2Sem_5Entities1())
            {
                int id = person.id;
                var items = entity.Items.Where(a => a.personId == id);
                if (items.FirstOrDefault() != null)
                {
                    List<ItemLocal> itemList = new List<ItemLocal>();
                    foreach (var i in items)
                    {
                        var pic = entity.Pictures.Where(a => a.itemId == i.id);
                        ItemLocal item = new ItemLocal();
                        if (pic.FirstOrDefault() != null)
                        {
                            item.img = new byte[1][];
                            item.img[0] = pic.FirstOrDefault().img;
                        }
                        item.id = i.id;
                        item.description = i.description;
                        item.endAuction = i.endAuction;
                        item.name = i.name;
                        item.price = i.price;
                        item.startAuction = i.startAuction;
                        item.stock = i.stock;
                        item.stockRemained = i.stockRemained;
                        item.category = i.category;
                        itemList.Add(item);
                    }
                    person.itemsSold = itemList;
                }
            }
        }
    }
}