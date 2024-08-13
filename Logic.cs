using System;
using System.Security.Cryptography.X509Certificates;

namespace Slot_Machine
{
    public static class Logic
    {
        
        


        public static int[,] PopulateGrid(int[,] slotNumbers)
        {
            for(int col = 0; col < slotNumbers.GetLength(0); col++)
                {
                for (int row = 0; row < slotNumbers.GetLength(1); row++)
                {
                    // creates random number
                    Random random = new Random();
                    int computerChoice = random.Next(Constants.MIN, Constants.MAX + 1);
                    slotNumbers[col, row] = 1;
                }

            }
            return slotNumbers;
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
        public static int CalcRowsWinnings(int numberOfMatches)
        {
            int amount = 0;


            if (numberOfMatches == 1)
            {

                amount = Constants.CASHBOX_WIN ;
                
            }
            else if (numberOfMatches == Constants.ROWS - 1)
            {
                amount = Constants.BONUS_WIN;
            }
            else if (numberOfMatches == Constants.ROWS)
            {
                amount = (Constants.BONUS_WIN * Constants.ROWS);
            }
            else
            {
                amount = Constants.CASHBOX_LOSS - amount;
            }

            return amount;
        }

        public static int FindNumberOfMatchingColumns(int[,] slotNumbers)
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
            return numberOfMatches;
        }

        public static int CalcColumnsWinning(int numOfMatches)
        {
            int amount = 0;

            //1. 0 wins if
            //2. 1 win else if
            //3. Constants.COLUMNS wins -> user wins on all columns 5X5  else if
            //4. all the others else

            if (numOfMatches == 1)
            {
                amount += Constants.CASHBOX_WIN;
            }
            else if (numOfMatches == Constants.COLUMNS - 1)
            {

                amount += Constants.BONUS_WIN;
            }
            else if (numOfMatches == Constants.COLUMNS)
            {
                amount += (Constants.BONUS_WIN * Constants.COLUMNS);
            }
            else
            {
                amount = -Constants.CASHBOX_LOSS;
            }
             return amount;
        }
        public static void FindNumberOfMatchingDiagonals(int[,] slotNumbers)
        {
            /*/ +++++***** L     E     F   T *******++++++*/
            bool winningMatchFoundLeft = false;
            bool winningMatchFoundRight = false;
            int numOfMatches = 0;
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
                numOfMatches++;
            }



        }
        public static int CalcDiaWinnings(int numOfMatches)
        {
            
            int amount = 0;

            switch (numOfMatches )
            {
                case Constants.NUMBER_OF_DIAGONALS:
                    amount += Constants.BONUS_WIN * Constants.NUMBER_OF_DIAGONALS;
                    break;
                case 1:
                    amount += Constants.CASHBOX_WIN;
                    break;
                default:
                    amount -= Constants.CASHBOX_LOSS;
                    break;
            }
            return amount;
        }

        //public static bool 
        public static bool FinalLogic(int cashBox)
        {
            //ConsoleKeyInfo userAnswer = Console.ReadKey();
            //Char useranswerChar = userAnswer.KeyChar;
            
            if (cashBox > 0)
            {

                Console.WriteLine("\nDo you want to play again? y/n");
                ConsoleKeyInfo userAnswer = Console.ReadKey();
                Char useranswerChar = userAnswer.KeyChar;
                //Console.ReadKey();

                if (useranswerChar == Constants.YES_CONFIRMATION_CHAR)
                {
                    cashBox -= Constants.PLAYING_COST;
                    return true;
                }                
                    return false;
              
            }
            else
            {

                Console.WriteLine("You don't have money! do you want to bet again? y/n");
                ConsoleKeyInfo userConfirmation = Console.ReadKey();
                char userConfirmationChar = userConfirmation.KeyChar;

                if (userConfirmationChar == Constants.YES_CONFIRMATION_CHAR)

                {
                    Console.WriteLine($"amount that you want to bet ");
                    int lossConfirmation = Int32.Parse(Console.ReadLine());
                    cashBox = lossConfirmation;
                    return true;
                }
                return true;
            }
        }
    }

}
    



    
        
            


    

