using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Common
{
    public static class Extensions
    {
        public static void SetAsSolved(this Cell Cell)
        {
             string[] remainingValues = Cell.ToString().Split(new char[] { '(', ')',' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (string value in remainingValues)
            {
                if (int.Parse(value) != Cell.Value)
                {
                    Cell.RemovePossibility(int.Parse(value));
                }
            }
        }

        public static void SetAsSolved(this Cell Cell, int Value)
        {
            Cell.Value = Value;
            SetAsSolved(Cell);
        }
        
    }
}
