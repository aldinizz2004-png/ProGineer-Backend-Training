//this is answer for question { 3,4,5,6,7,8 } 1 and 2 are is sempel
partial class Program //partial is used because the class is defined in multiple files.
{
    static void Main(string[] args)
    {    //students
        var students = new List<Student>
        {
            new Student { Name = "Alice", Age = 21, Grade = 85.5 },
            new Student { Name = "Bob", Age = 22, Grade = 90.0 },
            new Student { Name = "abed", Age = 21, Grade = 50.0 },
            new Student { Name = "izz", Age = 23, Grade = 62.0 },
            new Student { Name = "malik", Age = 22, Grade = 45.0 },
            new Student { Name = "Charlie", Age = 19, Grade = 78.0 }
        };
        //products
        var products = new List<Product>    //List of products with Id, Name, Category, Price, and Stock
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 5 },
            new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 0 },
            new Product { Id = 3, Name = "Monitor", Category = "Electronics", Price = 400, Stock = 3 },
            new Product { Id = 4, Name = "Chair", Category = "Furniture", Price = 250, Stock = 7 },
            new Product { Id = 5, Name = "Desk", Category = "Furniture", Price = 600, Stock = 2 }
        };
        //orders
        var orders = new List<Order>
        {
            new Order { Id = 1, CustomerId = 101, Date = DateTime.Now, Total = 200 },
            new Order { Id = 2, CustomerId = 102, Date = DateTime.Now, Total = 500 },
            new Order { Id = 3, CustomerId = 101, Date = DateTime.Now, Total = 300 },
            new Order { Id = 4, CustomerId = 103, Date = DateTime.Now, Total = 700 },
            new Order { Id = 5, CustomerId = 102, Date = DateTime.Now, Total = 150 },
            new Order { Id = 6, CustomerId = 104, Date = DateTime.Now, Total = 900 }
        };
        //students results
        var result = students
            .Where(s => s.Age > 20 && s.Grade >= 80)
            .Select(s => s.Name);


    Console.WriteLine(string.Join(", ", result));   // Output: Alice, Bob

        var groupResults = students         //Group students by age and calculate the count and average grade for each group
            .GroupBy(s => s.Age)
            .Select(g => new
            {
                Age = g.Key,
                Count = g.Count(),
                AverageGrade = g.Average(s => s.Grade)
            });

        foreach (var group in groupResults)     //for each group, print the age, count, and average grade 
        {
            Console.WriteLine(
                $"Age: {group.Age}, Count: {group.Count}, Average: {group.AverageGrade}"// Output: Age: 21, Count: 2, Average: 67.75
            );
        }


        //products
        var productResults = products.Where(p => p.Stock > 0)    //Filter products with stock greater than 0
            .OrderByDescending(p => p.Price)
            .Take(3)
            .Select(p => new { p.Name, p.Price });

        foreach (var product in productResults){
            Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");  // Output: Product: Laptop, Price: 1200
        }
        //category
        var categoryResults = products.GroupBy(p => p.Category) //Group products by category
            .Select(g => new
            {
                Category = g.Key,
                Count = g.Count(),
                AveragePrice = g.Average(p => p.Price),
                MaxPrice = g.Max(p => p.Price)
            })
            .OrderByDescending(g => g.AveragePrice);       //Order the results by average price in descending order

            foreach (var category in categoryResults)      //for each category, print the category name, count, average price, and max price
        {
            Console.WriteLine(
                $"Category: {category.Category}, Count: {category.Count}, Average Price: {category.AveragePrice}, Max Price: {category.MaxPrice}"
            );
        }


        //orders
        var orderResults = orders.GroupBy(o => o.CustomerId)//Group orders by customer ID
            .Select(g => new
            {
                CustomerId = g.Key,
                TotalSpent = g.Sum(o => o.Total)
            })
            .OrderByDescending(g => g.TotalSpent).Take(3);//Order the results by total spent in descending order and take the top 3 customers
        
        foreach (var order in orderResults)
        {
            Console.WriteLine(
                $"CustomerId: {order.CustomerId}, Total Spent: {order.TotalSpent}"      // Output: CustomerId: 104, Total Spent: 900
            );
        }


        //Find the customer with the highest number of orders in the current year
        var resultOrder = orders
            .Where(o => o.Date.Year == DateTime.Now.Year)     //Filter orders for the current year
            .GroupBy(o => o.CustomerId)
            .Select(g => new
            {
                CustomerId = g.Key,
                NumberOfOrders = g.Count()
            })
            .OrderByDescending(x => x.NumberOfOrders)
            .FirstOrDefault();//Get the customer with the highest number of orders

        if (resultOrder != null)//Check if there is a result before printing
        {
            Console.WriteLine(
                $"CustomerId: {resultOrder.CustomerId}, Number of Orders: {resultOrder.NumberOfOrders}" // Output: CustomerId: 101, Number of Orders: 2
            );
        }
    } //end of main
} //end of program
