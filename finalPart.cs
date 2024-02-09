using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine
{
    internal class finalPart
    {
        public static void final()
        {
            /*/final part of game*/


            ConsoleKeyInfo userAnswer = Console.ReadKey(true);
            Char useranswerChar = userAnswer.KeyChar;

            if (cashBox > 0)
            {

                Console.WriteLine("\nDo you want to play again? y/n");
                Console.ReadKey(true);

                if (useranswerChar == NO_CHAR)
                {
                    break;
                }
                else
                {
                    cashBox -= PLAYING_COST;
                }
                Console.WriteLine(userChoiceText);
                ConsoleKeyInfo userNumberChoice = Console.ReadKey(true);
                userChoiceChar = userNumberChoice.KeyChar;


            }
            else
            {

                Console.WriteLine("You don't have money! do you want to bet again? y/n");

                ConsoleKeyInfo userConfirmation = Console.ReadKey(true);
                char userConfirmationChar = userConfirmation.KeyChar;

                if (userConfirmationChar == YES_CHAR)

                {
                    Console.WriteLine($"amount that you want to bet ");
                    int lossConfirmation = Int32.Parse(Console.ReadLine());
                    cashBox = lossConfirmation;
                }
                else
                {
                    break;
                }
            }
            Console.Clear();
        }

    }
}
