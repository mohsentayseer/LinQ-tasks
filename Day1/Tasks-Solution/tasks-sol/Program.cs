using System.Runtime.Intrinsics.X86;
using tasks_sol;
using static tasks_sol.ListGenerators;

#region  LINQ - Restriction Operators

///1. Find all products that are out of stock.
//var prods = ProductList.Where(p => p.UnitsInStock == 0).Select(p =>p);
//foreach (var prod in prods) Console.WriteLine($"proID:{prod.ProductID} \t proName:{prod.ProductName}");

///2. Find all products that are in stock and cost more than 3.00 per unit.
//var prods = ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice>3).Select(p =>p);
//Console.WriteLine(prods.Count());
//foreach (var prod in prods) Console.WriteLine($"proID:{prod.ProductID} \t unitPrice:{prod.UnitPrice} \t {prod.UnitsInStock} \t proName:{prod.ProductName}");

///3. Returns digits whose name is shorter than their value.
//string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
//var digits = Arr.Select((n, i) => new { name = n, index = i }).Where(x => x.name.Length < x.index);
//foreach (var digit in digits) Console.WriteLine($"{digit.index} length of name:{digit.name.Length}");
#endregion

#region LINQ - Element Operators

//1. Get first Product out of Stock 
//var productList = ProductList.First(p=>p.UnitsInStock==0);
//Console.WriteLine(productList);

//2.Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
//var productList = ProductList.FirstOrDefault(p => p.UnitPrice == 1000);
//Console.WriteLine(productList);

//3. Retrieve the second number greater than 5 
//int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
//var num = Arr.Where(p => p > 5).Skip(1).FirstOrDefault();
//Console.WriteLine(num);

#endregion

#region LINQ - Set Operators 
//1.Find the unique Category names from Product List
//var productList = ProductList.Select(p => p.Category).Distinct();
//foreach (var category in productList)
//{
//    Console.WriteLine(category);
//}

//2. Produce a Sequence containing the unique first letter from both product and customer names.
//var firstLetterprodList = ProductList.Select(p => p.ProductName[0]).Distinct();
//var firstLettercustName = CustomerList.Select(p => p.CompanyName[0]).Distinct();
//var result = firstLetterprodList.Union(firstLettercustName);
//foreach (var res in result)
//{
//    Console.WriteLine(res);
//}
//3. Create one sequence that contains the common first letter from both product and customer names.
//var firstLetterprodList = ProductList.Select(p => p.ProductName[0]).Distinct();
//var firstLettercustName = CustomerList.Select(p => p.CompanyName[0]).Distinct();
//var result = firstLetterprodList.Intersect(firstLettercustName);
//foreach (var res in result)
//{
//    Console.WriteLine(res);
//}

//4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.
//var result = ProductList.Select(p => p.ProductName[0]).Except(CustomerList.Select(p => p.CompanyName[0]));
//foreach (var res in result)
//{
//    Console.WriteLine(res);
//}

//5. Create one sequence that contains the last Three Characters in each names of all customers and products, including any duplicates
//var seq1 = ProductList.Select(p => p.ProductName.Length >= 3 ? p.ProductName.Substring(p.ProductName.Length - 3) : p.ProductName);
//var seq2 = CustomerList.Select(c => c.CompanyName.Length >= 3 ? c.CompanyName.Substring(c.CompanyName.Length - 3) : c.CompanyName);
//var result = seq1.Concat(seq2);
//foreach (var res in result)
//{
//    Console.WriteLine(res);
//}
#endregion

#region LINQ - Aggregate Operators
//1.Uses Count to get the number of odd numbers in the array
//int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
//var result = Arr.Count(n=>n % 2 == 0);
//Console.WriteLine(result);

//2.Return a list of customers and how many orders each has.
//var Customers = CustomerList.Select((c) => new { Customer = c.CustomerID, Order = c.Orders.Count() });
//Console.WriteLine(Customers.Count());
//foreach (var customer in Customers) Console.WriteLine(customer);

//3. Return a list of categories and how many products each has
//var products = ProductList.GroupBy(p => p.Category).Select((p)=> new { Category = p.Key, ProductCount = p.Count() });
//foreach (var product in products)
//{
//    Console.WriteLine(product);
//}

//4. Get the total of the numbers in an array.
//int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
//Console.WriteLine(Arr.Sum());

//5.Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
//List<string> lines = File.ReadLines("dictionary_english.txt").ToList();
//var container = lines.Select(p => p.Length);
//Console.WriteLine(container.Sum());

//6. Get the total units in stock for each product category.
//var products = ProductList.GroupBy(p => p.Category).Select(p =>new { Category = p.Key, TotalUnitOfStock = p.Sum(p=>p.UnitsInStock) });
//    foreach (var item in products)
//{
//    Console.WriteLine(item);
//}

//7. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
//string[] arr = File.ReadLines("dictionary_english.txt").ToArray();
//var shortWord = arr.Select(x=>x.Length).Min();
//Console.WriteLine(shortWord);

