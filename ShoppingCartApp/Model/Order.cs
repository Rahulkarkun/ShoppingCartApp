using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Model
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }

        public List<LineItem> Items { get; set; }

        //public 

        public Order(int id, DateTime timeStamp)
        { 
            Id = id;
            TimeStamp = timeStamp;
        }

        

        public double calculateOrderPrice()
        {
            double orderCost = 0;
            foreach (LineItem lineItem in Items)
            {
                double lineItemCost = lineItem.calculateLineItemCost();
                orderCost += lineItemCost;
            }
            return orderCost;
        }

    }
}
