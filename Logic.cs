using System;
using System.Security.Cryptography.X509Certificates;

namespace Slot_Machine
{
    public static class Logic
    {
        // cashbox win / cashbox loss constants
        const int CASHBOX_WIN = 2;
        const int CASHBOX_LOSS = -1;
        const int PLAYING_COST = -1;
        const int BONUS_WIN = 10;
        const int ROWS = 3;
        const int COLUMNS = 3;
        const int DIAGONALS = 2;

        public class numberOfMatchesClass 
        {
            int numberofMatches = 0;

        }


        // 3 - check if numbers of a row are all the same-
        public static int FindNumberOfMatchingRows(int[,] slotNumbers)
        {
            bool winningMatchFound = false;
            int numberOfMatches = 0;

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
            return numberOfMatches;
        }

        // 5 - keep track of money (depending on number of matches calculate cash available)
        public static int CalcRowsWinnings(int numOfMatches)
        {
         //   int amount = 0;

            if (numOfMatches > 0)
            {
                return CASHBOX_WIN;
            }
            else if (numOfMatches == ROWS - 1)
            {
                return BONUS_WIN;
            }
            else if (numOfMatches == ROWS)
            {
                return (BONUS_WIN * ROWS);
            }
            else
            {
                return -CASHBOX_LOSS;
            }

            //return amount;
        }

        public static void ColumnsLogic(int[,] slotNumbers)
        {
            bool winningMatchFound = false;
            int numberOfMatches = 0;

            /* 3 - check if numbers of a row are all the same */
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
        }

        public static int CalcColumnsWinning(int numOfMatches)
        {
            if (numOfMatches > 0)
            {
                return CASHBOX_WIN;
            }
            else if (numOfMatches == COLUMNS - 1)
            {
                return BONUS_WIN;
            }
            else if (numOfMatches == COLUMNS)
            {
                return (BONUS_WIN * COLUMNS);
            }
            else
            {
                return -CASHBOX_LOSS;
            }
        } 
        public static void DiagonalsLogic(int[,] slotNumbers)
        {
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

        


        public static void FinalLogic(int[,] slotNumbers)
        {
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