//8. Get the cheapest price among each category's products
//var cate = ProductList.GroupBy(g=>g.Category).Select(s=>new {category=s.Key , minPrice = s.Min(p=>p.UnitPrice) });
//foreach (var product in cate)
//{
//    Console.WriteLine(product);
//}
//9. Get the products with the cheapest price in each category (Use Let)
//var products = (from product in ProductList
//                group product by product.Category into ProductCategory
//                let min = ProductCategory.MinBy(p => p.UnitPrice)
//                select $"MinPrice : {min.UnitPrice} \t Prodcuts: {min.ProductName}");
//foreach (var product in products)
//{
//    Console.WriteLine(product);
//}

//10. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
//string[] arr = File.ReadLines("dictionary_english.txt").ToArray();
//var longWord = arr.Select(x=>x.Length).Max();
//Console.WriteLine(longWord);

//11. Get the most expensive price among each category's products.
//var products = ProductList.GroupBy(c => c.Category).Select(p => new { Category = p.Key, MostExpensiveProduct = p.Max(p => p.UnitPrice) });
//foreach (var product in products)
//{
//    Console.WriteLine(product);
//}

//12. Get the products with the most expensive price in each category.
//var products = from product in ProductList
//               group product by product.Category into ProductCategory
//               let mostExpensive = ProductCategory.MaxBy(p => p.UnitPrice)
//               select "Product Name " + mostExpensive.ProductName + ", Price: " + mostExpensive.UnitPrice;
//foreach (var product in products)
//{
//    Console.WriteLine(product);
//}

//13.Get the average length of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
//string[] arr = File.ReadLines("dictionary_english.txt").ToArray();
//var average = arr.Select(p => p.Length).Average();
//Console.WriteLine(average);

//14.Get the average price of each category's products.
//var products = ProductList.GroupBy(p => p.Category).Select(p => new { CategoryName = p.Key, AveragePrice = p.Average(p=>p.UnitPrice)});
//foreach (var product in products)
//{
//    Console.WriteLine(product);
//}
#endregion

#region LINQ - Ordering Operators

//1.Sort a list of products by name
//var products = ProductList.OrderBy(p => p.ProductName);
//foreach (var product in products)
//{
//    Console.WriteLine(product.ProductName);
//}
//2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
//string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
//var result = Arr.OrderBy(p => p, StringComparer.OrdinalIgnoreCase);
//foreach (var item in result)
//{
//    Console.WriteLine(item);
//}

//3.Sort a list of products by units in stock from highest to lowest.
//var products = ProductList.OrderByDescending(p => p.UnitsInStock );
//foreach (var product in products)
//{
//    Console.WriteLine(product.ProductName);
//}

//4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
//string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
//var result = Arr.OrderBy(p => p.Length).ThenBy(p => p);
//foreach (var item in result)
//{
//    Console.WriteLine(item);
//}

//5.Sort first by word length and then by a case-insensitive sort of the words in an array.
//string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
//var result = words.OrderBy(p => p.Length).ThenBy(p => p, StringComparer.OrdinalIgnoreCase);
//foreach (var item in result)
//{
//    Console.WriteLine(item);
//}

//6.Sort a list of products, first by category, and then by unit price, from highest to lowest.
//var products = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
//foreach(var product in products)
//{
//    Console.WriteLine(product);
//}

//7. Sort first by word length and then by a case-insensitive descending sort of the words in an array.
//string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
//var result = Arr.OrderBy(p => p.Length).ThenByDescending(p => p, StringComparer.OrdinalIgnoreCase);
//foreach (var item in result)
//{
//    Console.WriteLine(item);
//}

//8.Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
//string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
//var result = Arr.Where(word => word[1] == 'i').Reverse();
//foreach (var item in result)
//{
//    Console.WriteLine(item);
//}
#endregion

#region LINQ - Partitioning Operators
//1.Get the first 3 orders from customers in Washington.
//var products = CustomerList.Where(p => p.Region == "WA").Take(3);
//foreach (var p in products)
//{
//    Console.WriteLine(p);
//}

//2.Get all but skip the first 2 orders from customers in Washington.
//var products = CustomerList.Where(p => p.Region == "WA").Skip(2);
//foreach (var p in products)
//{
//    Console.WriteLine(p);
//}

//3.Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
//int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
//var result = numbers.TakeWhile((v, i) => v >= i);
//foreach (var num in result)
//{
//    Console.WriteLine(num);
//}

//4.Get the elements of the array starting from the first element divisible by 3.
//int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
//var result = numbers.Where(n => n % 3 == 0 && n != 0);
//foreach (var n in result)
//{
//    Console.WriteLine(n);
//}

//5.Get the elements of the array starting from the first element less than its position.
//int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
//var result = numbers.Where((v, i) => v <= i);
//foreach (var num in result)
//{
//    Console.WriteLine(num);
//}

