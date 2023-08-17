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
            var groupedProducts = products.GroupBy(product => product.Category);

            // 2. Count the number of products in each category
            var productCounts = groupedProducts.Select(group => new
            {
                Category = group.Key,
                Count = group.Count()
            });

            // 3. Calculate the total price of products in each category
            var totalPriceByCategory = groupedProducts.Select(group => new
            {
                Category = group.Key,
                TotalPrice = group.Sum(product => product.Price)
            });

            // 4. Find the most expensive product in each category
            var mostExpensiveProducts = groupedProducts.Select(group => new
            {
                Category = group.Key,
                MostExpensiveProduct = group.OrderByDescending(product => product.Price).FirstOrDefault()
            });

            // Print the results
            foreach (var count in productCounts)
            {
                Console.WriteLine($"Category: {count.Category}, Count: {count.Count}");
            }

            Console.WriteLine();

            foreach (var total in totalPriceByCategory)
            {
                Console.WriteLine($"Category: {total.Category}, Total Price: {total.TotalPrice:C}");
            }

            Console.WriteLine();

            foreach (var product in mostExpensiveProducts)
            {
                Console.WriteLine($"Category: {product.Category}, Most Expensive Product: {product.MostExpensiveProduct.Name}, Price: {product.MostExpensiveProduct.Price:C}");
            }
        }

    }
}
