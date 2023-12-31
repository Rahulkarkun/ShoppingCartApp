﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Model
{
    internal class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }

        public Customer(int id,string name, List<Order> orders) 
        { 
            Id = id;
            Name = name;
            Orders = orders;
        }

        public override string ToString()
        {
            return $"CustomerId: {Id}\n" +
                $"Customer Name: {Name}\n" +
                $"Order Count: {Orders.Count}";
        }
    }

}
