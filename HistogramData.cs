namespace Trafics
{
    public class HistogramData
    {{//�������� ������ �����������
        public HistogramData(string title, string[] xLabels, double[] yValues)
        {
            Title = title;
            XLabels = xLabels;
            YValues = yValues;
        }
        public string Title { get; }
        public string[] XLabels { get; }
        public double[] YValues { get; }
    }
}