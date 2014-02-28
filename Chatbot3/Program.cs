using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;

namespace Chatbot3
{
    class Program
    {
        static SpeechSynthesizer reader = new SpeechSynthesizer();

        static List<Word> words = new List<Word>();

        //Method to parse input text and add to words list
        static void splitWords(string input)
        {
            string[] wordbits = input.Split(' ');

            //Add words to list
            for (int i = 0; i < wordbits.Length -1; i += 1)
            {
                int index = words.FindIndex(x => x != null && x.AWord == wordbits[i]);
                if (index == -1)
                {
                    words.Add(new Word() { AWord = wordbits[i] });
                }

            }

            //add references to int list in each instance of the word class.
            for (int i = 0; i < wordbits.Length - 1; i += 1)
            {
                int index = words.FindIndex(x => x != null && x.AWord == wordbits[i]);
                int indexFollowing = words.FindIndex(x => x != null && x.AWord == wordbits[i + 1]);

                words[index].count.Add(indexFollowing);
            }

        }

        //Method to parse text from text file
        static void readFile(string inputFile)
        {
            string[] lines = System.IO.File.ReadAllLines(inputFile);
            for(int j = 0; j < lines.Length; j++)
            {
                string[] wordbits = lines[j].Split(' ', '.', ',','-');

                for (int i = 0; i < wordbits.Length - 1; i += 1)
                {
                    int index = words.FindIndex(foo => foo != null && foo.AWord == wordbits[i]);
                    int indexFollowing = words.FindIndex(foo => foo != null && foo.AWord == wordbits[i + 1]);
                    if (index == -1)
                    {
                        
                        words.Add(new Word() { AWord = wordbits[i] });
                        
                    }
                    
                }


                for (int i = 0; i < wordbits.Length - 1; i += 1)
                {
                    int index = words.FindIndex(foo => foo != null && foo.AWord == wordbits[i]);
                    int indexFollowing = words.FindIndex(foo => foo != null && foo.AWord == wordbits[i + 1]);

                    words[index].count.Add(indexFollowing);
                }

            }
        }

        //Method to return text to user.
        static void talkback(string input)
        {
            string[] wordbits = input.Split(' ');
            int index = words.FindIndex(foo => foo != null && foo.AWord == wordbits[0]);
            
            if (index < 0)
            {
                Random myRan = new Random();
                int ran = myRan.Next(words.Count);
                index = ran;
            }
            string output = words[index].AWord + " ";

                Random myran = new Random();
                int j = myran.Next(words[index].count.Count);
                if (j < 0)
                {
                    j = myran.Next(words.Count);
                }

                int follow = words[index].count[j];  
                if (follow == -1)
                {
                    follow = myran.Next(words.Count);
                }
                

                int k = myran.Next(words[follow].count.Count);
                int follow2 = words[follow].count[k];
                if (follow2 < 0)
                {
                    follow2 = myran.Next(words.Count);
                }
                

                int l = myran.Next(words[follow2].count.Count);
                int follow3 = words[follow2].count[l];
                if (follow3 < 0)
                {
                    follow3 = myran.Next(words.Count);
                }
                
                
                int m = myran.Next(words[follow3].count.Count);
                int follow4 = words[follow3].count[m];
                if (follow4 < 0)
                {
                    follow4 = myran.Next(words.Count);
                }
                
                int n = myran.Next(words[follow4].count.Count);
                int follow5 = words[follow4].count[n];
                if (follow5 < 0)
                {
                    follow5 = myran.Next(words.Count);
                }
                
                int o = myran.Next(words[follow5].count.Count);
                int follow6 = words[follow5].count[o];
                if (follow6 < 0)
                {
                    follow6 = myran.Next(words.Count);
                }
                

                
                int h = myran.Next(words.Count);
                
                Console.Write("DANI> ");

                if (wordbits.Length > 1)
                {
                    output += (words[follow] + " ");
                }
                if (wordbits.Length > 2)
                {
                    output += (words[follow2] + " ");
                }
                if (wordbits.Length > 3)
                {
                    output += (words[follow3] + " ");
                }
                if (wordbits.Length > 3)
                {
                    output += (words[follow4] + " ");
                }
                if (wordbits.Length > 4)
                {
                    output += (words[follow5] + " ");
                    output += (words[follow6] + " ");
                }

                //output = (words[index] + " " + words[follow] + " " + words[follow2] + " " + words[follow3]);
                Console.WriteLine(output);
                reader.SpeakAsync(output);
        }


        static void Main(string[] args)
        {
            
            Console.WriteLine("DANI> Hello my name is DANI. I'm a *Somewhat* intelligent robot thing");
            reader.SpeakAsync("Hello my name is DANI. I'm a Somewhat intelligent robot thing");
            Console.WriteLine();
            Console.WriteLine("If you would like to teach me some new words, press # to see my bookshelf");
            Console.WriteLine();
            Console.WriteLine("Enter 'quit' to quit at any time");
            Console.WriteLine();
            Console.WriteLine("Please tell me your name");
            reader.SpeakAsync("Please tell me your name");
            string userName = Console.ReadLine();
            string reply = ("It's nice to meet you " + userName);
            Console.WriteLine(reply);
            reader.SpeakAsync(reply);
            Console.WriteLine("DANI> Let's have a chat. What do you want to talk about today?");
            reader.SpeakAsync("Let's have a chat. What do you want to talk about today?");
            while (true)
            {
            quitCase:
                Console.Write("You>");
                string input = Console.ReadLine();

                if (input == "quit")
                {
                    break;
                }
                if (input == "#")
                {
                    //books stored as text files in the bin\debug\ folder.
                
                FileSelect:
                    Console.WriteLine("Books available for me to read are:");
                Console.WriteLine();
                    Console.WriteLine("1 - Fear and Loathing in Las Vegas by Hunter S. Thompson");
                    Console.WriteLine("2 - The Wizard of Oz, by L. Frank Baum");
                    Console.WriteLine("3 - A Midsommer Nights Dreame, by William Shakespeare");
                    Console.WriteLine();
                    Console.WriteLine("Please enter the number of the book you would like me to read. Enter 0 to Quit.");
                    
                    Console.Write("Book No.> ");
                    
                    int inputNo = int.Parse(Console.ReadLine());
                    Console.WriteLine("Reading! This may take a moment, I'm a slow reader");
                    string inputFile = "";
                    switch (inputNo)
                    {
                        case 0:
                            goto quitCase;
                        case 1:
                            inputFile = "fearAndLoathing.txt";
                            break;
                        case 2:
                            inputFile = "theWizardOfOz.txt";
                            break;
                        case 3:
                            inputFile = "aMidsommerNightsDream.txt";
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("**Invalid input, please enter one of the options provided**");
                            goto FileSelect;
                    }
                    readFile(inputFile);
                }
                 

                else
                {
                    splitWords(input);
                    talkback(input);
                }

            }
        }
    }
}