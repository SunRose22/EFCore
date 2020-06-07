
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;

namespace CoreExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            var options = optionsBuilder
                .UseMySql(connectionString)
                .Options;


            Connection();
             UpdateTester(options, 11, "Tom Hiddler");
            // InsertTester(options, "Karpov");
            //DeleteTester(options, 12);


            Console.Read();
        }



        public static int DeleteTester(DbContextOptions<AppContext> options, int id)
        {
            using (AppContext db = new AppContext(options))
            {
                Tester tester = db.Tester.Find(id);
                if (tester != null)
                {
                    db.Tester.Remove(tester);
                    db.SaveChanges();
                    Console.WriteLine("Пользователь удалён");
                }
                else
                {
                    Console.WriteLine("Пользователя с таким id не существует");
                }
            }
            return 0;
        }

        public static int InsertTester(DbContextOptions<AppContext> options, string Name)
        {
            using (AppContext db = new AppContext(options))
            {
                Tester tester = new Tester { name_tester = Name };
                db.Tester.Add(tester);
                db.SaveChanges();
                Console.WriteLine("Пользователь добавлен");
               
            }
            return 0;
        }

        public static int UpdateTester(DbContextOptions<AppContext> options, int id, string NewName)
        {
            
            using (AppContext db = new AppContext(options))
            {
                Tester tester = db.Tester.Find(id);
                if (tester != null)
                {

                    tester.name_tester = NewName;
                    db.SaveChanges();
                    Console.WriteLine("Имя пользователя изменено");

                }
               
            }
            return 0;
        }

        //Подключение к БД
        public static int Connection()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            var options = optionsBuilder
                .UseMySql(connectionString)
                .Options;

            using (AppContext db = new AppContext(options)) {
               return 0;
            }
        }
    }
}
