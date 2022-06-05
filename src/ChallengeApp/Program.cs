using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {          
            Console.WriteLine("Please input name or ID");
            var name = Console.ReadLine();
            var employee = new Employee(name, new DateTime(9999, 12, 31));
            
            employee.DateOfBirth = new DateTime(1994, 12, 7);
            Console.WriteLine($"{employee.Name} born on {employee.DateOfBirth}");
                        
            employee.GradeAddedLowerThanThree += OnTheLowestGradeAdded;

            while (true) 
            {              
                Console.WriteLine("Now you can add grades (numeric or with sign 3 to 5) for employee or input q for quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                
                try
                {
                    var grade = input;
                    employee.AddGrade(grade);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("END");
                }
                
            }

            var stat = employee.GetStatistics();
            Console.WriteLine($"Max: {stat.High}");
            Console.WriteLine($"Min: {stat.Low}");
            Console.WriteLine($"Avg: {stat.Average:N2}");
            Console.WriteLine($"Grade: {stat.Letter}");
            Console.WriteLine($"Your Rise could be: {stat.Rise}");          

            
        
        }
        static void OnTheLowestGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("We must inform you that you could not get a raise.");
        }

    }
}
