using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Drawing;
using System.Dynamic;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;

namespace Lab_1_2910
{
    public class Program
    {
        private static List<VideoGame> list = new List<VideoGame>();
        private static Stack<VideoGame> myStack = new Stack<VideoGame>();
        private static Queue<VideoGame> myQueue = new Queue<VideoGame>();
        private static Dictionary<string, string> myDictionary = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            var ProjectFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent;
            string FilePath = @$"{ProjectFolder}{Path.DirectorySeparatorChar}videogames.csv";
            
            // INPUTING FILE AND PASSING THE OBJECTS. ///////////////////////////////////////////////////////////////////////
            try
            {
                using (var sr = new StreamReader($@"{FilePath}"))
                {
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] inputs = line.Split(',');

                        //myStack.Push(new VideoGame(inputs[0], inputs[1], int.Parse(inputs[2]), inputs[3], inputs[4], double.Parse(inputs[5]), double.Parse(inputs[6]), double.Parse(inputs[7]), double.Parse(inputs[8]), double.Parse(inputs[9])));
                        list.Add(new VideoGame(inputs[0], inputs[1], int.Parse(inputs[2]), inputs[3], inputs[4], double.Parse(inputs[5]), double.Parse(inputs[6]), double.Parse(inputs[7]), double.Parse(inputs[8]), double.Parse(inputs[9])));
                    }
                }
            }
            catch
            {
                Console.WriteLine("ERROR OPENING FILE.");
            }

            // INTRODUCTION //////////////////////////////////////////////////////////////////////////////////////////////
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n*\t*\t*\t*\t*\t*\tDATA STRUCTURES QUEST\t*\t*\t*\t*\t*\t*\n");
            Console.WriteLine("\n\tGreetings, young, old, or middle aged learner!! You have just entered the blue realm of data structures." +
                "\n\tA courageous quest awaits you as you uncover some secrets of stacks, queues, and dictionaries." +
                "\n\tYour mission, should you choose to accept it, is to know how each structure works and its basics." +
                "\n\tFear not, for I your ally will help you!");
            Console.WriteLine("\n...");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\nIMPORTANT: There are three different types of data strucutres we will learn here. They are Stacks, Queues, \nand Dictionaries. Make sure that you are familiar with VideoGames.csv file.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nClick [Enter] to proceed...");
            Console.ReadLine();

            // STACKS ////////////////////////////////////////////////////////////////////////////////////////////// GAMES ARE ADDED BY PUBLISHER AND ORDERED BY YEAR
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\t\tIntroducing Stacks...");
            Console.WriteLine("\n...");
            Console.WriteLine("\nYou will now be able to create your own stack that is ordered by year simply by answering the following question.");
            Console.Write("\nClick [Enter] to proceed...");
            Console.ReadLine();
            Console.WriteLine();

            // DEMO ON HOW ITEMS ARE STORED IN STACKS. /////////
            PublisherLookup();

            Console.WriteLine("\nYou may have choosen a publisher that has a short list of games and this is good." +
                "\nScroll around and you will see that the last game displayed has the year that is the oldest and the first game \ndisplayed has the most recent year. " +
                "This is the way items in a stack are stored and more will be learned in a bit. " +
                "\nIf you chose a publisher with a big amount of games and cannot see the first game do not worry!" +
                "\nThe following is a stack of games published by Nintendo ordered by year.");
            Console.Write("\nClick [Enter] to proceed...");
            Console.ReadLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Black;
            myStack.Clear();
            list.Sort();
            var stackyear1 = list.Where(VideoGame => VideoGame.Publisher == "Nintendo");
            foreach (var VideoGame in stackyear1)
            {
                myStack.Push(VideoGame);
            }

            foreach (var VideoGame in myStack)
            {
                Console.WriteLine(VideoGame.Name + "\tYEAR: " + VideoGame.Year);
            }

            // DEMO ON REMOVING AN ITEM IN STACKS. /////////
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nAs mentioned previously, can see the same thing happening here with how the year is displayed when ordered." +
                "\nThis happened because stacks use the \"LIFO\" principle, which means \"Last in, First out\"." +
                "\nThink of stacking plates on top of each other. To demo we will remove an item." +
                "\nIt will automatically remove the last item stored using \"POP\" from this video game stack. " +
                "\nRemember the first item displayed on the stack currently.");
            Console.Write("\nClick [Enter] to proceed...");
            Console.ReadLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Black;
            var poppedItem = myStack.Pop();
            foreach (var VideoGame in myStack)
            {
                Console.WriteLine(VideoGame.Name + "\tYEAR: " + VideoGame.Year);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nIf you scroll to see, the first item displayed is now the second to last item stored!" +
                "\nIt is essentially the second item displayed in the previous stack!" +
                "\nIf you do not want to scroll because you are tired of scrolling..." +
                "\n\nPOPPED ITEM: " + poppedItem.Name + " " + poppedItem.Year);
            Console.Write("\nClick [Enter] to proceed...");
            Console.ReadLine();
            Console.Clear();

            // DEMO ON ADDING AN ITEM TO STACKS! /////////
            Console.WriteLine("\nNow that you have seen how items are removed from stacks, you will now see how items are added to a stack using \"PUSH\"." +
                "\nThe year will be zero just so you will not have to scroll to find it and it will not be called to sort." +
                "\nIt will be added to the current stack. Can you guess where your game will be displayed at?");
            Console.Write("\nName of your favorite game: ");
            Console.ForegroundColor = ConsoleColor.Black;

            string userInput = Console.ReadLine();
            myStack.Push(new VideoGame(userInput, null, 0, null, null, 0.0, 0.0, 0.0, 0.0, 0.0));
            foreach (var VideoGame in myStack)
            {
                Console.WriteLine(VideoGame.Name + "\tYEAR: " + VideoGame.Year);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nIf you guessed the top then you are right! Your game is the last item stored, so it is the first item that could be removed." +
                "\nNow you have learned a good amount of how stacks function. We will now be moving on to the next data strucutre! Hurrayyyy!!");
            Console.Write("\nClick [Enter] to proceed...");
            Console.ReadLine();

            // QUEUES ////////////////////////////////////////////////////////////////////////////////////////////// GAMES ARE ADDED BY PLATFORM AND ORDERED BY NAME 
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\t\tIntroducing Queues...");
            Console.WriteLine("\n...");
            Console.WriteLine("\nQueues are different and it follows the pinciple of \"FIFO\", which means \"First in, First out\". Think of a supermarket checkout line." +
                "\nYou will now make a queue by entering the name of the platform you wish to use. It will be ordered alphabetically by the name of the game and stored in the queue using \"Enqueue\".");
            Console.Write("\nClick [Enter] to proceed...");
            Console.ReadLine();
            Console.Clear();

            // DEMO ON HOW ITEM ARE STORED TO QUEUES! /////////
            PlatformLookup();

            var firstData = myQueue.Peek(); 

            Console.WriteLine("\nI know you are probably tired of scrolling and therefore not really a younger learner. So, as your helper I will help you." +
                "\n\nFIRST ITEM IN YOUR QUEUE: " + firstData.Name +
                "\n\nIf you do not believe me go on and scroll... go have a young spirit. However, notice how the items are being displayed alphabetically " +
                "correct and not in reverse like a stack.");

            Console.Write("\nClick [Enter] to proceed...");
            Console.ReadLine();
            Console.Clear();

            // DEMO ON REMOVING AN ITEM FROM QUEUES! /////////
            string answer = "";
            bool validInput = false;

            while (!validInput)
            {
                Console.Write("\n\n\tMINI CHALLENGE: If we were to remove a stored item in your queue by simply calling \"Dequeue\", will the last item be removed?" +
                 "\n\tEnter \" T \" for TRUE or \" F \" for FALSE. ");
                answer = Console.ReadLine();

                if (answer.ToUpper() == "F")
                {
                    Console.WriteLine("\n\tThat is correct!");
                    validInput = true;

                }
                else if(answer.ToUpper() == "T")
                {
                    Console.WriteLine("\n\tThat is incorrect. You need some work young learner!");
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("\n\t\tERROR: ENTER AN ACCEPTABLE INPUT. TRY AGAIN!");
                }
            }

            Console.WriteLine("\nYour task now is to see how removing or \"Dequeuing\" an item from a queue works...");
            Console.Write("\nClick [Enter] to proceed...");
            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Black;
            var dequeueItem = myQueue.Dequeue();
            foreach (var videoGame in myQueue)
            {
                Console.WriteLine(videoGame.Name);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nITEM REMOVED: " + dequeueItem.Name + "\nIf you recall, this was the first item displayed from the queue previously and it was the first item stored.");

            // DEMO ON ADDING AN ITEM TO QUEUE! /////////
            Console.WriteLine("\nYour quest continues! You shall now see how adding or \"Enqueuing\" an item to a queue works by adding a game you wish to the queue.\nAgain, the queue will not be called to sort. " +
                "Can you guess where your game will be displayed at?");
            Console.Write("\nClick [Enter] to proceed...");
            Console.ReadLine();
            Console.Clear();

            Console.Write("\nName of video game you wish to add: ");
            Console.ForegroundColor = ConsoleColor.Black;

            string userInput2 = Console.ReadLine();
            myQueue.Enqueue(new VideoGame(userInput2, null, 0, null, null, 0.0, 0.0, 0.0, 0.0, 0.0));
            foreach (var VideoGame in myQueue)
            {
                Console.WriteLine(VideoGame.Name);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nHopefully you guessed bottom! Your game is the last item stored, so it is the last item that could be removed." +
                "\nNow you have learned a good amount of how queues function. Time for the last data structure!");
            Console.Write("\nClick [Enter] to proceed...");
            Console.ReadLine();
            Console.Clear();

            // Dictionary ////////////////////////////////////////////////////////////////////////////////////////////// GENRE AND NAME
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\t\tIntroducing Dictionaries...");
            Console.WriteLine("\n...");
            Console.WriteLine("\nDictionaries may be a little more complex. Think of it as a two-dimensional array. In this case, each item is essentially a record." +
                "\nThere is a \"key\" and \"value\" in the record. The \"key\" is what will be used to basiclly lookup the \"values\". In the record, they are\nstored first, then the \"values\" are stored.");
            Console.Write("\nClick [Enter] to proceed...");
            Console.ReadLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Black;
            foreach (var VideoGame in list)
            {
                myDictionary[VideoGame.Genre] = (VideoGame.Name); //not every game is being added
            }

            foreach (var VideoGame in myDictionary)
            {
                Console.WriteLine(VideoGame);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nAs you can see, when a dictionary is displayed, the \"keys\" and \"values\" in each record are surrounded by \"[ ]\" and are seperated by\n\",\". " +
                "In this case, the genre is the \"keys\" and the name of the videogame is the \"values\". You may be wondering why the list is short.\nWell, this displays a \"keys\" " +
                "feature of dictionaries. They \"key\" must be unique (it acts as an index) and may have only one \"value\".\nTherefore, the \"value\" is being overriden when set to the same \"key\"." +
                "\n\nWE ARE NEARING THE END OF YOUR QUEST!");
            Console.ForegroundColor = ConsoleColor.Black;

            string genreLookup = " ";
            bool success = false;
            while (!success)
            {
                Console.Write("\n\nLAST TASK: To prove \"keys\" act as indexes, choose a genre. It will display the record for the chosen \"key\". ");
                genreLookup = Console.ReadLine();

                if (myDictionary.ContainsKey(genreLookup))
                {
                    string name = myDictionary[genreLookup];
                    Console.WriteLine("\nKEY: " + genreLookup + " VALUE: " + name);
                    Console.Write("\nClick [Enter] to proceed...");
                    success = true;
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("PLEASE ENTER A VALID GENRE!");
                }
            }



            // ENDING ////////////////////////////////////////////////////////////////////////////////////////////// 
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n\n\t\t\t\tYOUR QUEST ENDS HERE! GOODBYE YOUNG, OLD, OR MIDDLE AGED LEARNER!");
            Console.Write("\nClick [Enter] to proceed...");
            Console.ReadLine();
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\t\t\t\t\t\t\t\t...");

        }
        // DEMO ON HOW ITEMS ARE STORED IN STACKS. /////////
        private static void PublisherLookup()
        {
            Console.Clear ();
            Console.Write("\nWhat Publisher do you wish to look up? ");
            Console.ForegroundColor = ConsoleColor.Black;
            string publisherLookup = Console.ReadLine();

            list.Sort();

            bool success = false;
            while (!success)
            {
                bool containsPublisher = myStack.Any(VideoGame => VideoGame.Publisher.Equals(publisherLookup, StringComparison.OrdinalIgnoreCase));

                if (containsPublisher)
                {
                    success = true;
                }
                else
                {
                    Console.Write("\nERROR. " + "\"" + publisherLookup + "\"" + " IS NOT IN THE FILE. ENTER A VALID PUBLISHER. ");
                    publisherLookup = Console.ReadLine();
                    break;
                }
            }

            var stackyear0 = list.Where(VideoGame => VideoGame.Publisher == $"{publisherLookup}"); //I had to use string interpolation and not concatenation.
            foreach (var VideoGame in stackyear0)
            {
                myStack.Push(VideoGame);
            }

            foreach (var VideoGame in myStack)
            {
                Console.WriteLine(VideoGame.Name + "\tYEAR: " + VideoGame.Year);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        //DEMO ON HOW ITEMS ARE STORED IN QUEUES. /////////
        private static void PlatformLookup()
        {
            VideoGame.SortByName(list);

            Console.Write("\nWhat Platform do you wish to use? ");
            Console.ForegroundColor = ConsoleColor.Black;
            string platform = Console.ReadLine();

            bool success = false;
            while (!success)
            {
                bool containsPlatform = myQueue.Any(VideoGame => VideoGame.Platform.Equals(platform, StringComparison.OrdinalIgnoreCase));

                if (containsPlatform)
                {
                    success = true;
                }
                else
                {
                    Console.Write("\nERROR. " + "\"" + platform + "\"" + " IS NOT IN THE FILE. ENTER A VALID PLATFORM. ");
                    platform = Console.ReadLine();
                    break;
                }
            }

            var queues = list.Where(VideoGame => VideoGame.Platform == $"{platform}");
            foreach (var VideoGame in queues)
            {
                myQueue.Enqueue(VideoGame);
            }

            foreach (var VideoGame in myQueue)
            {
                Console.WriteLine("NAME: " + VideoGame.Name);
            }
            Console.ForegroundColor = ConsoleColor.White;

        }
        //DEMO FOR DICTIONARY. /////////
        private static string removeCharacters(string s)
        {
            try
            {
                return Regex.Replace(s, @"[,]]", " ", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

    }
}
