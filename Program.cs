﻿using System;
using System.Collections.Generic;
using System.Linq;
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

            foreach (var it in result)
            {
                Console.WriteLine($"FirstName {it.Name }, LastName {it.LastName}");
            }

            //var purchases = new List<Purchase>()
            //{
            //    new Purchase("Carrots", 12,1),
            //    new Purchase("Cauliflower", 2,1),
            //    new Purchase("Cauliflower", 2,1),
            //    new Purchase("Apples", 2,3),
            //    new Purchase("Apples", 7,1),
            //    new Purchase("Avocados", 2,4),
            //    new Purchase("Avocados", 2,1),
            //    new Purchase("Avocados", 3,1),
            //    new Purchase("Avocados", 2,4),
            //    new Purchase("Avocados", 7,1),
            //    new Purchase("Avocados", 2,1)
            //};

            //writeline person list


            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }

            //write linq statement for people with last name that starts with the letter D, writeline id of them

            var result1 = from ppl in people
                          where ppl.LastName.StartsWith("D")
                          select new { Id = ppl.Id };
            Console.WriteLine("----");

            foreach (var it in result1)
            {
                Console.WriteLine($" ID {it.Id}");
            }

            //Write linq statement for first Person Older Than 50 In Descending Alphabetical  Order by First Name
            var result2 = people.OrderByDescending(
                x => x.Age
                );

            foreach (var it in result2)
            {
                Console.WriteLine(it.ToString());
            }

            //Write person ages that is "dublicate"
            var r = from ppl in people
                    group ppl by ppl.Age into g
                    where g.Count() > 1
                    select new { g.Key, Count = g.Count() };
            Console.WriteLine("-----");

            foreach (var x in r)
            {
                Console.WriteLine($"{x.Key} {x.Count}");
            }


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
                return "Person Id - " + Id + ", FirstName " + FirstName + ", LastName " + LastName + ", Age  " + Age;//base.ToString();
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
