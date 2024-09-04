using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            var sum = numbers.Sum();
            var average = numbers.Average();
            
            Console.WriteLine($"Sum: {sum}\nAverage: {average}");

            //TODO: Print the Average of numbers

            //TODO: Order numbers in ascending order and print to the console
            var ascending = numbers.OrderBy(num => num);
            Console.WriteLine("--------------------");
            Console.WriteLine("Numbers in Ascending Order");
            foreach (var number in ascending)
            {
                Console.WriteLine(number);
            }

            //TODO: Order numbers in descending order and print to the console
            var descending = numbers.OrderByDescending(num => num);
            Console.WriteLine("--------------------");
            Console.WriteLine("Numbers in Desscending Order");
            foreach (var number in descending)
            {
                Console.WriteLine(number);
            }

            //TODO: Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6);
            Console.WriteLine("--------------------");
            Console.WriteLine("Numbers Greater Than Six");
            foreach (var number in greaterThanSix)
            {
                Console.WriteLine(number);   
            }

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("--------------------");
            Console.WriteLine("First Four Numbers in Ascending Order");
            foreach (var number in ascending.Take(4))
            {
                Console.WriteLine(number);
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 36;
            Console.WriteLine("--------------------");
            Console.WriteLine("Numbers Descending From Age");
            foreach (var number in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(number);
            }

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var filter =
                employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S'))
                    .OrderBy(person => person.FirstName);
            Console.WriteLine("--------------------");
            Console.WriteLine("Print Full Name with First Letter as 'C' or 'S'.");
            foreach (var employee in filter)
            {
                Console.WriteLine(employee.FullName);
            }
            
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees.Where(person => person.Age > 26)
                .OrderBy(person => person.Age).ThenBy(person => person.FirstName);
            Console.WriteLine("--------------------");
            Console.WriteLine("Employee's Full Name Over Age 26");
            foreach (var employee in overTwentySix)
            {
                Console.WriteLine($"first Name: {employee.FirstName}\nAge: {employee.Age}");
            }
            
            
            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var yearsOfExperience = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var sumOfExperience = yearsOfExperience.Sum(x => x.YearsOfExperience);
            Console.WriteLine("--------------------");
            Console.WriteLine("Sum of All Years of Experience:");
            Console.WriteLine(sumOfExperience);
            
            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var avgOfExperience = yearsOfExperience.Average(x => x.YearsOfExperience);
            Console.WriteLine("--------------------");
            Console.WriteLine("Average of All Years of Experience:");
            Console.WriteLine(avgOfExperience);
            
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Robert", "Rockhold", 36, 0)).ToList();

            foreach (var item in employees)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}: {item.Age}, {item.YearsOfExperience}");
            }


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
