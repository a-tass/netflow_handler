using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace Trafics
{
    internal static class Charts
    {
        public static void ShowHistogram(HistogramData stats)
        {//построение диаграммы при помощи библиотеки ZedGraph
            var chart = new ZedGraphControl
            {
                Dock = DockStyle.Fill
            };
            chart.GraphPane.Title.Text = stats.Title;
            chart.GraphPane.XAxis.Title.Text = "X, время 25.02.2020";
            chart.GraphPane.YAxis.Title.Text = "Y, бит";
            chart.GraphPane.AddBar("", Enumerable.Range(0, stats.YValues.Length).Select(i => (double) i).ToArray(),
                stats.YValues, Color.Blue);
            chart.GraphPane.YAxis.Scale.MaxAuto = true;
            chart.GraphPane.YAxis.Scale.MinAuto = true;
            chart.GraphPane.XAxis.Type = AxisType.Text;
            chart.GraphPane.XAxis.Scale.TextLabels = stats.XLabels;

            chart.AxisChange();var form = new Form
            {
                Text = stats.Title,
                Size = new Size(800, 600)
            };
            form.Controls.Add(chart);
            form.ShowDialog();
        }
    }
}