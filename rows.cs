using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine
{
    internal class rows
    {
        public static void rows()
        {
            //++++++***** R O W S *******++++

            if (ROWS_CHAR == userChoiceChar)
            {
                // 3 - check if numbers of a row are all the same

                Console.WriteLine($"\n \nyour total amount of money is {cashBox}$");

                for (int rowCheck = 0; rowCheck < slotNumbers.GetLength(0); rowCheck++)
                {
                    // switch on again
                    winningMatchFound = true;

                    for (int colCheck = 0; colCheck < slotNumbers.GetLength(1); colCheck++)
                    {
                        if (slotNumbers[rowCheck, 0] != slotNumbers[rowCheck, colCheck])
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
                    Console.WriteLine($"You Win! number of matching rows: {numberOfMatches} ");
                }

                // 5 - keep track of money
                if (numberOfMatches > 0)
                {
                    cashBox += CASHBOX_WIN;
                }
                else if (numberOfMatches == ROWS - 1)
                {
                    cashBox += BONUS_WIN;
                }
                else if (numberOfMatches == ROWS)
                {
                    cashBox += (BONUS_WIN * ROWS);
                }
                else
                {
                    cashBox -= CASHBOX_LOSS;
                }
            }
        }

    }
}
