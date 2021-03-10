using System;

namespace Trafics
{
    internal static class HistogramSample
    {
        // Подготовка данных для построения графиков:
        public static HistogramData GetHistogram(TraficData[] trafics)
        {
            Console.WriteLine("Статистика трафика по времени");
            var minTime = int.MaxValue;
            var maxTime = 0;
            foreach (var trafic in trafics)
            {// вычисление крайних значений времени
                minTime = Math.Min(minTime, trafic.TimeOfConnecting.Hour * 60 + trafic.TimeOfConnecting.Minute);
                maxTime = Math.Max(maxTime, trafic.TimeOfConnecting.Hour * 60 + trafic.TimeOfConnecting.Minute);
            }
            var minutes = maxTime - minTime+1; 
            var times = new string[minutes];// массив значений времени с точностью до минуты
            var traficsCounts = new double[minutes];// массив значений трафика, переданного к этой минуте
            string k;
            string tempTime;
            if (trafics[0].TimeOfConnecting.Minute < 10) k = "0";
            else k = "";
            times[0] = Convert.ToString(trafics[0].TimeOfConnecting.Hour) + ":" + k
                  + Convert.ToString(trafics[0].TimeOfConnecting.Minute);
            traficsCounts[0] = trafics[0].Trafic;
            int i = 0;
            int overallTrafic = trafics[0].Trafic; // общий трафик
            for (var y = 1; y < trafics.Length; y++)
            {//занесение значений в массивы
                overallTrafic+= trafics[y].Trafic;
                if (trafics[y].TimeOfConnecting.Minute < 10) k = "0";
                else k = "";
                tempTime = Convert.ToString(trafics[y].TimeOfConnecting.Hour) + ":" + k 
                      + Convert.ToString(trafics[y].TimeOfConnecting.Minute);
                if (tempTime != times[i]) 
                { 
                    i++;
                    times[i] = tempTime;
                    traficsCounts[i] = trafics[y].Trafic; 
                }
                else traficsCounts[i] += trafics[y].Trafic;
            }
            Console.WriteLine("Всего бит: " + Convert.ToString(overallTrafic)); //тарификация
            Console.WriteLine("По тарифу 1 руб/Кб нужно заплатить рублей: " + Convert.ToString(overallTrafic/Math.Pow(2, 13)));
            Console.WriteLine("По тарифу 1 руб/Мб нужно заплатить рублей: " + Convert.ToString(overallTrafic / Math.Pow(2, 23)));
            return new HistogramData("Статистика трафика по времени", times, traficsCounts);
        }
    }
}