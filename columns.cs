using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine
{
    internal class columns
    {


        public static void columns()
        {
            // ++++++***** C O L U M N S *****+++++++

            if (COLUMNS_CHAR == userChoiceChar)
            {
                /* 3 - check if numbers of a row are all the same */
                Console.WriteLine($"\n \nyour total amount of money is {cashBox}$");
                for (int colCheck = 0; colCheck < slotNumbers.GetLength(0); colCheck++)
                {
                    /* switch on again*/
                    winningMatchFound = true;
                    for (int rowCheck = 0; rowCheck < slotNumbers.GetLength(1); rowCheck++)
                    {
                        if (slotNumbers[0, colCheck] != slotNumbers[rowCheck, colCheck])
                        {
                            winningMatchFound = false;
                            break;
                        }
                    }

                    //handling of gameStatus      


                    if (winningMatchFound)
                    {
                        numberOfMatches++;
                    }
                }

                // 4 - output win / lose

                if (numberOfMatches == 0)
                {
                    Console.WriteLine("You Lose!");

                }
                else
                {
                    Console.WriteLine($"You Win! number of matching columns: {numberOfMatches} ");
                }

                // 5 - keep track of money

                switch (numberOfMatches)
                {
                    case COLUMNS - COLUMNS:
                        cashBox -= CASHBOX_LOSS;
                        break;
                    case COLUMNS - 1:
                        cashBox += BONUS_WIN;
                        break;
                    case COLUMNS:
                        cashBox += (BONUS_WIN * COLUMNS);
                        break;
                    default:
                        cashBox += CASHBOX_WIN;
                        break;
                }
            }
        }


    }
}
