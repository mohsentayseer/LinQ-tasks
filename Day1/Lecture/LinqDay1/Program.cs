using static LinqDay1.ListGenerators;
#region Var
using LinqDay1;


List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
////List<int> oddNumbers= numbers.FindAll(x=>x%2!=0);
//var oddNumbers= numbers.Where(x=>x%2!=0);

//foreach(int number in oddNumbers)
//{
//    Console.WriteLine(number);
//} 
#endregion

#region Extension Methods
//using LinqDay1;

//string str = Console.ReadLine();
//string AppendedStr = "ya Ali";
//Console.WriteLine(Utility.YaRoka(str,AppendedStr));
//Console.WriteLine(str.YaRoka(AppendedStr));
//var EvenNumbers= Enumerable.Where(numbers, x => x % 2 == 0);
//EvenNumbers=numbers.Where(x=>x%2==0);
//foreach (var number in EvenNumbers)
//{
//    Console.WriteLine(number);
//}
#endregion

#region Anonymous Data type
//List<Employee> employees = new() 
//{ new Employee() { ID=1, Name="Ali", Age=20, Address="Cairo", Salary=1000},
//new Employee(){ ID=2, Name="Ola", Age=25, Address="Cairo", Salary=1000},
//new Employee(){ ID=3, Name="Lara", Age=27, Address="Cairo", Salary=1000},
//new Employee(){ ID=4, Name="Hamada", Age=18, Address="Cairo", Salary=1000} 
//};
//var older = employees.Where(x => x.Age >= 25);
//var emp = new { ID = 5, Name = "Dalia" };
//var emp2 = new { ID = 6 , Name = "Ali"};

//Console.WriteLine(emp.GetType().Name);
//Console.WriteLine(emp2.GetType().Name);
//foreach (var item in older)
//{
//    Console.WriteLine(item);
//}
#endregion

#region Restriction operators
//fluent syntax
//var prds = ProductList.Where(p => p.UnitPrice > 20);
//indexed where
//prds = ProductList.Where((p, i) => p.UnitPrice > 20 && i > 10);

//query syntax .. start with from and end with select or group by
//prds= from p in ProductList
//      where p.UnitPrice>20
//      select p;

//foreach (var p in prds)
//{
//    Console.WriteLine(p);
//}
#endregion

#region Projection operators
//var prds = ProductList.Select(p => p.ProductID).Where(i=>i>10);
//var prds = ProductList.Where(p=>p.UnitsInStock==0).Select(p => p.ProductID);
//prds = from p in ProductList
//       where p.UnitsInStock == 0
//       select p.ProductID;
//indexed select
//var prds = ProductList.Select((p, i) => new { p.ProductID, indx = i });
//var prds = ProductList.Select(p => new { ID = p.ProductID, Name = p.ProductName });
#endregion

#region Partitioning operators // fluent only
//var prds = ProductList.Take(10);
//prds = ProductList.Take(10..50).Take(20);
//prds= ProductList.Skip(10);
//prds= ProductList.SkipLast(10);
//prds= ProductList.TakeLast(10);
//var prdss = ProductList.Chunk(10);
//for (int i = 0; i < ProductList.Count/10+1; i++)
//{
//    Console.Clear();
//    var prds= ProductList.Skip(i*10).Take(10);
//	foreach (var item in prds)
//	{

//        Console.WriteLine(item);
//    }

//    Console.ReadKey();
//}
//foreach (var prdlist in prdss)
//{
//    Console.Clear();
//    foreach (var prd in prdlist)
//    {
//        Console.WriteLine(prd);
//    }
//    Console.ReadKey();
//}

//var prds = ProductList.TakeWhile(p => p.UnitsInStock > 0);
//prds = ProductList.SkipWhile(p => p.UnitsInStock <= 0);
#endregion

#region Ordering operators
//delayed execution // deffered execution
//var prds = ProductList.Where(p => p.UnitPrice > 10).ToList();

//ProductList.Add(new Product { ProductID = 78, ProductName = "Ne3na3", UnitPrice = 12 });

