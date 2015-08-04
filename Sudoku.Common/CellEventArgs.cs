namespace Sudoku.Common
{
    public class CellEventArgs : System.EventArgs
    {
        #region Properties

        private readonly Cell _Cell;
        /// <summary>
        /// Gets the cell involved in the event.
        /// </summary>
        public Cell Cell
        {
            get { return _Cell; }
        }

        #endregion Properties

        #region Construction

        /// <summary>
        /// Initializes a new instance of the Sudoku.Common.CellEventArgs class
        /// with the specified cell.
        /// </summary>
        /// <param name="cell">The cell involved in the event.</param>
        public CellEventArgs(Cell cell)
        {
            _Cell = cell;
        }

        #endregion Construction
    }
}