#endregion

#region LINQ - Projection Operators
//1.Return a sequence of just the names of a list of products.
//var products = ProductList.Select(p => p.ProductName);
//foreach (var product in products)
//{
//    Console.WriteLine(product);
//}

//2.Produce a sequence of the uppercase and lowercase versions of each word in the original array(Anonymous Types).
//string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
//var result = words.Select(word => new { Upper = word.ToUpper(), Lower = word.ToLower() });
//foreach (var word in result)
//{
//    Console.WriteLine(word);
//}

//3.Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
//var products = ProductList.Select(p => new { ProductName = p.ProductName, Price = p.UnitPrice });
//foreach (var product in products)
//{
//    Console.WriteLine(product);
//}

//4.Determine if the value of ints in an array match their position in the array.
//int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
//var result = Arr.Select((n, i) => n == i).ToArray();
//for (int i = 0; i < result.Length; i++)
//{
//    Console.WriteLine($"index {i} => {result[i]}");
//}

//5.Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
//int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
//int[] numbersB = { 1, 3, 5, 7, 8 };
//var pairs = from a in numbersA
//            from b in numbersB
//            where a < b
//            select a + " is less than " + b;
//foreach (var pair in pairs)
//{
//    Console.WriteLine(pair);
//}

//6.Select all orders where the order total is less than 500.00.
//var orders = CustomerList.SelectMany((p) => p.Orders.Select(p => p).Where(p => p.Total < 500));
//foreach (var order in orders)
//{
//    Console.WriteLine(order);
//}

//7.Select all orders where the order was made in 1998 or later.
//var orders = CustomerList.SelectMany((p) => p.Orders.Select(p => p).Where(p => p.OrderDate > new DateTime(1998)));
//foreach (var order in orders)
//{
//    Console.WriteLine(order);
//}
#endregion

#region LINQ - Quantifiers
//1.Determine if any of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
//List<string> lines = File.ReadLines("dictionary_english.txt").ToList();
//var container = lines.Any(w=>w.Contains("ei"));
//Console.WriteLine(container);

//2.Return a grouped a list of products only for categories that have at least one product that is out of stock.
//var products = ProductList.GroupBy(p => p.Category).Select(p => new { Category = p.Key, Boolean = p.Any(p => p.UnitsInStock == 0) }).Where(p => p.Boolean);
//foreach (var product in products)
//{
//    Console.WriteLine(product);
//}

#region Fail
//var products = ProductList.GroupBy(p => p.Category).Select(p => new { Category = p.Key, Boolean = p.Any(p => p.UnitsInStock == 0) }).Where(p => p.Boolean);
//var result = products.SelectMany(p => ProductList,(Category, productlist)=>new {ProductName = productlist.Category}).Where(p=>p);

//var products = (from product in ProductList
//                group product by product.Category into ProductCategory
//                let check = ProductCategory.Any(p => p.UnitsInStock == 0)
//                let names = ProductCategory.Select(p => p.ProductName)
//                where check
//                select "Prodcut Name" + names + ", Prcie " + check); ;
//    foreach (var product in products)
//{
//    Console.WriteLine(product[2]);
//} 
#endregion

//3.Return a grouped a list of products only for categories that have all of their products in stock.
//var products = ProductList.GroupBy(p => p.Category).Select(p => new { Category = p.Key, Boolean = p.All(p => p.UnitsInStock > 0) }).Where(p => p.Boolean);
//foreach (var product in products)
//{
//    Console.WriteLine(product);
//}
#endregion

#region  LINQ - Grouping Operators
//1.Use group by to partition a list of numbers by their remainder when divided by 5
//int[] Arr = { 0, 5, 10, 1, 6, 11, 3, 8, 13, 4, 9, 14,7, 2, 12 };
//var groupedNumbers = Arr.GroupBy(num => num % 5).OrderBy(group => group.Key).ToList();

//foreach (var group in groupedNumbers)
//{
//    Console.WriteLine($"Numbers with a remainder of {group.Key} when divided by 5:");
//    foreach (var number in group)
//    {
//        Console.WriteLine(number);
//    }
//    Console.WriteLine();
//}

//2.Uses group by to partition a list of words by their first letter.
//List<string> lines = File.ReadLines("dictionary_english.txt").ToList();
//var container = lines.GroupBy(p => p[0]);
//foreach (var word in container)
//{
//    Console.WriteLine(word.Key);
//    foreach (var line in word)
//    {
//        Console.WriteLine(line);
//    }
//}

//3.Use Group By with a custom comparer that matches words that are consists of the same Characters Together
//string[] Arr = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };
//var groupmatch = Arr.Select(word => word.Trim()).GroupBy(word => string.Concat(word.OrderBy(c => c)));
//foreach (var group in groupmatch)
//{
//    Console.WriteLine("...");
//    foreach (var word in group)
//    {
//        Console.WriteLine(word);
//    }
//}
#endregion
