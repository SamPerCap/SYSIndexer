using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SYSIndexer
{
    class Program
    {

        public static List<Cars> ListOfCars = new List<Cars>();

        static string CarsPath = @"C:\Users\Samuel\Desktop\PBS Software\SYS\CarList.json";
        static void Main(string[] args)
        {
            var ReadFile = File.ReadAllText(CarsPath);
            ListOfCars = JsonConvert.DeserializeObject<List<Cars>>(ReadFile);

            Console.WriteLine("Write your car manufacturer");
            var model = Console.ReadLine();
            Cars cars = new Cars();
            var carFinded = cars[model];
            foreach (var car in carFinded)
            {
                Console.WriteLine("\nCar id:" + car.id + "\nCar model: " + car.Name + "\nCar Manufacturer: "
                    + car.Manufacturer + "\nCar Price: " + car.AppPrice);
            }
            Console.ReadLine();
        }
    }

    public class Cars
    {
        public List<Cars> listCars = Program.ListOfCars;

        public int id;
        public string Manufacturer;
        public string Name;
        public string Color;
        public string AppPrice;
        public string Product;

        public IEnumerable<Cars> this[string input]
        {
            get
            {
                return listCars.Where(c => c.Manufacturer.Equals(input) || c.Name.Equals(input));
            }
        }
    }
}
