namespace Day4_Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product("Laptop", "Electronics", 1000),
                new Product("Phone", "Electronics", 800),
                new Product("Shirt", "Clothing", 25),
                new Product("Jeans", "Clothing", 50),
                new Product("Book", "Books", 15),
                new Product("Headphones", "Electronics", 150),
                new Product("Watch", "Accessories", 200),
                new Product("Hat", "Accessories", 30),
            };

            // Group products by category
            var productsByCategory = products.GroupBy(p => p.category);

            // Count the number of products in each category
            Console.WriteLine("Number of products in each category:");
            foreach (var group in productsByCategory)
            {
                Console.WriteLine($"{group.Key}: {group.Count()} products");
            }

            // Calculate the total price of products in each category
            Console.WriteLine("\nTotal price of products in each category:");
            foreach (var group in productsByCategory)
            {
                double total = group.Sum(p => p.price);
                Console.WriteLine($"{group.Key}: ${total}");
            }

            // Find the most expensive product in each category
            Console.WriteLine("\nMost expensive product in each category:");
            foreach (var group in productsByCategory)
            {
                var mostExpensive = group.OrderByDescending(p => p.price).First();
                Console.WriteLine($"{group.Key}: {mostExpensive.name} (${mostExpensive.price})");
            }


        }
    }

    public class Product
    {
        public String name, category;
        public int price;

        public Product(String name, String category, int price)
        {
            this.name = name;
            this.category = category;
            this.price = price;
        }

    }

}