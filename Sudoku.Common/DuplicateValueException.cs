namespace Sudoku.Common
{
    /// <summary>
    /// Represents an exception that is thrown when a duplicate value is identified in a feature.
    /// </summary>
    public class DuplicateValueException : System.Exception
    {
        #region Properties

        private readonly Feature _Feature;
        /// <summary>
        /// Gets the feature that contains the duplicate value.
        /// </summary>
        public Feature Feature
        {
            get { return _Feature; }
        }

        private readonly int _Value;
        /// <summary>
        /// Gets the duplicate value.
        /// </summary>
        public int Value
        {
            get { return _Value; }
        }

        #endregion Properties

        #region Construction

        /// <summary>
        /// Initializes a new instance of the Sudoku.Common.DuplicateValueException class
        /// with the specified feature and value.
        /// </summary>
        /// <param name="feature">The feature that contains the duplicate value.</param>
        /// <param name="value">The duplicate value.</param>
        public DuplicateValueException(Feature feature, int value)
        {
            _Feature = feature;
            _Value = value;
        }

        #endregion Construction

        #region Methods

        public override string ToString()
        {
            return string.Format("Duplicate value [{0}] found in [{1}]",
                this.Value, this.Feature);
        }

        #endregion Methods
    }
}