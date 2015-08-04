using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Common
{
    /// <summary>
    /// Represents a puzzle column  that knows references to cells and its position within a puzzle.
    /// </summary>
    public class Column : Feature
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the Sudoku.Common.Column class
        /// with its specified position and associated puzzle.
        /// </summary>
        public Column(int position, Puzzle puzzle)
            : base(position)
        {
            for(int i=0;i<puzzle.Height;i++)
                this.Cells.Add(puzzle[this.Position, i]);
        }

        #endregion Construction
    }
}
