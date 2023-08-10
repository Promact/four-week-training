namespace LinqGroupAggregate
{
    public class Program
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

            // Group products by category
            var GroupByCategory = products.GroupBy(product => product.Category);

            // Count the number of products in each category
            Console.WriteLine("Number of Products in Each Category:");
            foreach (var group in GroupByCategory)
            {
                Console.WriteLine($"{group.Key}: {group.Count()} products");
            }

            // Calculate the total price of products in each category
            Console.WriteLine("\nTotal Price of Products in Each Category:");
            foreach (var group in GroupByCategory)
            {
                decimal totalPrice = group.Sum(product => product.Price);
                Console.WriteLine($"{group.Key}: ${totalPrice}");
            }

            // Find the most expensive product in each category
            Console.WriteLine("\nMost Expensive Product in Each Category:");
            foreach (var group in GroupByCategory)
            {
                var mostExpensiveProduct = group.OrderByDescending(product => product.Price).FirstOrDefault();
                if (mostExpensiveProduct != null)
                {
                    Console.WriteLine($"{group.Key}: {mostExpensiveProduct.Name} => ${mostExpensiveProduct.Price}");
                }
            }
        }
    }
}