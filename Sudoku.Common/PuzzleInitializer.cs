using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Common
{
    /// <summary>
    /// Base class that provides initialization of a Puzzle. Abstract method GetPuzzleContent() must be implemented by a subclass.
    /// </summary>
    public abstract class PuzzleInitializer
    {
        private string _EmptyCellDesignator = ".";
        private int _EmptyCellValue = 0;
        private int _BoxWidth = 3;
        private int _BoxHeight = 3;

        private string _puzzleFilePath = @"..\..\..\puzzles\";
        private string _puzzleFileNamePattern = "input*.txt";

        public string PuzzleFilePath
        {
            get { return _puzzleFilePath; }
            set { _puzzleFilePath = value; }
        }
        public string PuzzleFileNamePattern
        {
            get { return _puzzleFileNamePattern; }
            set { _puzzleFileNamePattern = value; }
        }
        /// <summary>
        /// Gets or sets the string value that designates an empty puzzle cell.
        /// </summary>
        public string EmptyCellDesignator
        {
            get { return _EmptyCellDesignator; }
            set { _EmptyCellDesignator = value; }
        }
        /// <summary>
        /// Gets or sets the integer value that represents an empty puzzle cell.
        /// </summary>
        public int EmptyCellValue
        {
            get { return _EmptyCellValue; }
            set { _EmptyCellValue = value; }
        }
        /// <summary>
        /// Gets or sets the Puzzle box width
        /// </summary>
        public int BoxWidth
        {
            get { return _BoxWidth; }
            set { _BoxWidth = value; }
        }
        /// <summary>
        /// Gets or sets the Puzzle box size
        /// </summary>
        public int BoxHeight
        {
            get { return _BoxHeight; }
            set { _BoxHeight = value; }
        }
        /// <summary>
        /// Default constructor for inheriting classes
        /// </summary>
        public PuzzleInitializer() { }
        /// <summary>
        /// (Overridable) Accepts an unassigned Puzzle and returns it created and populated with required values.
        /// </summary>
        /// <param name="Puzzle"></param>
        public virtual void InitializePuzzle(out Puzzle Puzzle)
        {
            List<string> puzzleRows = GetPuzzleContent();
            int[] cellValues = new int[puzzleRows[0].Length * puzzleRows.Count];
            Alphabet puzzleAlphabet = new Alphabet();

            ExtractMetadata(puzzleRows);

            // Assumption: All values in the puzzle's alphabet can be found among the pre-filled cells it contains.
            for (int rowIndex = 0; rowIndex < puzzleRows.Count; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < puzzleRows[rowIndex].Length; columnIndex++)
                {
                    string cellValue = puzzleRows[rowIndex].Substring(columnIndex, 1);
                    if (cellValue != _EmptyCellDesignator && !puzzleAlphabet.Contains(int.Parse(cellValue)))
                    {
                        puzzleAlphabet.Add(int.Parse(cellValue));
                    }
                    cellValues[rowIndex * puzzleRows.Count + columnIndex] = cellValue == _EmptyCellDesignator ? _EmptyCellValue : int.Parse(cellValue);
                }
            }

            Puzzle = new Puzzle(puzzleRows[0].Length, puzzleRows.Count, this.BoxWidth, this.BoxHeight, puzzleAlphabet);
            for (int cellIndex = 0; cellIndex < Puzzle.Cells.Count; cellIndex++)
            {
                Puzzle.Cells[cellIndex].Value = cellValues[cellIndex];
                if (Puzzle.Cells[cellIndex].Value != _EmptyCellValue)
                {
                    Puzzle.Cells[cellIndex].SetAsSolved();
                }
            }
        }

        public virtual void ExtractMetadata(List<string> PuzzleRows)
        {
            string boxWidth = null;
            string boxHeight = null;

            List<string> metadata = PuzzleRows.Where(p => p.Contains(":")).ToList();
            PuzzleRows.RemoveAll(p => p.Contains(":"));

            boxWidth = metadata.FirstOrDefault(p => p.Contains("BoxWidth:"));
            boxHeight = metadata.FirstOrDefault(p => p.Contains("BoxHeight:"));

            this._BoxWidth = boxWidth == null ? this._BoxWidth : int.Parse(boxWidth.Split(':')[1]);
            this._BoxHeight = boxHeight == null ? this._BoxHeight : int.Parse(boxHeight.Split(':')[1]);
        }

        /// <summary>
        /// Returns a List of strings representing the rows of elements in a puzzle and any metadata. Required by the default InitializePuzzle method.
        /// </summary>
        /// <returns></returns>
        public abstract List<string> GetPuzzleContent();
    }
}
