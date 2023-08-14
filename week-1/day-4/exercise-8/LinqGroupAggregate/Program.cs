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
            var productsByCategory = products.GroupBy(p => p.Category);
            foreach (var group in productsByCategory)
            {
                Console.WriteLine("Category: " + group.Key);
                foreach (var product in group)
                {
                    Console.WriteLine("  " + product.Name);
                }
            }

            // 2. Count the number of products in each category
            var productCountsByCategory = productsByCategory.Select(group => new
            {
                Category = group.Key,
                Count = group.Count()
            });
            foreach (var count in productCountsByCategory)
            {
                Console.WriteLine("Category: " + count.Category + ", Count: " + count.Count);
            }

            // 3. Calculate the total price of products in each category
            var totalPriceByCategory = productsByCategory.Select(group => new
            {
                Category = group.Key,
                TotalPrice = group.Sum(p => p.Price)
            });
            foreach (var totalPrice in totalPriceByCategory)
            {
                Console.WriteLine("Category: " + totalPrice.Category + ", Total Price: " + totalPrice.TotalPrice);
            }

            // 4. Find the most expensive product in each category
            var mostExpensiveByCategory = productsByCategory.Select(group => new
            {
                Category = group.Key,
                MostExpensiveProduct = group.OrderByDescending(p => p.Price).FirstOrDefault()
            });
            foreach (var expensive in mostExpensiveByCategory)
            {
                Console.WriteLine("Category: " + expensive.Category + ", Most Expensive: " + expensive.MostExpensiveProduct?.Name);
            }

        }
    }
}