using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DipeshLama_Spreadsheet_Assignment
{
  public  class ExcelOperation
    {
        public double FunctionOperation(string calculation, IList<double> values)
        {

            double result = 0;       
            FormulaClass fc = new FormulaClass();
            List<double> value = fc.SortedList(values);
            switch (calculation.ToLower())
            {
                case "sum":
                    result = fc.Sum_Formula(value);
                    break;
                case "median":
                    result = fc.Median_Formula(value);
                    break;
                case "mean":
                    result = fc.Mean_Formula(value);
                    break;

                case "mode":
                    result = fc.Mode_Formula(value);
                    break;
                case "average":
                    result = fc.Average_Formula(value);
                    break;
                case "*":
                    result = fc.Multiply(value);
                    break;
            }
            return result;

        }
    }
}
