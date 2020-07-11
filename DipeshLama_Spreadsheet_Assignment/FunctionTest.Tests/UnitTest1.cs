using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DipeshLama_Spreadsheet_Assignment;
namespace FunctionTest.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PassTestSum()
        {
            DipeshLama_Spreadsheet_Assignment.FormulaClass f = new DipeshLama_Spreadsheet_Assignment.FormulaClass();
            List<double> values = new List<double> { 1, 2, 3, 4 };
            double Result = f.Sum_Formula(values);
            Assert.AreEqual(10, Result);
        }
        [TestMethod]
        public void FailTestSum2()
        {
            DipeshLama_Spreadsheet_Assignment.FormulaClass f = new DipeshLama_Spreadsheet_Assignment.FormulaClass();
            List<double> values = new List<double> { 1, 2, 3, 4 };
            double Result = f.Sum_Formula(values);
            Assert.AreEqual(50, Result);
        }


        [TestMethod]
        public void PassTestMedian()
        {
            FormulaClass fc = new FormulaClass();
            DipeshLama_Spreadsheet_Assignment.FormulaClass f = new DipeshLama_Spreadsheet_Assignment.FormulaClass();
            List<double> values = new List<double> { 1, 2, 4,58, 42};
            List<double> sortedList = fc.SortedList(values);
            double Result = f.Median_Formula(sortedList);
            Assert.AreEqual(4, Result);
        }


        [TestMethod]
        public void FailTestMedian2()
        {
            FormulaClass fc = new FormulaClass();
            DipeshLama_Spreadsheet_Assignment.FormulaClass f = new DipeshLama_Spreadsheet_Assignment.FormulaClass();
            List<double> values = new List<double> { 1, 2, 4, 58, 42 };
            List<double> sortedList = fc.SortedList(values);
            double Result = f.Median_Formula(sortedList);
            Assert.AreEqual(58, Result);
        }


        [TestMethod]
        public void PassTestMean()
        {
            DipeshLama_Spreadsheet_Assignment.FormulaClass f = new DipeshLama_Spreadsheet_Assignment.FormulaClass();
            List<double> values = new List<double> { 5, 5, 5, 5 };
            double Result = f.Mean_Formula(values);
            Assert.AreEqual(5, Result);
        }

        [TestMethod]
        public void FailTestMean2()
        {
            DipeshLama_Spreadsheet_Assignment.FormulaClass f = new DipeshLama_Spreadsheet_Assignment.FormulaClass();
            List<double> values = new List<double> { 5, 5, 5, 5 };
            double Result = f.Mean_Formula(values);
            Assert.AreEqual(10, Result);
        }


        [TestMethod]
        public void PassTestMode()
        {
            DipeshLama_Spreadsheet_Assignment.FormulaClass f = new DipeshLama_Spreadsheet_Assignment.FormulaClass();
            List<double> values = new List<double> { 2, 2, 3, 4, 2 };
            double Result = f.Mode_Formula(values);
            Assert.AreEqual(2, Result);
        }

        [TestMethod]
        public void FailTestMode2()
        {
            DipeshLama_Spreadsheet_Assignment.FormulaClass f = new DipeshLama_Spreadsheet_Assignment.FormulaClass();
            List<double> values = new List<double> { 2, 2, 3, 4, 2 };
            double Result = f.Mode_Formula(values);
            Assert.AreEqual(4, Result);
        }

        [TestMethod]
        public void PassTestMultiply()
        {
            DipeshLama_Spreadsheet_Assignment.FormulaClass f = new DipeshLama_Spreadsheet_Assignment.FormulaClass();
            List<double> values = new List<double> { 10,20 };
            double Result = f.Multiply(values);
            Assert.AreEqual(200, Result);
        }

        [TestMethod]
        public void FailTestMultiply()
        {
            DipeshLama_Spreadsheet_Assignment.FormulaClass f = new DipeshLama_Spreadsheet_Assignment.FormulaClass();
            List<double> values = new List<double> { 5, 20 };
            double Result = f.Multiply(values);
            Assert.AreEqual(200, Result);
        }
    }
}