//var prds = ProductList.OrderBy(p=>p.UnitPrice);
//prds= ProductList.OrderByDescending(p=>p.UnitPrice).ThenBy(p=>p.UnitsInStock);
//prds= ProductList.OrderByDescending(p=>p.UnitPrice).ThenByDescending(p=>p.UnitsInStock);
//prds = from p in ProductList
//       orderby p.UnitPrice descending, p.UnitsInStock
//       select p;


#endregion

#region Single Element operators // immediate execution
//List<string> names = new List<string>();
////var prd = names.First();
//var prd = names.FirstOrDefault();
//var prd = ProductList.First(p => p.UnitPrice > 300);
//var prd = ProductList.FirstOrDefault(p => p.UnitPrice > 300)??new Product() { };
//prd = ProductList.FirstOrDefault(p => p.UnitPrice == 9.5m);
//prd = ProductList.LastOrDefault(p => p.UnitPrice == 9.5m);
//prd = ProductList.SingleOrDefault(p => p.UnitPrice == 300);

//var prd= ProductList.ElementAtOrDefault(100);
#endregion


#region Aggregate Operators
//var res = ProductList.Count();
// res = ProductList.Count(p=>p.UnitPrice==9.5m);
//res = ProductList.Sum(p => p.UnitsInStock);
//var res2 = ProductList.Average(p => p.UnitPrice);
//var res = ProductList.Max(p=>p.ProductID);
//var prd= ProductList.MaxBy(p=>p.ProductID);
#endregion

#region Casting operator // immediate execution
//var prds= ProductList.Where(p=>p.ProductID>6).ToList();
//var prds = ProductList.Where(p => p.ProductID > 6).ToDictionary(p => p.ProductName);
//prds= (from p in ProductList
//      where p.ProductID>6 && p.UnitPrice==ProductList.Max(p => p.UnitPrice)
//      select p).ToDictionary(p => p.ProductName); // to be reviewd
//foreach (var i in prds)
//{
//    Console.WriteLine(i.Key);
//    Console.WriteLine(i.Value);
//}

#endregion
//Console.WriteLine(prd);
#region Quantifiers
//List<int> nums = new() { 1,2,3,4,5,6,7};
//List<int> nums2 = new() { 7,1,2,3,4,5,6};
//var res = ProductList.Any(p=>p.ProductID==79);
//ProductList.Add(new Product() { UnitPrice = 0, ProductID = 78 });
//res = ProductList.All(p => p.UnitPrice > 0);
//var res= nums.SequenceEqual(nums2);
//Console.WriteLine(res);
#endregion

#region Generators 
//var res = Enumerable.Range(0, 90);
//var res= Enumerable.Empty<int>();
//var res = Enumerable.Repeat("hello", 9);
//foreach (var i in res)
//    Console.WriteLine(i);
#endregion

#region Set Operators
//var lst1 = Enumerable.Range(0, 50);
//var lst2 = Enumerable.Range(0, 100);
//var res= lst1.Intersect(lst2);
//res= lst1.Concat(lst2).Distinct();
//res = lst1.Union(lst2);
//res= lst2.Except(lst1);

//foreach (var item in res)
//{
//    Console.WriteLine(item);
//}

#endregion

#region Projection continued
//selectMany
//List<string> FullNames = new() { "Ali Ahmed", "LAra Wael", "Mohamed abdo" };
//List<int> IDs=Enumerable.Range(1, 4).ToList();
//var res = FullNames.SelectMany(n => n.Split(' '));
//var res = IDs.Zip(FullNames);
//foreach (var i in res)
//    Console.WriteLine(i);
#endregion

#region Group by
//var res = ProductList.GroupBy(p => p.Category);
//res = from p in ProductList
//      group p by p.Category;
//foreach (var i in res)
//{
//    Console.WriteLine(i.Key);
//    foreach (var t in i)
//        Console.WriteLine(t);
//}
#endregion

#region Into, Let in query syntax
List<string> FullNames = new() { "Ali Ahmed", "LAra Wael", "Mohamed abdo" };
//var res= from name in FullNames
//         select name+" pla pla " into newName
//         select new {newName};
var res= from name in FullNames
         let NewName= name+ " pla pla"
         select new {NewName, name};

foreach (var i in res)
    Console.WriteLine(i);
#endregion