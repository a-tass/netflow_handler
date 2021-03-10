using System;
using System.Globalization;

namespace Trafics
{
    public class TraficData
    {//описание класса TraficData
        public DateTime TimeOfConnecting;

        public int Trafic;

        public TraficData(int year, int month, int day, int hour, int minute, int second, int trafic)
            : this(new DateTime(year, month, day, hour, minute, second), trafic)
        {
        }

        public TraficData(DateTime timeOfConnecting, int trafic)
        {
            TimeOfConnecting = timeOfConnecting;
            Trafic = trafic;
        }

        public static TraficData ParseFrom(string textLine)
        {//парсинг строки, извлечение данных о времени и трафике
            var parts = textLine.Split(',');
            const string format = "yyyy-MM-dd HH:mm:ss";
            var date = DateTime.ParseExact(parts[1], format, CultureInfo.InvariantCulture);
            return new TraficData(date, Convert.ToInt32(parts[12]));
        }
    }
}