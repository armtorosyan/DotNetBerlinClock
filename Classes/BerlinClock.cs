using System;
using System.Text;

namespace BerlinClock
{
    public class BerlinClock
    {
        private bool TopPoint { get; }
        private int FirstHourRow { get; }
        private int SecondHourRow { get; }
        private int FirstMinuteRow { get; }
        private int SecondMinuteRow { get; }

        public BerlinClock(int hour, int minute, int second)
        {
            TopPoint = second % 2 == 0;

            FirstHourRow = hour / 5;
            SecondHourRow = hour % 5;

            FirstMinuteRow = minute / 5;
            SecondMinuteRow = minute % 5;
        }

        public string GetBerlinTime()
        {
            var berlinTime = new StringBuilder();

            berlinTime.AppendLine(TopPoint ? LampState.Yellow : LampState.Off);

            AppendToBerlinTime(berlinTime, 4, FirstHourRow, (i, c) => i < c ? LampState.Red : LampState.Off, true);

            AppendToBerlinTime(berlinTime, 4, SecondHourRow, (i, c) => i < c ? LampState.Red : LampState.Off, true);

            AppendToBerlinTime(berlinTime, 11, FirstMinuteRow, (i, c) => i < c ? (i % 3 == 2 ? LampState.Red : LampState.Yellow) : LampState.Off, true);

            AppendToBerlinTime(berlinTime, 4, SecondMinuteRow, (i, c) => i < c ? LampState.Yellow : LampState.Off, false);

            return berlinTime.ToString();
        }

        private void AppendToBerlinTime(StringBuilder strBuilder, int lampsCount, int highlightLampsCount, Func<int, int, string> func, bool appendLine)
        {
            for (int i = 0; i < lampsCount; i++)
            {
                strBuilder.Append(func(i, highlightLampsCount));
            }

            if (appendLine)
            {
                strBuilder.AppendLine();
            }
        }
    }
}