using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine
{
    public static class UI_Design
    {

        //    2 - display array in rows and columns
        //   ---------------------------------------------------- -
        //    for (int col = 0; col < slotNumbers.GetLength(0); col++)
        //    {
        //        Console.WriteLine();

        //        for (int row = 0; row < slotNumbers.GetLength(1); row++)
        //        {
        //            Console.Write(' ');
        //            Console.Write(slotNumbers[col, row]);
        //            Console.Write(' ');
        //        }
        //        Console.Write(' ');
        //    }
        //}

        public static void printInitialStatement(string initialStatement){Console.WriteLine(initialStatement);}
        public static void printuserChoiceText(string userChoiceText) { Console.WriteLine(userChoiceText); }
        public static void printYouBet(string youBet) { Console.WriteLine(youBet); }  
        public static void printTotalAmountMoney(string totalAmountMoney) { Console.WriteLine(totalAmountMoney); }

        public static void displayArrayInRowsAndColumns(int[] slotNumbers)
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

        
    }

}

