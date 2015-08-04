using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Common
{
    /// <summary>
    /// Represents a puzzle box that knows references to cells and its position within a puzzle.
    /// </summary>
    public class Box : Feature
    {   
        #region Properties
        #endregion
        #region Construction

        /// <summary>
        /// Initializes a new instance of the Sudoku.Common.Box class
        /// with its specified position and associated puzzle.
        /// </summary>
        /// 
        public Box(int position, Puzzle puzzle)
            : base(position)
        {
            // TODO: (DONE) Identify cells
            PopulateCells(position, puzzle);
        }
        
        #endregion Construction
        #region Methods

        /// <summary>
        /// Populates the Cells collection for the Box based on the Position supplied.
        /// </summary>
        /// <param name="Position">The position of the Box in the Puzzle (numbered left-to-right then down).</param>
        /// <param name="puzzle">The associated Puzzle</param>
        private void PopulateCells(int Position, Puzzle puzzle)
        {
            int firstColumnIndex = Position % puzzle.BoxWidth * puzzle.BoxWidth;
            int firstRowIndex = Position / puzzle.BoxHeight * puzzle.BoxHeight % puzzle.Height;

            for (int rowIndex = firstRowIndex; rowIndex < firstRowIndex + puzzle.BoxHeight; rowIndex++)
            {
                for (int columnIndex = firstColumnIndex; columnIndex < firstColumnIndex + puzzle.BoxWidth; columnIndex++)
                {
                    this.Cells.Add(puzzle[columnIndex, rowIndex]);
                }
            }
        }

        #endregion
    }
}
