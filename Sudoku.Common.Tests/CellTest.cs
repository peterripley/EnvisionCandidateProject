using Sudoku.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sudoku.Common.Tests
{
    /// <summary>
    /// This is a test class for CellTest and is intended
    /// to contain all CellTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CellTest
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

        #region Helpers

        /// <summary>
        /// Creates a new instance of a default alphabet.
        /// </summary>
        /// <returns>A new instance of an Alphabet with values 1 - 9.</returns>
        public Alphabet CreateDefaultAlphabet()
        {
            return new Alphabet() {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };
        }

        #endregion Helpers

        #region Tests

        /// <summary>
        ///A test for Cell Constructor
        ///</summary>
        [TestMethod()]
        public void CellConstructorTest()
        {
            /*** ARRANGE ***/
            Alphabet alphabet = null; // TODO: Initialize to an appropriate value

            /*** ACT ***/
            Cell target = new Cell(alphabet);

            /*** ASSERT ***/
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        /// A test for RemovePossibility to verify that removed values can no longer be possible values without affecting the specified alphabet.
        /// </summary>
        [TestMethod()]
        public void RemovePossibilityTest()
        {
            /*** ARRANGE ***/
            Alphabet alphabet = CreateDefaultAlphabet();
            Cell target = new Cell(alphabet);
            int value = 3;                              // arbitrary

            /*** ACT ***/
            target.RemovePossibility(value);

            /*** ASSERT ***/
            Assert.IsFalse(target.CanBe(value));        // value is no longer a possible value
            Assert.IsTrue(alphabet.Contains(value));    // alphabet remains unchanged
        }

        /// <summary>
        /// A test for CanBe
        /// </summary>
        [TestMethod()]
        public void CanBeTest()
        {
            Alphabet alphabet = null; // TODO: Initialize to an appropriate value
            Cell target = new Cell(alphabet); // TODO: Initialize to an appropriate value
            int value = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.CanBe(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsSolved
        ///</summary>
        [TestMethod()]
        public void IsSolvedTest()
        {
            Alphabet alphabet = null; // TODO: Initialize to an appropriate value
            Cell target = new Cell(alphabet); // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsSolved;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        /// A test for setting the cell's Value.
        /// </summary>
        [TestMethod()]
        public void ValueTest()
        {
            /*** ARRANGE ***/
            Alphabet alphabet = CreateDefaultAlphabet();
            Cell target = new Cell(alphabet);
            int expected = 3;                   // arbitrary
            int actual;

            /*** ACT ***/
            target.Value = expected;

            /*** ASSERT ***/
            actual = target.Value;
            Assert.AreEqual(expected, actual);  // value setting successful

            alphabet.Remove(expected);          // cell can be no other value
            foreach (int value in alphabet)
                Assert.IsFalse(target.CanBe(value));
        }

        #endregion Tests
    }
}