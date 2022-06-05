namespace ChallengeApp
{
   public interface IEmployee 
    {
        void AddGrade(string grade);
        Statistics GetStatistics();

        string Name { get; }
        event GradeAddedDelegate GradeAddedLowerThanThree;

    }
    
}