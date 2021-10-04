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
            SortedNumber = -1;
        }
    }

    class Program
    {
        public static int InputCount()
        {
            var error = true;
            int result = 0;
            Console.Write("Введите количество сотрудников компании: ");
            while (error)
            {
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    error = false;
                }
                else
                {
                    Console.WriteLine("Вы ввели не число, попробуйте снова.");
                }
            }
            return result;
        }

        public static List<Person> CreatListOfPerson(int listSize, int maxListValue)
        {
            Random rnd = new Random();
            List<Person> resultList = new List<Person>();
            for (var i = 0; i < listSize; i++)
            {
                resultList.Add(new Person(i, rnd.Next(1, maxListValue)));
            }
            return resultList;
        }

        public static void ShowListValues(List<Person> list, string header)
        {
            Console.WriteLine(header);
            foreach (var employee in list)
            {
                Console.Write(employee.PersonValue + " ");
            }
        }

        public static List<Person> SortList(List<Person> originalList, bool orderBy)
        {
            if (orderBy)
            {
                return originalList.OrderBy(u => u.PersonValue).ToList();

            }
            return originalList.OrderByDescending(u => u.PersonValue).ToList();
        }

        public static void CalculateSortedIndexes(List<Person> sortdeList)
        {
            for (var i = 0; i < sortdeList.Count; i++)
            {
                sortdeList[i].SortedNumber = i;
            }
        }

        public static void ShowResult(List<Person> sortedListOfDrivers, List<Person> sortedListOfEmployees, List<Person> originalEmployeesList)
        {
            Console.WriteLine("\n\nСамая выгодня погрузка:");
            for (var i = 0; i < originalEmployeesList.Count; i++)
            {
                var pos = originalEmployeesList[i].SortedNumber;
                int index = sortedListOfDrivers.Select((item, ind) => new { Item = item, Index = ind }).First(x => x.Item.SortedNumber == pos).Item.InitNumber;
                Console.Write(index + " ");
            }
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            var count = InputCount();

            List<Person> employeesList = CreatListOfPerson(count, 1000);
            List<Person> taxiDriversList = CreatListOfPerson(count, 10000);

            ShowListValues(employeesList, "\nРасстояния до домов сотрудников: ");
            ShowListValues(taxiDriversList, "\n\nТарифы таксистов");

            var sortedListOfEmployees = SortList(employeesList, true);
            CalculateSortedIndexes(sortedListOfEmployees);

            var sortedListOfDrivers = SortList(taxiDriversList, false);
            CalculateSortedIndexes(sortedListOfDrivers);

            ShowResult(sortedListOfDrivers, sortedListOfEmployees, employeesList);
        }
    }
}
