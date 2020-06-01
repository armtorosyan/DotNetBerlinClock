using System;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string ConvertTime(string aTime)
        {
            ValidateTime(aTime);

            var splitTime = aTime.Split(':');

            var hour = Convert.ToInt32(splitTime[0]);
            var minute = Convert.ToInt32(splitTime[1]);
            var second = Convert.ToInt32(splitTime[2]);

            var berlinClock = new BerlinClock(hour, minute, second);

            return berlinClock.GetBerlinTime();
        }

        private void ValidateTime(string time)
        {
            var canParse = TimeSpan.TryParse(time, out var timeSpan);

            if (!canParse || 
                time.Split(':').Length != 3 || 
                timeSpan.Days != 0 && time != "24:00:00")
            {
                throw new ArgumentException("Time format is wrong!", nameof(time));
            }
        }
    }
}
