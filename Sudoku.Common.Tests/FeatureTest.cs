using Sudoku.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Sudoku.Common.Tests
{
    /// <summary>
    ///This is a test class for FeatureTest and is intended
    ///to contain all FeatureTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FeatureTest
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
        ///A test for Feature Constructor
        ///</summary>
        [TestMethod()]
        public void FeatureConstructorTest()
        {
            int position = 0; // TODO: Initialize to an appropriate value
            Feature target = new Feature(position);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            int position = 0; // TODO: Initialize to an appropriate value
            Feature target = new Feature(position); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod()]
        public void ValidateTest()
        {
            int position = 0; // TODO: Initialize to an appropriate value
            Feature target = new Feature(position); // TODO: Initialize to an appropriate value
            target.Validate();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Cells
        ///</summary>
        [TestMethod()]
        public void CellsTest()
        {
            int position = 0; // TODO: Initialize to an appropriate value
            Feature target = new Feature(position); // TODO: Initialize to an appropriate value
            List<Cell> actual;
            actual = target.Cells;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Position
        ///</summary>
        [TestMethod()]
        public void PositionTest()
        {
            int position = 0; // TODO: Initialize to an appropriate value
            Feature target = new Feature(position); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Position;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        #endregion Tests
    }
}