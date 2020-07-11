using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DipeshLama_Spreadsheet_Assignment
{
    public partial class Form1 : Form
    {
        string FinalValue = "";
        List<string> formulasList = new List<string>();
        int colIndex = -1;
        int rowIndex = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.ColumnCount = 26;
            dataGridView1.RowCount = 26;
            dataGridView1.RowHeadersWidth = 50;

            for (int i = 0; i < 26; i++)
            {

                dataGridView1.Columns[i].Name = Convert.ToString(Convert.ToChar(i + 'A'));
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
       {
   MessageBox.Show("FUNCTION FORMULA\n\n" + "  SUM =SUM\n" + "  MEAN =MEAN\n" + "  MEDIAN =MEDIAN\n" + "  MODE  =MODE");
       }



        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dv = (DataGridView)sender;
            string ValueInCell = Convert.ToString(dv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            if (formulasList.Count > 0)
            {
                if (ValueInCell.StartsWith("=") || ValueInCell.Contains("*"))
                {
                    ValueInCell = Convert.ToString(dataGridView1.CurrentCell.Value);
                    FinalValue = "";

                }
                else
                    ValueInCell = FinalValue;
            }
            ExcelOperation eo = new ExcelOperation();
            try
            {
                if (ValueInCell.StartsWith("="))
                {
                    if (FinalValue == "")
                    {
                        rowIndex = e.RowIndex;
                        colIndex = e.ColumnIndex;
                        FinalValue = ValueInCell;
                    }

                    try
                    {
                        if (ValueInCell.Contains("*"))
                        {
                            List<double> MultiplyValues = new List<double>();
                            char Column1 = Convert.ToChar(ValueInCell.Substring(ValueInCell.IndexOf('=') + 1, 1).ToUpper());
                            Char Column2 = Convert.ToChar(ValueInCell.Substring(ValueInCell.IndexOf('*') + 1, 1).ToUpper());
                            string LowerValue = ValueInCell.Substring(1, ValueInCell.IndexOf('*') - 1);
                            int Row1 = Convert.ToInt32(LowerValue.Substring(1));
                            int Row2 = Convert.ToInt32(ValueInCell.Substring(ValueInCell.IndexOf('*') + 2));
                            MultiplyValues.Add(Convert.ToDouble(dataGridView1.Rows[Row1 - 1].Cells[Column1.ToString()].Value));
                            MultiplyValues.Add(Convert.ToDouble(dataGridView1.Rows[Row2 - 1].Cells[Column2.ToString()].Value));
                            dv.Rows[rowIndex].Cells[colIndex].Value = eo.FunctionOperation("*", MultiplyValues);

                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if (ValueInCell.Contains(":"))
                    {
                        string KeyOperation = ValueInCell.Substring(1, (ValueInCell.IndexOf(' ') - ValueInCell.IndexOf('=')) - 1);
                        string FirstValue = ValueInCell.Substring(ValueInCell.IndexOf(' ') + 1, (ValueInCell.IndexOf(':') - ValueInCell.IndexOf(' ')) - 1);
                        string LastValue = ValueInCell.Substring(ValueInCell.IndexOf(':') + 1, (ValueInCell.Length - 1) - ValueInCell.IndexOf(':'));
                        char FirstLetter = Convert.ToChar(FirstValue.Substring(0, 1));
                        char LastLetter = Convert.ToChar(LastValue.Substring(0, 1));
                        string FirstNumber = FirstValue.Length < 3 ? FirstValue.Substring(1, 1) : FirstValue.Substring(1, 2);
                        string LastNumber = LastValue.Length < 3 ? LastValue.Substring(1, 1) : LastValue.Substring(1, 2);
                        List<double> values = new List<double>();
                        try
                        {
                            if (FirstLetter == LastLetter)
                            {


                                for (int row = Convert.ToInt32(FirstNumber); row <= Convert.ToInt32(LastNumber); row++)
                                {
                                    values.Add(Convert.ToDouble(dv.Rows[row - 1].Cells[e.ColumnIndex].Value));

                                }


                                dv.Rows[rowIndex].Cells[colIndex].Value = new ExcelOperation().FunctionOperation(KeyOperation, values);
                            }
                            else if (FirstNumber == LastNumber)
                            {


                                for (char c = FirstLetter; c <= LastLetter; c++)
                                {
                                    values.Add(Convert.ToDouble(dv.Rows[e.RowIndex].Cells[c.ToString()].Value));

                                }
                                dv.Rows[rowIndex].Cells[colIndex].Value = new ExcelOperation().FunctionOperation(KeyOperation, values);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    FinalValue = ValueInCell;
                    formulasList.Add(FinalValue);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }    


        private void button2_Click(object sender, EventArgs e)
        {
            List<double> values = new List<double>();
            List<int> rowIndexes = new List<int>();
            List<int> columnIndexes = new List<int>();
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                var value = dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value;
                values.Add(Convert.ToDouble(value));
                rowIndexes.Add(cell.RowIndex);
                columnIndexes.Add(cell.ColumnIndex);
            }

            ArrayList chars = new ArrayList();
            List<double> uniqueValues = new List<double>();

            int IndexValue = 0;
            foreach (int s in columnIndexes)
            {
                int charIndex = 0;
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    if (charIndex == s)
                    {
                        if (!chars.Contains(c))
                        {
                            uniqueValues.Add(values[IndexValue]);
                            chars.Add(c);
                        }
                        else
                        {
                            uniqueValues[chars.IndexOf(c)] += values[IndexValue];
                        }
                    }
                    charIndex++;

                }
                IndexValue++;

            }
            string[] letters = new string[chars.Count];
            int index = 0;
            foreach (char c in chars)
            {
                letters[index] = c.ToString();
                index++;
            }

            int[] dataValues = new int[uniqueValues.Count];
            int arrIndex = 0;
            foreach (int val in uniqueValues)
            {
                dataValues[arrIndex] = val;
                arrIndex++;
            }

                FormChart fc = new FormChart(letters, dataValues);
            fc.Show();
        }
    }
}
