using Sudoku.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sudoku.Common.Tests
{
    /// <summary>
    ///This is a test class for ColumnTest and is intended
    ///to contain all ColumnTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ColumnTest
    {
        #region Test Attributes

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        #endregion Test Attributes

        #region Tests

        /// <summary>
        ///A test for Column Constructor
        ///</summary>
        [TestMethod()]
        public void ColumnConstructorTest()
        {
            int position = 0; // TODO: Initialize to an appropriate value
            Puzzle puzzle = null; // TODO: Initialize to an appropriate value
            Column target = new Column(position, puzzle);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        #endregion Tests
    }
}