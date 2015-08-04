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

            originalPuzzleTable.Style.Add("border-spacing", "0px");
            solvedPuzzleTable.Style.Add("border-spacing", "0px");
            originalPuzzleTable.Style.Add("border", "solid black 3px");
            solvedPuzzleTable.Style.Add("border", "solid black 3px");

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
                    originalTableCell.Style.Add("border", "solid black 1px");
                    solvedTableCell.Style.Add("border", "solid black 1px");
                    originalTableCell.Style.Add("padding", "0px");
                    solvedTableCell.Style.Add("padding", "0px");

                    if ((columnIndex + 1) % (Puzzle.BoxWidth) == 0 && columnIndex < (Puzzle.Width - 1))
                    {
                        originalTableCell.Style.Add("border-right", "solid black 3px");
                        solvedTableCell.Style.Add("border-right", "solid black 3px");
                    }

                    if ((rowIndex + 1) % (Puzzle.BoxHeight) == 0 && rowIndex < (Puzzle.Height - 1))
                    {
                        originalTableCell.Style.Add("border-bottom", "solid black 3px;");
                        solvedTableCell.Style.Add("border-bottom", "solid black 3px");
                    }

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
                                    
            this.original.Controls.Add(originalPuzzleTable);
            this.solved.Controls.Add(solvedPuzzleTable);
        }
    }
}
