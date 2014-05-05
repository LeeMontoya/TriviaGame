
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame
{
    class Program
    {
        //global variables
        static string input = "";
        static int correct = 0;
        static int incorrect = 0;
        static Trivia questionTemp = new Trivia("", "");
        static List<Trivia> contents = GetTriviaList();
        static int amountCorrect = 0;
        static int amountIncorrect = 0;
        static bool playing = true;
        

        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 50);
            
            Welcome();
            GetTriviaList();
            
            //run game here
            while (playing)
            {
                CompChooseQuestion();
                UserGuess();
                CheckGameOver();
            }
  
            Console.ReadLine();
           
        }

        static List<Trivia> GetTriviaList()
        {
            //Get Contents from the file.  Remove the special char "\r".  Split on each line.  Convert to a list.
            List<string> contents = File.ReadAllText("trivia.txt").Replace("\r", "").Split('\n').ToList();

            //Each item in list "contents" is now one line of the Trivia.txt document.
            
            //make new list to return
            List<Trivia> returnList = new List<Trivia>();
            //go through each line in contents and make trivia an object
            //add it to our return list
            foreach (string line in contents)
            {

                string question = line.Split('*')[0];
                string answer = line.Split('*')[1];
                returnList.Add(new Trivia(question, answer));
            }

            return returnList;
        }

        //This function welcomes the user
        static void Welcome()
        {
            //Asks for users name
            string userName;
            Console.WriteLine("Hello! Whats your name?");
            userName = Console.ReadLine();
            Console.Clear();
            //Greets user and prompts the random question that was chosen
            Console.WriteLine("Nice to meet you, " + userName + ". Lets play some trivia!");
           
            Console.WriteLine();
            
            
        }

        static void CompChooseQuestion()
        {
            //choose random question
            Random randomQuestion = new Random();
            int random = randomQuestion.Next(1, contents.Count);
            questionTemp = contents[random];

            //print random question
            Console.WriteLine("Here is your question: ");
            Console.WriteLine();
            Console.WriteLine(questionTemp.Question + "?");

        }

        static void UserGuess()
        {
            //get users guess
            string userGuess;
            Console.Write("Guess: ");
            userGuess = Console.ReadLine();
            

            
                //Check to see if users guess is correct or incorrect
                if (userGuess.ToLower() == questionTemp.Answer.ToLower())
                {
                    Console.WriteLine("Correct!");

                    //add 1 to total correct
                    amountCorrect += 1;
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("Incorrect!");
                    Console.WriteLine();
                    Console.WriteLine("Correct answer: " + questionTemp.Answer);

                    //add 1 to total incorrect
                    amountIncorrect += 1;

                }
                
                //print total correct and incorrect
                Console.WriteLine();
                Console.WriteLine("Total correct: " + amountCorrect);
                Console.WriteLine("Total incorrect: " + amountIncorrect);

            }


        static void CheckGameOver()
        {
            //if user gets 10 right or wrong, end game
            if (correct == 10)
            {
                Console.WriteLine("Congratulations, you won!");
                Console.WriteLine("Correct: " + correct);
                Console.WriteLine("Incorrect: " + incorrect);
                playing = false;
                
            }
            else if (incorrect == 10)
            {
                Console.WriteLine("Oh no, you lost!");
                Console.WriteLine("Correct: " + correct);
                Console.WriteLine("Incorrect: " + incorrect);
                playing = false;
                
            }
        }

        static void Category()
        {

        }

    }
}
