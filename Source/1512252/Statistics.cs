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

namespace _1512252
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            DataPoint p;
            InitializeComponent();
            if (Stats.filename.Count == 0)
            {
                p = new DataPoint(0, 1);
                p.AxisLabel = "0";
                p.LegendText = "Nothing";
                chartStat.Series["Series1"].Points.Add(p);
            }
            else
            {
                int i;
                if (Stats.filename.Count > 6)
                {
                    int sum = 0;

                    for (i = 5; i < Stats.filename.Count; i++)
                        sum += Stats.frequent[i];
                    for (i = 0; i < 5; i++)
                    {
                        p = new DataPoint(0, Stats.frequent[i]);
                        p.AxisLabel = Stats.frequent[i].ToString();
                        p.LegendText = Stats.filename[i];
                        chartStat.Series["Series1"].Points.Add(p);
                    }
                    p = new DataPoint(0, sum);
                    p.AxisLabel = sum.ToString();
                    p.LegendText = "Others";
                    chartStat.Series["Series1"].Points.Add(p);
                }
                else
                {
                    for (i = 0; i < Stats.filename.Count; i++)
                    {
                        p = new DataPoint(0, Stats.frequent[i]);
                        p.AxisLabel = Stats.frequent[i].ToString();
                        p.LegendText = Stats.filename[i];
                        chartStat.Series["Series1"].Points.Add(p);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
