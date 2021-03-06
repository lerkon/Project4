﻿using System;
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

        public OrderLocal OrderLocalFromOrder(Order item)
        {
            OrderLocal i = new OrderLocal();
            i.amount = item.amount;
            i.buyDay = item.buyDay;
            i.buyer = new PersonService().personLocalFromPerson(item.buyer);
            i.id = item.id;
            i.totalPrice = item.totalPrice;
            return i;
        }

        public Order OrderFromOrderLocal(OrderLocal item)
        {
            Order i = new Order();
            i.amount = item.amount;
            i.buyDay = item.buyDay;
            //i.buyer = new PersonService().personLocalFromPerson(item.buyer);
            i.id = item.id;
            i.totalPrice = item.totalPrice;
            return i;
        }

        public Item getItem(int id, ref string message)
        {
            return itemLocalToItem(new ItemControl().getItem(id, ref message));
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

        public List<Item> getItemsCategory(string category, ref string message)
        {
            List<ItemLocal> i = new ItemControl().getItemsCategory(category);
            if (i != null)
            {
                List<Item> list = new List<Item>();
                foreach (var item in i)
                    list.Add(itemLocalToItem(item));
                return list;
            }
            return null;
        }

        public List<Item> getItemsCart(int[] idList, ref string message)
        {
            List<ItemLocal> i = new ItemControl().getItemsCart(idList);
            if (i != null)
            {
                List<Item> list = new List<Item>();
                foreach (var item in i)
                    list.Add(itemLocalToItem(item));
                return list;
            }
            return null;
        }

        public void getOrders(ref Item item, ref string message)
        {
            ItemLocal i = itemLocalFromItem(item);
            new ItemControl().getOrders(ref i, ref message);
            if (i.orders != null)
            {
                List<Order> list = new List<Order>();
                foreach (var ii in i.orders)
                {
                    Order o = OrderFromOrderLocal(ii);
                    o.buyer = new PersonService().personLocalToPerson(ii.buyer);
                    list.Add(o);
                }
                item.orders = list;
            }
        }

        public bool setOrder(List<Item> orders, ref string message)
        {
            List<ItemLocal> list = new List<ItemLocal>();
            foreach (var i in orders)
            {
                OrderLocal ol = OrderLocalFromOrder(i.orders.FirstOrDefault());
                List<OrderLocal> localList = new List<OrderLocal>();
                localList.Add(ol);
                ItemLocal il = itemLocalFromItem(i);
                il.orders = localList;
                list.Add(il);
            }
            return new ItemControl().setOrders(list, ref message);
        }

        public void bought(ref Person person, ref string message)
        {
            PersonLocal p = new PersonService().personLocalFromPerson(person);
            new ItemControl().bought(ref p);
            if (p.itemsBought != null)
            {
                List<Item> list = new List<Item>();
                foreach (var item in p.itemsBought)
                {
                    List<Order> listO = new List<Order>();
                    foreach (var order in item.orders)
                        listO.Add(OrderFromOrderLocal(order));
                    list.Add(itemLocalToItem(item));
                    list.Last().orders = listO;
                }
                person.itemsBought = list;
            }
        }

        public Item[] latestAdded(ref string message)
        {
            ItemLocal[] itemsLocal = new ItemControl().latestAdded(ref message);
            if (itemsLocal != null)
            {
                Item[] items = new Item[itemsLocal.Count()];
                for (int i = 0; i < itemsLocal.Count(); i++)
                    items[i] = itemLocalToItem(itemsLocal[i]);
                return items;
            }
            return null;
        }

        public void getComments(ref Item item, ref string message)
        {
            ItemLocal iL = itemLocalFromItem(item);
            new ItemControl().getComments(ref iL, ref message);
            if(iL.comments != null)
            {
                item.comments = new List<Comment>();
                foreach (var comment in iL.comments)
                    item.comments.Add(commentLocalToComment(comment));
            }
        }

        public bool setComment(ref Item item, ref string message)
        {
            ItemLocal iL = itemLocalFromItem(item);
            if (item.comments != null)
            {
                iL.comments = new List<CommentLocal>();
                iL.comments.Add(commentLocalFromComment(item.comments.FirstOrDefault()));
            }
            return new ItemControl().setComment(ref iL, ref message);
        }

        public Comment commentLocalToComment(CommentLocal comment)
        {
            Comment c = new Comment();
            c.comment = comment.comment;
            c.commentDay = comment.commentDay;
            c.id = comment.id;
            c.person = new PersonService().personLocalToPerson(comment.person);
            return c;
        }

        public CommentLocal commentLocalFromComment(Comment comment)
        {
            CommentLocal c = new CommentLocal();
            c.comment = comment.comment;
            c.commentDay = comment.commentDay;
            c.id = comment.id;
            c.person = new PersonService().personLocalFromPerson(comment.person);
            return c;
        }
    }
}