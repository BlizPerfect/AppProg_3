using System;
using System.Collections.Generic;
using System.Linq;

namespace AppProg_3
{
    class Person
    {

        public int InitNumber { private set; get; }
        public int SortedNumber { set; get; }
        public int PersonValue { private set; get; }

        public Person(int Number, int Price)
        {
            InitNumber = Number;
            PersonValue = Price;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество сотрудников компании: ");
            var count = Convert.ToInt32(Console.ReadLine());
            List<Person> employeesList = new List<Person>();
            List<Person> taxiDriversList = new List<Person>();
            Random rnd = new Random();
            for (var i = 0; i < count; i++)
            {
                employeesList.Add(new Person(i, rnd.Next(1, 1000)));
                taxiDriversList.Add(new Person(i, rnd.Next(1, 10000)));
            }
            //Выводится N чисел.Первое число — номер такси, в которое должен сесть первый сотрудник, второе число — номер такси, в которое должен сесть второй и т.д.,
            Console.WriteLine("Начальные данные:");
            Console.WriteLine("Расстояния до домов сотрудников:");
            foreach (var employee in employeesList)
            {
                Console.WriteLine(employee.PersonValue + " " + employee.InitNumber);
            }
            Console.WriteLine("\nТарифы таксистов:");
            foreach (var taxiDriver in taxiDriversList)
            {
                Console.WriteLine(taxiDriver.PersonValue + " " + taxiDriver.InitNumber);
            }
            Console.WriteLine("\nРастояния, отсортированные по убыванию:");
            var sortedListOfEmployees = employeesList.OrderBy(u => u.PersonValue).ToList();
            for (var i = 0; i < sortedListOfEmployees.Count; i++)
            {
                sortedListOfEmployees[i].SortedNumber = i;
            }
            foreach (var i in sortedListOfEmployees)
            {
                Console.WriteLine("Value: " + i.PersonValue + " InitNumber:" + i.InitNumber + " SortedNumber:" + i.SortedNumber);
            }

            Console.WriteLine("Тарифы, отсортированные по убыванию:");
            var sortedListOfDrivers = taxiDriversList.OrderByDescending(u => u.PersonValue).ToList();
            for (var i = 0; i < sortedListOfDrivers.Count; i++)
            {
                sortedListOfDrivers[i].SortedNumber = i;
            }
            foreach (var i in sortedListOfDrivers)
            {
                Console.WriteLine("Value: " + i.PersonValue + " InitNumber:" + i.InitNumber + " SortdeNumber:" + i.SortedNumber);
            }

            Console.WriteLine("");
            for (var i = 0; i < employeesList.Count; i++)
            {
                var pos = employeesList[i].SortedNumber;
                int index = sortedListOfDrivers.Select((item, ind) => new { Item = item, Index = ind }).First(x => x.Item.SortedNumber == pos).Item.InitNumber;
                var result = sortedListOfDrivers[index].InitNumber;
                Console.Write(index + " ");
            }
        }
    }
}
