using System;

namespace FishingCompetition
{
    internal class Program
    {
        const int Upto16Years = 85;
        const int Adult = 125;
        const int MealPrice = 65;
        const int MaxTransactions = 10;

        static void Main(string[] args)
        {
            int[] finalAmounts = new int[MaxTransactions];
            double[] weights= new double[MaxTransactions];    
            int transactionCount = 0;
            int winnerCatch = 0;
            double maxWeight = 0;

            do
            {
                int entranceFee = CalcEntry();
                int meals = GetMeals();

                int finalAmount = entranceFee + (meals * MealPrice);
                finalAmounts[transactionCount] = finalAmount;
                transactionCount++;

                Console.WriteLine($"Transaction {transactionCount} - Amount due: R {finalAmount}");
                Console.WriteLine();

                Console.Write("Do you want to process another transaction? (Y/N): ");
                char choice = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
                Console.WriteLine();

                if (choice == 'N' || transactionCount == MaxTransactions)
                    break;
            }
            while (true);
            for(int i=0; i< transactionCount; i++)
            {
                ( maxWeight,winnerCatch) = RecordWeight(i + 1, weights, maxWeight, winnerCatch);
                Console.WriteLine("Comepetitor{0} wins the competition with a catch of {1}:",winnerCatch,maxWeight); 
            }
            Console.ReadLine();


        }

        static int CalcEntry()
        {
            int competitorAge, numberOfDays, entranceFee = 0;

            Console.Write("Enter competitor age: ");
            competitorAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter number of days: ");
            numberOfDays = Convert.ToInt32(Console.ReadLine());

            if (competitorAge <= 16)
            {
                entranceFee = Upto16Years * numberOfDays;
            }
            else
            {
                entranceFee = Adult * numberOfDays;
            }

            return entranceFee;
        }

        static int GetMeals()
        {
            int meals;
            do
            {
                Console.Write("Enter the number of meals (0-9): ");
                meals = Convert.ToInt32(Console.ReadLine());
            }
            while (meals < 0 || meals > 9);

            return meals;
        }
        static (double, int) RecordWeight(int CompetitorsNumber, double[] weights, double maxWeight, int winnerCatch)
        {
            Console.WriteLine();
            Console.WriteLine("Recording Catches");
            for(int i=0; i<3; i++)
            {
                Console.Write("Enter the catch weight for competitor{0}:", i+1);
                double weight = double.Parse(Console.ReadLine());
                weights[CompetitorsNumber - 1] = weight;
                if (weight > maxWeight)
                {
                    maxWeight = weight;
                    winnerCatch = CompetitorsNumber;
                    break;
                }
            }
           
            return (maxWeight, winnerCatch);

        }
    }
}

