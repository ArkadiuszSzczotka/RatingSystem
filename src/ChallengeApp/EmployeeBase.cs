using System;

namespace ChallengeApp
{
    public abstract class EmployeeBase : PersonBase, IEmployee
    {
        public EmployeeBase (string name, DateTime date) : base(name, date)
        { }

        public virtual event GradeAddedDelegate GradeAddedLowerThanThree;

        public abstract void AddGrade(string grade);

        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
        public override DateTime SetDateOfBirth()
        {
            throw new NotImplementedException();
        }
    }
}