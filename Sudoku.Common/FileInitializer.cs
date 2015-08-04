using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sudoku.Common
{
    public class FileInitializer : PuzzleInitializer
    {
        public override List<string> GetPuzzleContent()
        {
            DirectoryInfo puzzleDirectory = new DirectoryInfo(PuzzleFilePath);
            FileInfo puzzleFile = puzzleDirectory.GetFiles(PuzzleFileNamePattern, SearchOption.TopDirectoryOnly).FirstOrDefault();
            string puzzleContent = null;

            try
            {
                using (StreamReader puzzleStream = new StreamReader(puzzleFile.FullName))
                {
                    puzzleContent = puzzleStream.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.Write("The puzzle file could not be found or read: ");
                Console.WriteLine(e.Message);
            }
            return new List<string>(puzzleContent.Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
