using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Common
{
    /// <summary>
    /// Represents a strategy used to solve Sudoku puzzles.
    /// </summary>
    public abstract class Strategy
    {
        /// <summary>
        /// Applies this strategy to the specified puzzle.
        /// </summary>
        /// <param name="puzzle">The puzzle to which to apply this strategy.</param>
        public abstract void ApplyStrategy(Puzzle puzzle);
    }
}