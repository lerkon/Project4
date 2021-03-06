﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceLayer
{
    [ServiceContract]
    public interface IItemService
    {
        [OperationContract]
        [FaultContract(typeof(ItemFault))]
        Item getItem(int id, ref string message);

        [OperationContract]
        [FaultContract(typeof(ItemFault))]
        bool setItem(Person person, ref string message);

        [OperationContract]
        [FaultContract(typeof(ItemFault))]
        List<Item> itemsSold(Person person, ref string message);

        [OperationContract]
        [FaultContract(typeof(ItemFault))]
        List<Item> getItemsCategory(string category, ref string message);

        [OperationContract]
        [FaultContract(typeof(ItemFault))]
        List<Item> getItemsCart(int[] idList, ref string message);

        [OperationContract]
        [FaultContract(typeof(ItemFault))]
        void getOrders(ref Item item, ref string message);

        [OperationContract]
        [FaultContract(typeof(ItemFault))]
        bool setOrder(List<Item> orders, ref string message);

        [OperationContract]
        [FaultContract(typeof(ItemFault))]
        void bought(ref Person person, ref string message);

        [OperationContract]
        [FaultContract(typeof(ItemFault))]
        Item[] latestAdded(ref string message);

        [OperationContract]
        [FaultContract(typeof(ItemFault))]
        void getComments(ref Item item, ref string message);

        [OperationContract]
        [FaultContract(typeof(ItemFault))]
        bool setComment(ref Item item, ref string message);
    }

    [DataContract]
    public class Item
    {
        [DataMember]
        public string FaultMessage { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public byte[] rowVersion { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int price { get; set; }
        [DataMember]
        public int stock { get; set; }
        [DataMember]
        public int stockRemained { get; set; }
        [DataMember]
        public DateTime startAuction { get; set; }
        [DataMember]
        public DateTime endAuction { get; set; }
        [DataMember]
        public List<Order> orders { get; set; }
        [DataMember]
        public List<Comment> comments { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public byte[][] img { get; set; }
        [DataMember]
        public string category { get; set; }
    }

    [DataContract]
    public class Order
    {
        [DataMember]
        public string FaultMessage { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int amount { get; set; }
        [DataMember]
        public int totalPrice { get; set; }
        [DataMember]
        public Person buyer { get; set; }
        [DataMember]
        public DateTime buyDay { get; set; }
    }

    [DataContract]
    public class Comment
    {
        [DataMember]
        public string FaultMessage { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public Person person { get; set; }
        [DataMember]
        public string comment { get; set; }
        [DataMember]
        public DateTime commentDay { get; set; }
    }

    [DataContract]
    public class ItemFault
    {
        public ItemFault(string msg)
        {
            FaultMessage = msg;
        }

        [DataMember]
        public string FaultMessage;
    }
}