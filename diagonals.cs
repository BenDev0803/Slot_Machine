using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine
{
    internal class diagonals
    {
        public static void diagonals()
        {

            /* +++++***** D I A G O N A L S *******++++++*/
            if (DIA_CHAR == userChoiceChar)
            {
                Console.WriteLine($"\n \nyour total amount of money is {cashBox}$");
                /*/ +++++***** L     E     F   T *******++++++*/
                for (int diaLeft = 0; diaLeft < slotNumbers.GetLength(0); diaLeft++)
                {
                    winningMatchFoundLeft = true;
                    if (slotNumbers[0, 0] != slotNumbers[diaLeft, diaLeft])
                    {
                        winningMatchFoundLeft = false;
                        break;
                    }
                }
                /*/ +++++***** R   I  G   H    T *******++++++*/
                for (int diaRight = 0; diaRight < slotNumbers.GetLength(1); diaRight++)
                {
                    winningMatchFoundRight = true;
                    int columnIndex = slotNumbers.GetLength(1) - diaRight - 1;
                    if (slotNumbers[0, slotNumbers.GetLength(1) - 1] != slotNumbers[diaRight, columnIndex])
                    {
                        winningMatchFoundRight = false;
                        break;
                    }
                }


                if (winningMatchFoundLeft || winningMatchFoundRight == true)
                {
                    numberOfMatches++;
                }

                /*/ 4 - output win / lose*/
                if (numberOfMatches == 0)
                {
                    Console.WriteLine("You Lose!");
                }
                else
                {
                    Console.WriteLine($"You Win! number of matching diagonals: {numberOfMatches} ");
                }
                /*/ 5 - keep track of money*/
                switch (numberOfMatches)
                {
                    case DIAGONALS:
                        cashBox += BONUS_WIN * DIAGONALS;
                        break;
                    case DIAGONALS - DIAGONALS:
                        cashBox -= CASHBOX_LOSS;
                        break;
                    default:
                        cashBox -= CASHBOX_WIN;
                        break;
                }
            }
        }
    }
}
