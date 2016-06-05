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
                    rowVersion = item.rowVersion,
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
                        item.rowVersion = i.rowVersion;
                        itemList.Add(item);
                    }
                    person.itemsSold = itemList;
                }
            }
        }

        public List<ItemLocal> getItemsCategory(string category)
        {
            using (var entity = new dmaj0914_2Sem_5Entities1())
            {
                var items = entity.Items.Where(a => a.category == category);
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
                        item.rowVersion = i.rowVersion;
                        itemList.Add(item);
                    }
                    return itemList;
                }
            }
            return null;
        }

        public List<ItemLocal> getItemsCart(int[] idList)
        {
            using (var entity = new dmaj0914_2Sem_5Entities1())
            {
                List<ItemLocal> itemList = new List<ItemLocal>();
                foreach (var idFromList in idList)
                {
                    var itemm = entity.Items.Where(a => a.id == idFromList);
                    if (itemm.FirstOrDefault() != null)
                    {
                        foreach (var i in itemm)
                        {
                            var pic = entity.Pictures.Where(a => a.itemId == i.id);
                            ItemLocal item = new ItemLocal();
                            if (pic.FirstOrDefault() != null)
                            {
                                item.img = new byte[1][];
                                item.img[0] = pic.FirstOrDefault().img;
                            }
                            item.id = i.id;
                            item.name = i.name;
                            item.price = i.price;
                            item.stock = i.stock;
                            item.stockRemained = i.stockRemained;
                            item.rowVersion = i.rowVersion;
                            itemList.Add(item);
                        }
                    }
                }
                if (itemList.Count() == 0)
                    return null;
                else
                    return itemList;
            }
        }

        public bool setOrders(List<ItemLocal> orders)
        {
            using (var entity = new dmaj0914_2Sem_5Entities1())
            {
                foreach (var i in orders)
                {
                    var item = entity.Items.Where(a => a.id == i.id).FirstOrDefault();
                    if (item != null)
                    {
                        item.rowVersion = i.rowVersion;
                        item.stockRemained -= i.orders.FirstOrDefault().amount;
                        if (item.stockRemained >= 0 && entity.SaveChanges() != 0)
                        {
                            Orderr order = new Orderr();
                            order.amount = i.orders.FirstOrDefault().amount;
                            order.buyDay = i.orders.FirstOrDefault().buyDay;
                            order.itemId = i.id;
                            order.personBuyerId = item.personId;
                            order.totalPrice = i.orders.FirstOrDefault().totalPrice;
                            entity.Orderrs.Add(order);
                            if (entity.SaveChanges() == 1)
                                return true;
                            else
                            {
                                item.stockRemained += i.orders.FirstOrDefault().amount;
                                if (entity.SaveChanges() == 1)
                                    return false;
                            }
                        }
                        else
                            entity.Items = null;
                    }
                }
            }
            return false;
        }

        public void bought(ref PersonLocal person)
        {
            using (var entity = new dmaj0914_2Sem_5Entities1())
            {
                int id = person.id;
                var orders = entity.Orderrs.Where(a => a.personBuyerId == id);
                int aaa = orders.Count();
                if (orders.FirstOrDefault() != null)
                {
                    List<ItemLocal> itemList = new List<ItemLocal>();
                    var itemIds = orders.GroupBy(x => x.itemId).Select(y => y.FirstOrDefault().itemId).Distinct();
                    foreach (var id2 in itemIds)
                    {
                        var items = entity.Items.Where(a => a.id == id2).FirstOrDefault();
                        var pic = entity.Pictures.Where(a => a.itemId == id2);
                        ItemLocal item = new ItemLocal();
                        if (pic.FirstOrDefault() != null)
                        {
                            item.img = new byte[1][];
                            item.img[0] = pic.FirstOrDefault().img;
                        }
                        item.id = items.id;
                        item.name = items.name;
                        item.price = items.price;
                        item.category = items.category;
                        item.orders = new List<OrderLocal>();
                        var orders2 = entity.Orderrs.Where(a => a.itemId == items.id);
                        foreach (var item2 in orders2)
                        {
                            OrderLocal o = new OrderLocal();
                            o.amount = item2.amount;
                            o.buyDay = item2.buyDay;
                            o.totalPrice = item2.totalPrice;
                            item.orders.Add(o);
                        }
                        itemList.Add(item);
                    }
                    person.itemsBought = itemList;
                }
            }
        }

        public ItemLocal[] latestAdded()
        {
            using (var entity = new dmaj0914_2Sem_5Entities1())
            {
                var items = entity.Items.OrderByDescending(p => p.id).Take(6);
                if (items.FirstOrDefault() != null)
                {
                    ItemLocal[] itemList = new ItemLocal[items.Count()];
                    for (int ii = 0; ii < items.Count(); ii++)
                    {
                        Item i = items.Skip(ii).FirstOrDefault();
                        ItemLocal item = new ItemLocal();
                        var pic = entity.Pictures.Where(a => a.itemId == i.id);
                        if (pic.FirstOrDefault() != null)
                        {
                            item.img = new byte[1][];
                            item.img[0] = pic.FirstOrDefault().img;
                        }
                        item.id = i.id;
                        item.name = i.name;
                        item.price = i.price;
                        item.stock = i.stock;
                        item.stockRemained = i.stockRemained;
                        item.category = i.category;
                        itemList[ii] = item;
                    }
                    return itemList;
                }
            }
            return null;
        }

        public void getOrders(ref ItemLocal item)
        {
            using (var entity = new dmaj0914_2Sem_5Entities1())
            {
                int idItem = item.id;
                var orders = entity.Orderrs.Where(a => a.itemId == idItem).OrderBy(x => x.buyDay);
                if (orders.FirstOrDefault() != null)
                {
                    item.orders = new List<OrderLocal>();
                    foreach (var o in orders)
                    {
                        var person = entity.People.Where(a => a.id == o.personBuyerId).FirstOrDefault();
                        OrderLocal ol = new OrderLocal();
                        ol.amount = o.amount;
                        ol.buyDay = o.buyDay;
                        ol.id = o.id;
                        ol.totalPrice = o.totalPrice;
                        ol.buyer = new PersonLocal();
                        ol.buyer.address = person.address;
                        ol.buyer.city = person.city;
                        ol.buyer.email = person.email;
                        ol.buyer.name = person.name;
                        ol.buyer.surname = person.surname;
                        ol.buyer.phone = person.phone;
                        ol.buyer.zipCode = person.zipCode;
                        item.orders.Add(ol);
                    }
                }
            }
        }

        public bool setComment(ref ItemLocal item)
        {
            using (var entity = new dmaj0914_2Sem_5Entities1())
            {
                int idItem = item.id;
                Comment c = new Comment();
                c.itemId = item.id;
                c.comment1 = item.comments.FirstOrDefault().comment;
                c.personId = item.comments.FirstOrDefault().person.id;
                c.commentDay = item.comments.FirstOrDefault().commentDay;
                entity.Comments.Add(c);
                if (entity.SaveChanges() == 1)
                    return true;
            }
            return false;
        }

        public void getComments(ref ItemLocal item)
        {
            using (var entity = new dmaj0914_2Sem_5Entities1())
            {
                int idItem = item.id;
                var comments = entity.Comments.Where(a => a.itemId == idItem);
                if (comments.FirstOrDefault() != null)
                {
                    List<CommentLocal> commentsList = new List<CommentLocal>();
                    foreach (var comment in comments)
                    {
                        CommentLocal c = new CommentLocal();
                        c.comment = comment.comment1;
                        c.commentDay = comment.commentDay;
                        c.id = comment.id;
                        var person = entity.People.Where(a => a.id == comment.personId).FirstOrDefault();
                        c.person = new PersonLocal();
                        c.person.name = person.name;
                        c.person.surname = person.surname;
                        c.person.id = person.id;
                        commentsList.Add(c);
                    }
                    item.comments = commentsList;
                }
            }
        }
    }
}