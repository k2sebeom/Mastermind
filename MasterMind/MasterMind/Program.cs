using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        static string Judge(int[] guess, int[] answer)
        {
            string code = "";
            for(int i = 0; i <4; i++)
            {
                if(!answer.Contains(guess[i]))
                {
                    code += " ";
                }
                else if(guess[i] == answer[i])
                {
                    code += "+";
                }
                else
                {
                    code += "-";
                }
            }
            return code;
        }

        static bool IsCorrectInput(string cmd)
        {
            if(cmd.Length < 4 || cmd.Length > 4)
            {
                return false;
            }
            for(int i = 0; i <4; i++)
            {
                int n = 0;
                try
                {
                    n = Convert.ToInt32(cmd[i].ToString());
                }
                catch(FormatException e)
                {
                    return false;
                }
                if (n < 0 || n > 6)
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            Random oRand = new Random();
            Console.WriteLine("\nWelcome to the game of Mastermind! You have 10 turns.\nYou will guess a four digit number.");
            Console.WriteLine("Write your guess in a given format. Ex) 1234\n===============");
            int[] target = new int[4];
            int[] guess = new int[4];
            bool win = false;
            for(int i = 0; i <4; i++)
            {
                target[i] = oRand.Next(1, 7);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.Write("Trial "+(i+1).ToString()+": Enter a four digit number: ");
                string num = Console.ReadLine();

                while (!IsCorrectInput(num))
                {
                    Console.Write("That is NOT a right format. Enter a four digit number. Ex) 1234 :");
                    num = Console.ReadLine();
                }

                for (int j = 0; j < 4; j++)
                {
                    guess[j] = Convert.ToInt32(num[j].ToString());
                }
                string result = Judge(guess, target);
                Console.WriteLine("Result: " + result+"\n----------------------");
                if (result == "++++")
                {
                    Console.WriteLine("Congratulations!  You win!");
                    win = true;
                    break;
                }
            }
            if (!win)
            {
                Console.WriteLine(String.Format("You failed! The answer was {0}, {1}, {2}, {3}", target[0], target[1], target[2], target[3]));
                Console.WriteLine("Try next time!");
            }
            Console.Write("===================\nPress Enter to quit.");
            Console.ReadLine();
        }
    }
}
