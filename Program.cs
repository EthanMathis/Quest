using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );

            Challenge favoriteGame = new Challenge(
                @"What is my favorite video game?
    1) Super Mario Bros
    2) Fortnite
    3) Halo
    4) Tetris
",
                 3, 25
            );

            Challenge favoriteColor = new Challenge(
                @"What is your favorite color?
    1) Red
    2) Blue
    3) Orange
    4) Green
",
                2, 20
            );

            Challenge bestSport = new Challenge(
                @"What is the best sport to watch on TV?
    1) Football
    2) Hockey
    3) Baseball
    4) Soccer
",
                 1, 40
            );



            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            // int minAwesomeness = 0;
            // int maxAwesomeness = 100;

            // Make a new "Adventurer" object using the "Adventurer" class
            Console.WriteLine("Hello Adventurer! What is your name?");
            string Name = Console.ReadLine();

            List<string> Colors = new List<string>()
            {
                "Light-Blue", "Royal-Blue", "Cyan", "Purple"
            };

            Robe BlueRobe = new Robe(Colors, 42);
            Hat BlindingHat = new Hat(10);

            Adventurer theAdventurer = new Adventurer(Name, BlueRobe, BlindingHat);

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> AllChallenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                favoriteGame,
                favoriteColor,
                bestSport
            };

            string Description = theAdventurer.GetDescription();
            Console.WriteLine(Description);
            // // Loop through all the challenges and subject the Adventurer to them
            // foreach (Challenge challenge in challenges)
            // {
            //     challenge.RunChallenge(theAdventurer);
            // }

            // // This code examines how Awesome the Adventurer is after completing the challenges
            // // And praises or humiliates them accordingly
            // if (theAdventurer.Awesomeness >= maxAwesomeness)
            // {
            //     Console.WriteLine("YOU DID IT! You are truly awesome!");
            // }
            // else if (theAdventurer.Awesomeness <= minAwesomeness)
            // {
            //     Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
            // }
            // else
            // {
            //     Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
            // }
            RunGame(AllChallenges, theAdventurer);
        }

        static int RandomNumber()
        {
            Random r = new Random();
            int RandomNumber = r.Next(0, 8);
            return RandomNumber;
        }

        static void RunGame(List<Challenge> challenges, Adventurer theAdventurer)
        {

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;
            List<Challenge> OnlyFive = new List<Challenge>();

            List<int> RandomNumberList = new List<int>();

            while (RandomNumberList.Count < 5)
            {
                int NumberToBeAdded = RandomNumber();

                if (!RandomNumberList.Contains(NumberToBeAdded))
                {
                    RandomNumberList.Add(NumberToBeAdded);
                }
                else
                {
                    NumberToBeAdded = RandomNumber();
                }
            }

            foreach (int Number in RandomNumberList)
            {
                OnlyFive.Add(challenges[Number]);
            }


            foreach (Challenge challenge in OnlyFive)
            {
                challenge.RunChallenge(theAdventurer);
            }

            // This code examines how Awesome the Adventurer is after completing the challenges
            // And praises or humiliates them accordingly
            if (theAdventurer.Awesomeness >= maxAwesomeness)
            {
                Console.WriteLine("YOU DID IT! You are truly awesome!");
            }
            else if (theAdventurer.Awesomeness <= minAwesomeness)
            {
                Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
            }
            else
            {
                Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
            }

            Prize Ball = new Prize("Blue Bouncy Ball");
            Ball.ShowPrize(theAdventurer);

            Console.WriteLine("Would you like to try again?");
            Console.WriteLine(@"
1) Yes
2) No 
            ");
            string PlayAgain = Console.ReadLine();
            int NumAnswer;
            bool isNumber = int.TryParse(PlayAgain, out NumAnswer);
            if (isNumber)
            {
                if (NumAnswer == 1)
                {
                    theAdventurer.Awesomeness = 50;
                    RunGame(challenges, theAdventurer);
                }
                else
                {
                    Console.WriteLine("Game Over");
                }
            }

        }
    }
}