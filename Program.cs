using System;

namespace Slot_Machine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // creates random number
            Random random = new Random();
            //game start initial statement
            //the user here inputs the amount of money that wants to bet
            
            // game start second statement
     
            // initialized array with the slot numbers
            int[,] slotNumbers = new int[Constants.ROWS, Constants.COLUMNS]; // define the exact number of rows and columns
            // declare number of matching rows/columns that later will change depending on the progression of the game

            int numberOfMatches = 0;
            bool playAgain = true;
            UI_Design.PrintInitialStatement();
            int initialBettingAmount = Int32.Parse(Console.ReadLine()); // Int32.Parse() method is used to convert the string to a number.
            UI_Design.PrintYouBet(initialBettingAmount);
            int cashBox = initialBettingAmount;
            string totalAmountMoney = "your total amount of money is " + cashBox;

            while (playAgain) // while loop is used for repeating a block of code until the user blocks it
            {
                
                Char userChoiceChar = UI_Design.GetUserChoice();
                UI_Design.PrintuserChoiceText();


                numberOfMatches = 0; // reset number of matches

                // 1 - fill 2 dimensional array with random slotNumbers
                //-----------------------------------------------------

                slotNumbers = Logic.PopulateGrid(slotNumbers);

               
                //-----------------------------------------------------

                UI_Design.DisplayArrayInRowsAndColumns(slotNumbers);


                //block that decides if there is a row win or not
                //if gamemode ....
                if (Constants.ROWS_CHAR == userChoiceChar)
                {
                    numberOfMatches = Logic.FindNumberOfMatchingRows(slotNumbers);
                    //call ui method for the user info PrintResult(numberofmatches);

                    UI_Design.OutputWinLoseRows(numberOfMatches);

                    Console.WriteLine();

                    cashBox = cashBox + Logic.CalcRowsWinnings(numberOfMatches);

                    //call ui method for the user info PrintResult(numberofmatches);
                    Console.WriteLine("your total amount of money is " + cashBox);

                    playAgain = Logic.FinalLogic(cashBox);
                }
                else if (Constants.COLUMNS_CHAR == userChoiceChar)
                {
                    numberOfMatches = Logic.FindNumberOfMatchingColumns(slotNumbers);

                    UI_Design.OutputWinLoseColumns(numberOfMatches);

                    Console.WriteLine();

                    cashBox = cashBox + Logic.CalcColumnsWinning(numberOfMatches);

                    Console.WriteLine("your total amount of money is " + cashBox);

                    playAgain = Logic.FinalLogic(cashBox);
                
                }
                else if( Constants.DIA_CHAR == userChoiceChar)
                {
                    numberOfMatches = Logic.CalcDiaWinnings(numberOfMatches);
                    Console.WriteLine();
                    cashBox = cashBox + Logic.CalcDiaWinnings(numberOfMatches);
                    Console.WriteLine("your total amount of money is " + cashBox);

                    playAgain = Logic.FinalLogic(cashBox);
                }

                
                Console.WriteLine("your total amount of money is " + cashBox);

                Console.Clear();
                /*
                     if (Constants.COLUMNS_CHAR == userChoiceChar)
                    {
                        numberOfMatches =  Logic.FindNumberOfMatchingColumns(slotNumbers);
                        cashBox = cashBox + Logic.CalcColumnsWinning(numberOfMatches);
                    }
                     */







            }
            Console.WriteLine("/ngame is over");
        }
    }
}
