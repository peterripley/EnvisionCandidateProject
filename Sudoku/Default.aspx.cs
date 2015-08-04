using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sudoku.Common;
using Sudoku.Core;
using Sudoku.Strategies;

namespace Sudoku.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SolvePuzzles();
        }

        public void SolvePuzzles()
        {
            Puzzle puzzle = null;

            StrategySolver solver = new StrategySolver();
            solver.Strategies.Add(new Comprehensive());
            
            PuzzleInitializer initializer = new FileInitializer();
            initializer.PuzzleFilePath = Server.MapPath("~") + @"..\puzzles\";
            initializer.InitializePuzzle(out puzzle);
            List<char[]> OriginalCellValues = GetPuzzleCellValues(puzzle);

            solver.Solve(puzzle);
            List<char[]> SolvedCellValues = GetPuzzleCellValues(puzzle);

            WritePuzzle(puzzle, OriginalCellValues, SolvedCellValues);
        }

        private List<char[]> GetPuzzleCellValues(Puzzle Puzzle)
        {
            List<char[]> puzzleCellValues = new List<char[]>();
            string[] puzzleRows = Puzzle.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            
            foreach(string row in puzzleRows)
            {
                puzzleCellValues.Add(row.ToCharArray());
            }
            return puzzleCellValues;
        }
        
        private void WritePuzzle(Puzzle Puzzle, List<char[]> OriginalCellValues, List<char[]> SolvedCellValues)
        {
            Table originalPuzzleTable = new Table();
            Table solvedPuzzleTable = new Table();

            for(int rowIndex = 0; rowIndex < OriginalCellValues.Count; rowIndex++)
            {
                char[] originalValues = new char[OriginalCellValues.Count];
                char[] solvedValues = new char[SolvedCellValues.Count];

                originalValues = OriginalCellValues[rowIndex];
                solvedValues = SolvedCellValues[rowIndex];

                TableRow originalTableRow = new TableRow(); 
                TableRow solvedTableRow = new TableRow();

                for (int columnIndex = 0; columnIndex < originalValues.Length; columnIndex++)
                {
                    char originalValue = originalValues[columnIndex];
                    char solvedValue = solvedValues[columnIndex];

                    TableCell originalTableCell = new TableCell();
                    TableCell solvedTableCell = new TableCell();

                    originalTableCell.Width = 21;
                    solvedTableCell.Width = 21;
                    originalTableCell.Style.Add("text-align", "center");
                    solvedTableCell.Style.Add("text-align", "center");
                    originalTableCell.BorderColor = Color.Black;
                    solvedTableCell.BorderColor = Color.Black;
                    originalTableCell.BorderWidth = 1;
                    solvedTableCell.BorderWidth = 1;

                    originalTableCell.Text = originalValue.ToString() == "0" ? " " : originalValue.ToString();
                    solvedTableCell.Text = solvedValue.ToString();

                    if (solvedValue != originalValue)
                    {
                        solvedTableCell.ForeColor = Color.Red;
                    }

                    originalTableRow.Cells.Add(originalTableCell);
                    solvedTableRow.Cells.Add(solvedTableCell);
                    originalTableRow.BorderColor = Color.Black;
                    solvedTableRow.BorderColor = Color.Black;
                    originalTableRow.BorderWidth = 3;
                    solvedTableRow.BorderWidth = 3;
                    
                }
                originalPuzzleTable.Rows.Add(originalTableRow);
                solvedPuzzleTable.Rows.Add(solvedTableRow);
            }
            originalPuzzleTable.BorderColor = Color.Black;
            solvedPuzzleTable.BorderColor = Color.Black;
            originalPuzzleTable.BorderWidth = 3;
            solvedPuzzleTable.BorderWidth = 3;
                        
            this.original.Controls.Add(originalPuzzleTable);
            this.solved.Controls.Add(solvedPuzzleTable);
        }
    }
}
