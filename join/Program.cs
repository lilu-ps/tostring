﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>()
            {
                new Person(1,"Bill", "Smith", 41),
                new Person(2,"Sarah", "Jones", 22),
                new Person(3,"Stacy","Baker", 21),
                new Person(4,"Vivianne","Dexter", 19 ),
                new Person(5,"Bob","Smith", 49 ),
                new Person(6,"Brett","Baker", 51 ),
                new Person(7,"Mark","Parker", 19),
                new Person(8,"Alice","Thompson", 18),
                new Person(9,"Evelyn","Thompson", 58 ),
                new Person(10,"Mort","Martin", 58),
                new Person(11,"Eugene","deLauter", 84 ),
                new Person(12,"Gail","Dawson", 19 ),
            };

            var result = from ppl in people
                         where ppl.Age < 20
                         select new { Name = ppl.FirstName, LastName = ppl.LastName };

            //foreach (var it in result)
            //{
            //    Console.WriteLine($"FirstName {it.Name }, LastName {it.LastName}");
            //}

            var purchases = new List<Purchase>()
            {
                new Purchase("Carrots", 12,1),
                new Purchase("Cauliflower", 2,1),
                new Purchase("Cauliflower", 2,1),
                new Purchase("Apples", 2,3),
                new Purchase("Apples", 7,1),
                new Purchase("Avocados", 2,4),
                new Purchase("Avocados", 2,1),
                new Purchase("Avocados", 3,1),
                new Purchase("Avocados", 2,4),
                new Purchase("Avocados", 7,1),
                new Purchase("Avocados", 2,1)
            };


            var max = people.Max(x => x.Age);
            var min = people.Min(x => x.Age);

            Console.WriteLine(max - min);


            var res = (from ppl in people
                      join prch in purchases on ppl.Id equals prch.PersonId into cur
                      orderby cur.Select(x => x.Quantity).Sum() descending
                      select new { Sum = cur.Select(x => x.Quantity).Sum(), Id = ppl.Id, FirstName = ppl.FirstName, LastName = ppl.LastName }).First();


            Console.WriteLine(res.FirstName + " " + res.LastName + " : " + res.Sum);


            Console.ReadLine();
        }


        public class Person
        {
            public Person(int id, string firstName, string lastName, int age)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
                Id = id;
            }

            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }

            //override ToString to return the person's Id  FirstName LastName Age. 
            // example Person Id - 1, FirstName Bill, LastName Smith, Age 41
            public override string ToString()
            {
                return $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Age: {Age}";
            }


        }

        public class Purchase
        {
            public Purchase(string product, int personId, int quantity)
            {
                Product = product;
                PersonId = personId;
                Quantity = quantity;
            }
            public string Product { get; set; }
            public int PersonId { get; set; }
            public int Quantity { get; set; }
        }
    }
}
