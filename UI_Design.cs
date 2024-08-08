using System;

namespace Slot_Machine
{
    public static class UI_Design
    {





        public static void PrintInitialStatement()
        {
            string initialStatement = "\nSlot machine! place your bet! every spin costs 1$, if you win you get 1$!";
            Console.WriteLine(initialStatement);
        }
        public static void PrintuserChoiceText() { Console.WriteLine("do you want to play rows (r), columns (c) or diagonals (d)?"); }

        public static Char GetUserChoice()
        {
            PrintuserChoiceText();
            // read the input from the user
            ConsoleKeyInfo userChoiceKeyInfo = Console.ReadKey(true);
            Char userChoiceChar = userChoiceKeyInfo.KeyChar;
            return userChoiceChar;
        }

        public static void PrintYouBet(string youBet) { Console.WriteLine(youBet); }
        public static void PrintTotalAmountMoney(string totalAmountMoney) { Console.WriteLine(totalAmountMoney); }


        public static void DisplayArrayInRowsAndColumns(int[,] slotNumbers)
        {
            for (int col = 0; col < slotNumbers.GetLength(0); col++)
            {
                char arrayInRowsNColumns = ' ';
                Console.WriteLine();
                for (int row = 0; row < slotNumbers.GetLength(1); row++)
                {
                    Console.Write(arrayInRowsNColumns);
                    Console.Write(slotNumbers[col, row]);
                    Console.Write(arrayInRowsNColumns);
                }
                Console.Write(arrayInRowsNColumns);
            }
        }

        //        // 4 - output win / lose (depending on number of matches, is displays Youwin / you lose)
        public static int OutputWinLoseRows(int numOfMatches)
        {
            if (numOfMatches == 0)
            {
                string lose = "You Lose!";
                Console.WriteLine(lose);
                
            }
            else
            {
                string win = $"You Win! number of matching rows: {numOfMatches} ";
                Console.WriteLine(win);
            }
            return numOfMatches;
        }
        public static void OutputWinLoseColumns(int numOfMatches)
        {
            if (numOfMatches == 0)
            {
                Console.WriteLine("You Lose!");

            }
            else
            {
                Console.WriteLine($"You Win! number of matching columns: {numOfMatches} ");
            }
        }

        public static void OutputWinLoseDiagonals(int numOfMatches)
        {
            /*/ 4 - output win / lose*/
            if (numOfMatches == 0)
            {
                Console.WriteLine("You Lose!");
            }
            else
            {
                Console.WriteLine($"You Win! number of matching diagonals: {numOfMatches} ");
            }
        }

        /*
         * public static void FinalUIoutputs()
        {
            Console.WriteLine(userChoiceText);
                ConsoleKeyInfo userNumberChoice = Console.ReadKey(true);
                userChoiceChar = userNumberChoice.KeyChar;
        }
         */
    }
}


