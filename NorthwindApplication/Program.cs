using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

using NorthwindDbLibrary;
using System.Threading.Tasks;

namespace NorthwindApplication
{
    class Program
    {
        private static IConfigurationRoot _configuration;

        #region Uncomment after scaffolding
        //private static DbContextOptionsBuilder<Northwind_SQLiteContext> _optionsBuilder;
        #endregion

        static void Main(string[] args)
        {
            BuildConfiguration();

            #region Ensuring appsettings.json is in the right location
            Console.WriteLine($"Configuration Directory: {DbConnectionsDirectory()}");

            var connectionString = _configuration.GetConnectionString("SQLite_northwind");
            if (!string.IsNullOrEmpty(connectionString))
                Console.WriteLine($"Connection string to Database: {connectionString}");
            else
            {
                Console.WriteLine($"Please copy the 'DbConnections.json' to this location");
                return;
            }
            #endregion

            #region Uncomment after scaffolding
            //BuildOptions();
            //QueryDatabaseAsync().Wait();
            //QueryDatabaseWithLinq();
            #endregion
        }

        static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(DbConnectionsDirectory())
                .AddJsonFile("DbConnections.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }
        static string DbConnectionsDirectory()
        {
            //LocalApplicationData is a good place to store configuration files.
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            documentPath = Path.Combine(documentPath, "AOOP2", "EFC", "DbConnections");
            if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
            return documentPath;
        }

        #region Uncomment after scaffolding
        /*
        private static void BuildOptions()
        {
            _optionsBuilder = new DbContextOptionsBuilder<Northwind_SQLiteContext>();

            var connectionString = _configuration.GetConnectionString("SQLite_northwind");
            _optionsBuilder.UseSqlite(connectionString);
        }

        private static async Task QueryDatabaseAsync()
        {
            using (var db = new Northwind_SQLiteContext(_optionsBuilder.Options))
            {
                var customers = await db.Customers.CountAsync();
                var employees = await db.Employees.CountAsync();
                var orders = await db.Orders.CountAsync();


                Console.WriteLine($"Nr of Customers: {customers}");
                Console.WriteLine($"Nr of Employees: {employees}");
                Console.WriteLine($"Nr of Orders: {orders}");
            }
        }
        private static void QueryDatabaseWithLinq()
        {
            using (var db = new Northwind_SQLiteContext(_optionsBuilder.Options))
            {
                var customers = db.Customers;
                var employees = db.Employees;
                var orders = db.Orders;

                Console.WriteLine("\n\nQuery Database with Linq");
                Console.WriteLine("------------------------");
                Console.WriteLine($"Nr of customers: {customers.Count()}");
                Console.WriteLine($"Nr of employees: {employees.Count()}");
                Console.WriteLine($"Nr of orders: {orders.Count()}");

                var list = customers.Join(orders, cust => cust.CustomerId, order => order.CustomerId, (cust, order) => new { cust, order });
                Console.WriteLine($"\nInnerJoin Customer - Order via Join, Count: {list.Count()}");
            }
        }
        */
        #endregion
    }
}
