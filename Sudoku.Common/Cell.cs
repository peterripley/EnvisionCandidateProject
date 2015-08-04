using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NightRays;

namespace Sudoku.Common
{
    public class Cell
    {
        #region Properties

        private readonly Alphabet _RemainingPossibilities;
        /// <summary>
        /// Gets the remaining possible values this cell can have.
        /// </summary>
        protected Alphabet RemainingPossibilities
        {
            get { return _RemainingPossibilities; }
        }

        private readonly ICellObserver _CellObserver;
        /// <summary>
        /// Gets the observer of this cell.
        /// </summary>
        public ICellObserver CellObserver
        {
            get { return _CellObserver; }
        }

        /// <summary>
        /// Gets whether the cell value has been determined.
        /// </summary>
        public bool IsSolved
        {
            get { return this.RemainingPossibilities.Count == 1; }
        }

        /// <summary>
        /// Gets or sets the solved value of this cell.
        /// </summary>
        public int Value { get; set; }

        #endregion Properties

        #region Construction

        /// <summary>
        /// Initializes a new instance of the Sudoku.Common.Cell class
        /// with the specified puzzle alphabet.
        /// </summary>
        /// <param name="alphabet">The collection of all possible cell values.</param>
        public Cell(Alphabet alphabet)
        {
            _RemainingPossibilities = alphabet.Clone();
        }

        /// <summary>
        /// Initializes a new instance of the Sudoku.Common.Cell class
        /// with the specified puzzle alphabet and observer.
        /// </summary>
        /// <param name="alphabet">The collection of all possible cell values.</param>
        /// <param name="cellObserver">The observer of this cell.</param>
        public Cell(Alphabet alphabet, ICellObserver cellObserver)
        {
            _CellObserver = cellObserver;
            _RemainingPossibilities = alphabet.Clone();
        }

        #endregion Construction

        #region Methods

        /// <summary>
        /// Determines whether the specified value is a remaining possible value.
        /// </summary>
        /// <param name="value">The possible value.</param>
        /// <returns>True if this cell can have this specified value.</returns>
        public bool CanBe(int value)
        {
            return this.RemainingPossibilities.Contains(value);
        }

        /// <summary>
        /// Removes the specified value from the cell's collection of possible values.
        /// </summary>
        /// <param name="value">The possible value to remove.</param>
        public void RemovePossibility(int value)
        {
            if (this.RemainingPossibilities.Contains(value))
            {
                this.RemainingPossibilities.Remove(value);
                OnCellChanged();
                if (this.IsSolved)
                {
                    // PSR 2015.08.03: Line added during candidate project completion.
                    this.Value = RemainingPossibilities.FirstOrDefault();

                    OnCellSolved();
                }
            }
        }

        public override string ToString()
        {
            if (this.IsSolved)
                return this.Value.ToString();
            else
                return string.Format("({0})", this.RemainingPossibilities.Implode(" ", v => v.ToString()));
        }

        #endregion Methods

        #region Event Handling

        /// <summary>
        /// Raises the CellChanged event.
        /// </summary>
        protected virtual void OnCellChanged()
        {
            if(this.CellObserver != null)
                this.CellObserver.ReportCellChanged(this);
        }

        /// <summary>
        /// Raises the CellSolved event.
        /// </summary>
        protected virtual void OnCellSolved()
        {
            if (this.CellObserver != null)
                this.CellObserver.ReportCellSolved(this);
        }

        #endregion Event Handling
    }
}