using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Common
{
    /// <summary>
    /// Represents a Sudoku puzzle containing features that contain cells.
    /// </summary>
    public class Puzzle : ICellObserver
    {
        #region Fields

        public event EventHandler<CellEventArgs> CellChanged;

        public event EventHandler<CellEventArgs> CellSolved;

        #endregion Fields

        #region Properties

        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets the cell associated with the specified column and row.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        /// <returns>The cell associated with the specified column and row.</returns>
        public Cell this[int column, int row]
        {
            get { return this.Cells[row * this.Width + column]; }
        }

        private readonly Alphabet _Alphabet;
        /// <summary>
        /// Gets the puzzle alphabet that contains all possible values.
        /// </summary>
        public Alphabet Alphabet
        {
            get { return _Alphabet; }
        }

        /// <summary>
        /// Gets whether the puzzles is solved.
        /// </summary>
        public bool IsSolved
        {
            get { return this.SolveCount == this.Size; }
        }

        /// <summary>
        /// Gets the number of cells in the puzzle.
        /// </summary>
        private int Size
        {
            get { return this.Width * this.Height; }
        }

        private int _SolveCount;
        /// <summary>
        /// Gets or sets the number of cells solved.
        /// </summary>
        public int SolveCount
        {
            get { return _SolveCount; }
            private set { _SolveCount = value; }
        }

        #region Dimensions

        private readonly int _BoxHeight;
        /// <summary>
        /// Gets the height of a box in the puzzle.
        /// </summary>
        public int BoxHeight
        {
            get { return _BoxHeight; }
        }

        private readonly int _BoxWidth;
        /// <summary>
        /// Gets the width of a box in the puzzle.
        /// </summary>
        public int BoxWidth
        {
            get { return _BoxWidth; }
        }

        private readonly int _Height;
        /// <summary>
        /// Gets the height of the puzzle.
        /// </summary>
        public int Height
        {
            get { return _Height; }
        }

        private readonly int _Width;
        /// <summary>
        /// Gets the width of the puzzle.
        /// </summary>
        public int Width
        {
            get { return _Width; }
        }

        #endregion Dimensions

        #region Features

        private readonly List<Box> _Boxes;
        /// <summary>
        /// Gets the collection of boxes in the puzzle.
        /// </summary>
        public List<Box> Boxes
        {
            get { return _Boxes; }
        }

        private readonly List<Cell> _Cells;
        /// <summary>
        /// Gets the collection of cells in the puzzle.
        /// </summary>
        public List<Cell> Cells
        {
            get { return _Cells; }
        }

        private readonly List<Column> _Columns;
        /// <summary>
        /// Gets the collection of columns in the puzzle.
        /// </summary>
        public List<Column> Columns
        {
            get { return _Columns; }
        }

        #endregion Features

        #endregion Properties

        #region Construction

        /// <summary>
        /// Initializes a new instance of the Sudoku.Common.Puzzle class
        /// with the specified dimensions and alphabet.
        /// <param name="width">The width of the puzzle.</param>
        /// <param name="height">The height of the puzzle.</param>
        /// <param name="boxWidth">The width of any box in the puzzle.</param>
        /// <param name="boxHeight">The height of any box in the puzzle.</param>
        /// <param name="alphabet">The puzzle alphabet that contains all possible values.</param>
        public Puzzle(int width, int height, int boxWidth, int boxHeight, Alphabet alphabet)
        {
            _Width = width;
            _Height = height;
            _BoxHeight = boxHeight;
            _BoxWidth = boxWidth;
            _Alphabet = alphabet;
            this.SolveCount = 0;

            // Has to be first
            _Cells = new List<Cell>();
            int cellCount = width * height;
            for (int i = 0; i < cellCount; i++)
                this.Cells.Add(new Cell(alphabet, this));

            _Columns = new List<Column>();
            for (int i = 0; i < width; i++)
                this.Columns.Add(new Column(i, this));
            
            _Boxes = new List<Box>();
            int boxCount = (width / boxWidth) * (height / boxHeight);
            for (int i = 0; i < boxCount; i++)
                this.Boxes.Add(new Box(i, this));
        }

        #endregion Construction

        #region Methods

        /// <summary>
        /// Validates the puzzles.
        /// </summary>
        public void Validate()
        {
            foreach (Column column in this.Columns)
                column.Validate();
            foreach (Box box in this.Boxes)
                box.Validate();
        }
        /// <summary>
        /// Overrides base ToString() to return a string formatted with the Puzzle dimensions
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder formattedString = new StringBuilder();
            for (int rowIndex = 0; rowIndex < this.Height; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < this.Width; columnIndex++)
                {
                    formattedString.Append(this[columnIndex, rowIndex].Value);
                }
                formattedString.Append(Environment.NewLine);
            }
            return formattedString.ToString();
        }

        #endregion Methods

        #region Event Handling

        /// <summary>
        /// Raises the CellChanged event.
        /// </summary>
        protected virtual void OnCellChanged(Cell cell)
        {
            var e = CellChanged;
            if (e != null)
                e(this, new CellEventArgs(cell));
        }

        /// <summary>
        /// Raises the CellSolved event.
        /// </summary>
        protected virtual void OnCellSolved(Cell cell)
        {
            this.SolveCount++;
            var e = CellSolved;
            if (e != null)
                e(this, new CellEventArgs(cell));
        }

        #endregion Event Handling

        #region ICellObserver Members

        public void ReportCellChanged(Cell cell)
        {
            OnCellChanged(cell);
        }

        public void ReportCellSolved(Cell cell)
        {
            OnCellSolved(cell);
        }

        #endregion
    }
}