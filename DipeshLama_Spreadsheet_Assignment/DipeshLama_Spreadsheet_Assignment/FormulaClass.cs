using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DipeshLama_Spreadsheet_Assignment
{
   public class FormulaClass
    {

        public double Sum_Formula(List<double> Values)
        {
            double Sum = 0;
            foreach (var v in Values)
                Sum += v;
            return Sum;
        }
        public double Median_Formula(List<double> Values)
        {
            int FirstItem = 0;     
            int SecondItem = 0;      
            double median = 0;
            if (Values.Count % 2 == 1)
            {
                FirstItem = (Values.Count + 1) / 2;
                median = Values[FirstItem - 1];
            }
            else
            {
                FirstItem = Values.Count / 2;
                SecondItem = (Values.Count / 2) + 1;
                median = (Values[FirstItem - 1] + Values[SecondItem - 1]) / 2;
            }
            return median;
        }
        public double Mean_Formula(List<double> Values)
        {
            double mean = 0;
            foreach (var v in Values)
                mean += v;
            mean = mean / Values.Count;
            return mean;
        }

        public double Average_Formula(List<double> Values)
        {
            double Avg = 0;
            foreach (var v in Values)
                Avg += v;
            Avg = Avg / Values.Count;
            return Avg;
        }

        public double Mode_Formula(List<double> values) //Mode is maximum repeated number
        {
            int mode = 0;
            var groups = values.GroupBy(x => x);
            var largest = groups.OrderByDescending(x => x.Count()).First();
            mode = Convert.ToInt32(largest.Key);
            return mode;
        }

        public double Multiply(List<double> values)
        {
            double multiply = values[0] * values[1];
            return multiply;
        }

        public List<double> SortedList(IList<double> values)
        {
            bool flag;
            double temp;
            do
            {
                flag = false;
                for (int i = 0; i < values.Count - 1; i++)
                {
                    if (values[i] > values[i + 1])
                    {
                        temp = values[i];
                        values[i] = values[i + 1];
                        values[i + 1] = temp;
                        flag = true;
                    }
                }

            } while (flag == true);
            List<double> list = values.ToList();
            return list;
        }
    }
}
