using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DipeshLama_Spreadsheet_Assignment
{
    public partial class FormChart : Form
    {
        string[] chars;
        int[] values;
        public FormChart(string[] chars, int[] values)
        {
            this.chars = chars;
            this.values = values;
            InitializeComponent();
        }

        public void Barchart()
        {

            chart1.Series.Clear();

          
            string[] seriesArray = chars; 
            int[] pointsArray = values;

          
            chart1.Palette = ChartColorPalette.EarthTones;

          
            chart1.Titles.Add("Spread Sheet");

           
            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }

        }

        private void FormChart_Load(object sender, EventArgs e)
        {
            Barchart();
        }
    }
}
