using System;


namespace assessment3
{
    

    class CricketTeam
    {
        public double Pointscalculation(int no_of_matches)
        {

            
            int totalScore = 0;
            int score;
            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"\nEnter score for match {i + 1}: ");
                score = Convert.ToInt32(Console.ReadLine());
                totalScore += score;
            }

            double averageScore = totalScore / no_of_matches;
            Console.WriteLine($"\n\nTotal Matches Played: {no_of_matches}");
            Console.WriteLine($"Total Score: {totalScore}");
            Console.WriteLine($"Average Score: {averageScore}");

            return totalScore;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("------IPL Scoring------");
            CricketTeam team = new CricketTeam();

            Console.Write("\n\nEnter number of matches: ");
            int no_of_matches = Convert.ToInt32(Console.ReadLine());

            team.Pointscalculation(no_of_matches);
            Console.Read();
        }
    }
}
