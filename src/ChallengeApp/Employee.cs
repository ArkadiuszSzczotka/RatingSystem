using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Employee : EmployeeBase
    {
        public override event GradeAddedDelegate GradeAddedLowerThanThree;

        private readonly List<double> grades = new List<double>();
        

        public Employee(string name, DateTime date) : base(name, date)
        { }    
        
        public void AddGradeFromString(string grade)
        {   
            int result;
            if (int.TryParse(grade, out result))
            {
            this.grades.Add(result);
            }
        }   
        public void ChangeName(Employee employee, string name) 
        {
            {
                foreach (char c in name)
                {
                    if (char.IsDigit(c))
                    {
                        throw new ArgumentException("Name can not contain any digits");
                    }
                }
            }
            employee.Name = name;
        }     

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
            this.grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid argument {nameof(grade)}");
            }
        }

        public override void AddGrade(string grade)
        {
            switch (grade)
            {
                case "N" or "-3" or "-C":
                this.grades.Add(0.0);
                if(GradeAddedLowerThanThree != null)
                {
                    GradeAddedLowerThanThree(this, new EventArgs());
                }
                break;
                
                case "3" or "C":
                this.grades.Add(20.0);
                break;

                case "3+" or "C+":
                this.grades.Add(30.0);
                break;

                case "-4" or "-B":
                this.grades.Add(40.0);
                break;

                case "4" or "B":
                this.grades.Add(50.0);
                break;

                case "4+" or "B+":
                this.grades.Add(60.0);
                break;

                case "-5" or "-A":
                this.grades.Add(70.0);
                break;

                case "5" or "A":
                this.grades.Add(80.0);
                break;
                
                case "5+" or "A+":
                this.grades.Add(100.0);
                break;          

                default:
                throw new ArgumentException($"Argument out of grades range {nameof(grade)}");            
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            
            result.Average = 0.0;
            result.Rise = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            
            foreach (var grade in grades)
            {
                result.Low = Math.Min(result.Low, grade);
                result.High = Math.Max(result.High, grade);
                result.Average = result.Average + grade;
            }
            result.Average = result.Average / grades.Count;

            switch (result.Average)
            {
                case <= 15.0:
                    result.Rise = 0.0;
                    result.Letter = "-C";
                    break;
                case > 15.0 and < 25.0:
                    result.Rise = 100.0;
                    result.Letter = "C";
                    break;
                case > 25.0 and < 35.0:
                    result.Rise = 200.0;
                    result.Letter = "C+";
                    break;
                case >= 35.0 and < 45.0:
                    result.Rise = 300.0;
                    result.Letter = "-B";
                    break;
                case >= 45.0 and < 55.0:
                    result.Rise = 400.0;
                    result.Letter = "B";
                    break;
                case >= 55.0 and < 65.0:
                    result.Rise = 500.0;
                    result.Letter = "B+";
                    break;
                case >= 65.0 and < 75.0:
                    result.Rise = 600.0;
                    result.Letter = "-A";
                    break;
                case >= 75.0 and < 90.0:
                    result.Rise = 700.0;
                    result.Letter = "A";
                    break;
                case >= 90.0 and <= 100.0:
                    result.Rise = 1000.0;
                    result.Letter = "A+";
                    break;
            }
            return result;
        }
    }
}