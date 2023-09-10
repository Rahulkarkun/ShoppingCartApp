using ShoppingCartApp.Model;

namespace ShoppingCartApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create products
            Product product1 = new Product(1, "Slice", 100, 10);
            Product product2 = new Product(2, "Maaza", 50, 5);

            // Create line items for the first order (Order No: 1)
            LineItem lineItem1 = new LineItem(1, 3, product1);
            LineItem lineItem2 = new LineItem(2, 5, product2);

            // Create the first order (Order No: 1)
            Order order1 = new Order(101, DateTime.Now);
            order1.Items = new List<LineItem> { lineItem1, lineItem2 };

            Product product3 = new Product(1, "Marie", 100, 10);
            Product product4 = new Product(2, "GoodDay", 50, 5);

            // Create line items for the second order (Order No: 2)
            LineItem lineItem3 = new LineItem(3, 2, product3);
            LineItem lineItem4 = new LineItem(4, 4, product4);

            // Create the second order (Order No: 2)
            Order order2 = new Order(2, DateTime.Now); // Change the order date as needed
            order2.Items = new List<LineItem> { lineItem3, lineItem4 };

            // Create a customer and add both orders
            Customer customer1 = new Customer(101, "Rahul", new List<Order> { order1, order2 });

            // Print customer information
            Console.WriteLine(customer1.ToString());

            

            // Print order information
            foreach (var order in customer1.Orders)
            {
                Console.WriteLine($"Order No: {order.Id}");
                Console.WriteLine($"Order Id: {order.Id}");
                Console.WriteLine($"Order Date: {order.TimeStamp:dd-MM-yyyy HH:mm:ss}");

                // Print header row
                Console.WriteLine("LineItemId ProductId ProductName Quantity UnitPrice Discount% UnitCostAfterDiscount TotalLineItemCost");

                // Print line items in the order
                foreach (var lineItem in order.Items)
                {
                    // Calculate and print UnitCostAfterDiscount and TotalLineItemCost
                    double unitCostAfterDiscount = lineItem.Product.calculateDiscountedPrice();
                    //double unitCostAfterDiscount = discountedPrice;
                    double totalLineItemCost = unitCostAfterDiscount * lineItem.Quantity;

                    // Print line item details with formatting
                    Console.WriteLine($"{lineItem.Id,-12} {lineItem.Product.Id,-9} {lineItem.Product.Name,-12} {lineItem.Quantity,-8} {lineItem.Product.Price,-9} {lineItem.Product.DiscountPercent,-10} {unitCostAfterDiscount,-18} {totalLineItemCost}");
                }

                // Calculate and print the total cost of all line items in the order
                double totalOrderCost = order.calculateOrderPrice();

                //Console.WriteLine($"Order Cost: {totalOrderCost,76}\n");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t    -----------------");
                //Console.WriteLine($"                                                   " +
                //    $"            -----------------");
                Console.WriteLine($"\t\t\t\t\t\t\t\t\t\t    Order Cost: {totalOrderCost}\n");
            }
        }
    }
}