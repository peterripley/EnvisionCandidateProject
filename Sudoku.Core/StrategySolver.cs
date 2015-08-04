using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sudoku.Common;

namespace Sudoku.Core
{
    public class StrategySolver : ISolver
    {
        #region Properties

        private readonly List<Strategy> _Strategies;
        /// <summary>
        /// Gets the list of strategies used to solve a Sudoku puzzle.
        /// </summary>
        public List<Strategy> Strategies
        {
            get { return _Strategies; }
        }

        #endregion Properties

        #region Construction

        /// <summary>
        /// Initializes a new instance of the Sudoku.Core.StrategySolver class.
        /// </summary>
        public StrategySolver()
        {
            _Strategies = new List<Strategy>();
        }

        #endregion Construction

        #region ISolver Members

        public void Solve(Puzzle puzzle)
        {
            while (!puzzle.IsSolved)
            {
                foreach (Strategy strategy in this.Strategies)
                    strategy.ApplyStrategy(puzzle);
            }
        }

        #endregion ISolver Members
    }
}
