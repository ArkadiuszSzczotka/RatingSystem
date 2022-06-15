using System;
using System.IO;

namespace ChallengeApp
{
    public class EmployeeInFile : EmployeeBase, IEmployee
    {
        public EmployeeInFile(string name, DateTime date) : base(name, date)
        {
        }
        public override event GradeAddedDelegate GradeAddedLowerThanThree;
        public override DateTime SetDateOfBirth()
        {
            DateTime birthDay;
            Console.WriteLine("Enter date of birth as day/month/year");

            string[] formats = { "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                    "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy"};

            while (!DateTime.TryParseExact(Console.ReadLine(), formats,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out birthDay))
            {
                Console.WriteLine("Your input is incorrect. Please input again.");
            }
                return birthDay;             
        }

        const string gradesMemory = "Grades.txt";
        const string auditFile = "AuditGrades.txt";
        public override void AddGrade(string grade)
        {            
            using (var writer = File.AppendText($"{gradesMemory}"))
            using (var auditwriter = File.AppendText($"{auditFile}"))
            {
            switch (grade)
            {
                case "N" or "-3" or "-C":
                writer.WriteLine("0");
                auditwriter.WriteLine($"0 : {DateTime.UtcNow}");
                if(GradeAddedLowerThanThree != null)
                {
                    GradeAddedLowerThanThree(this, new EventArgs());
                }
                break;
                
                case "3" or "C":
                writer.WriteLine("20");
                auditwriter.WriteLine($"20 : {DateTime.UtcNow}");
                break;

                case "3+" or "C+":
                writer.WriteLine("30");
                auditwriter.WriteLine($"30 : {DateTime.UtcNow}");
                break;

                case "-4" or "-B":
                writer.WriteLine("40");
                auditwriter.WriteLine($"40 : {DateTime.UtcNow}");
                break;

                case "4" or "B":
                writer.WriteLine("50");
                auditwriter.WriteLine($"50 : {DateTime.UtcNow}");
                break;

                case "4+" or "B+":
                writer.WriteLine("60");
                auditwriter.WriteLine($"60 : {DateTime.UtcNow}");
                break;

                case "-5" or "-A":
                writer.WriteLine("70");
                auditwriter.WriteLine($"70 : {DateTime.UtcNow}");
                break;

                case "5" or "A":
                writer.WriteLine("80");
                auditwriter.WriteLine($"80 : {DateTime.UtcNow}");
                break;
                
                case "5+" or "A+":
                writer.WriteLine("100");
                auditwriter.WriteLine($"100 : {DateTime.UtcNow}");
                break;          

                default:
                throw new ArgumentException($"Argument out of grades range {nameof(grade)}");            
            }
            }
        }
         
    }
}