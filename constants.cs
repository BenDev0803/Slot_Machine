using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine
{
    internal class Constants
    {
            public const int ROWS = 3;
            public const int COLUMNS = 3;
            public const int NUMBER_OF_DIAGONALS = 2;
        //declare range of numbers that should be displayed randomly
            public const int MAX = 9;
            public const int MIN = 1;
        // declare bonus win for multiple matching rows/columns

        // declare characters that user should press for choosing rows, diagonals, columns, yes or no
            public const char COLUMNS_CHAR = 'c';
            public const char ROWS_CHAR = 'r';
            public const char DIA_CHAR = 'd';
            public const char YES_CONFIRMATION_CHAR = 'y';
            public const char NO_CONFIRMATION_CHAR = 'n';

            // cashbox win / cashbox loss constants
            public const int CASHBOX_WIN = 2;
            public const int CASHBOX_LOSS = -1;
            public const int PLAYING_COST = -1;
            public const int BONUS_WIN = 10;
            
    }
}
