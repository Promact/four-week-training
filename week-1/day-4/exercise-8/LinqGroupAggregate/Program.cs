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

            // a. Group products by category
            var groupProducts = products.GroupBy(product => product.Category);

            foreach (var group in groupProducts)
            {
                Console.WriteLine("Category: " + group.Key);
                foreach (var product in group)
                {
                    Console.WriteLine("Product: " + product.Name);
                }
            }

            // b. Count the number of products in each category
            var count = products.GroupBy(product => product.Category)
                                                 .Select(group => new { Category = group.Key, Count = group.Count() });

            Console.WriteLine("\nProducts count in each category:");
            foreach (var result in count)
            {
                Console.WriteLine($"Category: {result.Category}, Count: {result.Count}");
            }

            // c. Calculate the total price of products in each category
            var total = products.GroupBy(product => product.Category)
                                                .Select(group => new { Category = group.Key, TotalPrice = group.Sum(product => product.Price) });

            Console.WriteLine("\nTotal price of products in each category:");
            foreach (var result in total)
            {
                Console.WriteLine($"Category: {result.Category}, Total Price: {result.TotalPrice}");
            }

            // d. Find the most expensive product in each category
            var costly = products.GroupBy(product => product.Category)
                                                 .Select(group => new { Category = group.Key, MostExpensive = group.Max(product => product.Price) });

            Console.WriteLine("\nMost expensive product in each category:");
            foreach (var output in costly)
            {
                Console.WriteLine($"Category: {output.Category}, Most Expensive: {output.MostExpensive}");
            }
        }
    }
}