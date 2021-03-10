using System;
using System.IO;

namespace Trafics
{
    public static class Program
    {
        private static readonly string dataFilePath = "data.csv"; //файл с исходными данными

        private static void Main()
        {
            var traficsData = ReadData();
            Charts.ShowHistogram(HistogramSample.GetHistogram(traficsData));
            Console.WriteLine();
        }


        private static TraficData[] ReadData()
        {//функция считывания исходных данных
            var lines = File.ReadAllLines(dataFilePath);
            var trafics = new TraficData[lines.Length-4];
            for (var i = 0; i < lines.Length-4; i++)
                trafics[i] = TraficData.ParseFrom(lines[i+1]);
            return trafics;
        }
    }
}