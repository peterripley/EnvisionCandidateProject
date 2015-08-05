using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sudoku.Common;

namespace Sudoku.Strategies
{
    /// <summary>
    /// Implements a strategy used to solve Sudoku puzzles.
    /// </summary>
    public class Comprehensive : Strategy
    {
        private Puzzle Puzzle { get; set; }
        
        /// <summary>
        /// Applies this strategy to the specified puzzle.
        /// </summary>
        /// <param name="puzzle">The puzzle to which to apply this strategy.</param>
        public override void ApplyStrategy(Puzzle puzzle)
        {
            this.Puzzle = puzzle;

            while (!Puzzle.IsSolved)
            {
                for (int rowIndex = 0; rowIndex < Puzzle.Height; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < Puzzle.Width; columnIndex++)
                    {
                        Cell cell = Puzzle[columnIndex, rowIndex];
                        if (cell.IsSolved)
                        {
                            RemoveCandidates(columnIndex, rowIndex, cell.Value);
                        }
                    }
                }
            }
            try
            {
                this.Puzzle.Validate();
            }
            catch (Exception e)
            {
                Puzzle.ErrorMessage = e.Message;
            }
        }
        /// <summary>
        /// Removes candidate values from cells using various scanning methods
        /// </summary>
        /// <param name="ColumnIndex">Index of the Puzzle column to scan</param>
        /// <param name="RowIndex">Index of the Puzzle row to scan</param>
        /// <param name="Value">Candidate value to remove from cells</param>
        public void RemoveCandidates(int ColumnIndex, int RowIndex, int Value)
        {
            RemoveRowCandidates(RowIndex, Value);
            RemoveColumnCandidates(ColumnIndex, Value);
            RemoveBoxCandidates(ColumnIndex, RowIndex, Value);
        }
        
        /// <summary>
        /// Removes a value from the possible values each cell in a Puzzle row may contain.
        /// </summary>
        /// <param name="RowIndex">The index of the row's cells to remove the value from.</param>
        /// <param name="CandidateValue">The value to remove.</param>
        public void RemoveRowCandidates(int RowIndex, int CandidateValue)
        {
            for (int columnIndex = 0; columnIndex < Puzzle.Width; columnIndex++)
            {
                Cell columnCell = Puzzle[columnIndex, RowIndex];
                if (!columnCell.IsSolved && columnCell.CanBe(CandidateValue))
                {
                    columnCell.RemovePossibility(CandidateValue);
                    if (columnCell.IsSolved)
                    {
                        RemoveColumnCandidates(columnIndex, columnCell.Value);
                        RemoveBoxCandidates(columnIndex, RowIndex, columnCell.Value);
                    }
                }
            }
        }

        /// <summary>
        /// Removes a value from the possible values each cell in a Puzzle column may contain.
        /// </summary>
        /// <param name="ColumnIndex">The index of the column's cells to remove the value from.</param>
        /// <param name="CandidateValue">The value to remove</param>
        public void RemoveColumnCandidates(int ColumnIndex, int CandidateValue)
        {
            for (int rowIndex = 0; rowIndex < Puzzle.Height; rowIndex++)
            {
                Cell rowCell = Puzzle[ColumnIndex, rowIndex];
                if (!rowCell.IsSolved && rowCell.CanBe(CandidateValue))
                {
                    rowCell.RemovePossibility(CandidateValue);
                    if (rowCell.IsSolved)
                    {
                        RemoveRowCandidates(rowIndex, rowCell.Value);
                        RemoveBoxCandidates(ColumnIndex, rowIndex, rowCell.Value);
                    }
                }
            }
        }

        /// <summary>
        /// Removes a value from the possible values each cell in a Puzzle box may contain.
        /// </summary>
        /// <param name="ColumnIndex">The index of the column in the Puzzle, used to determine the Box.</param>
        /// <param name="RowIndex">The index of the row in the Puzzle, used to determine the Box.</param>
        /// <param name="CandidateValue">The value to remove</param>
        public void RemoveBoxCandidates(int ColumnIndex, int RowIndex, int CandidateValue)
        {
            int boxPosition = ColumnIndex / Puzzle.BoxWidth % Puzzle.Width + RowIndex / Puzzle.BoxHeight * Puzzle.BoxHeight % Puzzle.Height;
            Box box = Puzzle.Boxes.FirstOrDefault(b => b.Position == boxPosition);
            
            foreach(Cell boxCell in box.Cells)
            {
                if (!boxCell.IsSolved && boxCell.CanBe(CandidateValue))
                {
                    boxCell.RemovePossibility(CandidateValue);
                    if (boxCell.IsSolved)
                    {
                        RemoveBoxCandidates(ColumnIndex, RowIndex, boxCell.Value);
                    }
                }
            }
        }
    }
}
