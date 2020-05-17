using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace IBL.Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a new chart.
            ChartControl pointChart = new ChartControl();

            // Create a point series.
            Series series1 = new Series("Series 1", ViewType.Point);

            // Set the numerical argument scale type for the series,
            // as it is qualitative, by default.
            series1.ArgumentScaleType = ScaleType.Numerical;

            // Add points to it.
            series1.Points.Add(new SeriesPoint(1, 10));
            series1.Points.Add(new SeriesPoint(2, 22));
            series1.Points.Add(new SeriesPoint(3, 14));
            series1.Points.Add(new SeriesPoint(4, 27));
            series1.Points.Add(new SeriesPoint(5, 15));
            series1.Points.Add(new SeriesPoint(6, 28));
            series1.Points.Add(new SeriesPoint(7, 15));
            series1.Points.Add(new SeriesPoint(8, 33));

            // Add the series to the chart.
            pointChart.Series.Add(series1);

            // Access the view-type-specific options of the series.
            PointSeriesView myView1 = (PointSeriesView)series1.View;
            myView1.PointMarkerOptions.Kind = MarkerKind.Star;
            myView1.PointMarkerOptions.StarPointCount = 5;
            myView1.PointMarkerOptions.Size = 20;

            // Access the type-specific options of the diagram.
            ((XYDiagram)pointChart.Diagram).EnableAxisXZooming = true;

            // Hide the legend (if necessary).
            pointChart.Legend.Visible = false;

            // Add a title to the chart (if necessary).
            pointChart.Titles.Add(new ChartTitle());
            pointChart.Titles[0].Text = "A Point Chart";

            // Add the chart to the form.
            pointChart.Dock = DockStyle.Fill;
            this.Controls.Add(pointChart);
        }
    }
}
