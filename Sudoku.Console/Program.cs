using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Sudoku.Core;
using Sudoku.Common;
using Sudoku.Strategies;

namespace Sudoku.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            StrategySolver solver = new StrategySolver();

            // TODO: (DONE) Add strategies
            solver.Strategies.Add(new Comprehensive());

            // TODO: (DONE) Initialize puzzle from file
            Puzzle puzzle = null;
            PuzzleInitializer initializer = new FileInitializer();
            initializer.InitializePuzzle(out puzzle);
            Console.WriteLine(puzzle.ToString().Replace('0', ' '));
            
            solver.Solve(puzzle);
            Console.Write(puzzle);
            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to continue.");
            Console.ReadLine();
        }
    }
}
