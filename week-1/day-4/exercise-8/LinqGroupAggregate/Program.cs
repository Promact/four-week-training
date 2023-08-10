namespace LinqGroupAggregate
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            // Create a list of Product objects
            List<Product> products = new List<Product>
        {
            new Product { Name = "Laptop", Category = "Electronics", Price = 1200.00M },
            new Product { Name = "Smartphone", Category = "Electronics", Price = 800.00M },
            new Product { Name = "Headphones", Category = "Electronics", Price = 200.00M },
            new Product { Name = "Shirt", Category = "Clothing", Price = 30.00M },
            new Product { Name = "Jeans", Category = "Clothing", Price = 60.00M },
            new Product { Name = "Sneakers", Category = "Footwear", Price = 100.00M }
        };
            // Use LINQ to perform the following operations:
            // 1. Group products by category
            // 2. Count the number of products in each category
            // 3. Calculate the total price of products in each category
            // 4. Find the most expensive product in each category


          
            var productscategory = products.GroupBy(product => product.Category);

            // 2. Count the number of products in each category
            var productCounts = productscategory.ToDictionary(group => group.Key, group => group.Count());

            // 3. Calculate the total price of products in each category
            var totalPrices = productscategory.ToDictionary(group => group.Key, group => group.Sum(product => product.Price));

            // 4. Find the most expensive product in each category
            var expensiveProducts = productscategory.ToDictionary(group => group.Key, group => group.OrderByDescending(product => product.Price).FirstOrDefault());


            // Print the results
            Console.WriteLine("Group products by category:");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (var group in productscategory)
            {
                Console.WriteLine("Category: " + group.Key);
                foreach (var product in group)
                {
                    Console.WriteLine($"  Product: {product.Name}, Price: {product.Price}");
                }
            }
            Console.ResetColor();
            Console.WriteLine("\nProduct Counts by Category:");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var kvp in productCounts)
            {
                Console.WriteLine($"Category: {kvp.Key}, Count: {kvp.Value}");
            }

            Console.ResetColor();
            Console.WriteLine("\nTotal Prices by Category:");

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var kvp in totalPrices)
            {
                Console.WriteLine($"Category: {kvp.Key}, Total Price: {kvp.Value:C}");
            }
            Console.ResetColor();
            Console.WriteLine("\nMost Expensive Products by Category:");
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var kvp in expensiveProducts)
            {
                Console.WriteLine($"Category: {kvp.Key}, Product: {kvp.Value?.Name}, Price: {kvp.Value?.Price:C}");
            }
            Console.ResetColor();
        }
    }

}
