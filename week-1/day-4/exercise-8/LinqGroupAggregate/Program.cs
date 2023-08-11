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

            /// Use LINQ to perform the following operations:
            // 1. Group products by category
            var groupByCategory = products.GroupBy(product => product.Category);

            // 2. Count the number of products in each category
            var countProductByCategory = groupByCategory.ToDictionary(
                group => group.Key,
                group => group.Count());


            // 3. Calculate the total price of products in each category
            var totalPriceByCategory = groupByCategory.ToDictionary(
                group => group.Key,
                group => group.Sum(product => product.Price));

            // 4. Find the most expensive product in each category
            var expensiveProductByCategory = groupByCategory.Select(
                group => group.OrderBy(product => product.Price).Last());

            foreach (var item in groupByCategory)
            {
                Console.WriteLine($"Category: {item.Key}");
                Console.WriteLine($"Product Count: {countProductByCategory[item.Key]}");
                Console.WriteLine($"Total Price: {totalPriceByCategory[item.Key]}");
                Console.WriteLine($"Expensive Product: {expensiveProductByCategory.Single(p => p.Category == item.Key).Name}\n");
            }
        }
    }
}