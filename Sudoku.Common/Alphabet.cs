using System;
using System.Collections.Generic;

namespace Sudoku.Common
{
    /// <summary>
    /// Represents a complete collection of possible puzzle values.
    /// </summary>
    public class Alphabet : List<int>
    {
        /// <summary>
        /// Creates a new instance of itself with the same values.
        /// </summary>
        /// <returns></returns>
        public Alphabet Clone()
        {
            Alphabet clonedAlphabet = new Alphabet();
            clonedAlphabet.AddRange(this);
            return clonedAlphabet;
        } 
    }
}
