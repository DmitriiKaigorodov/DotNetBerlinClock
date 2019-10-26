using BerlinClock.Classes.Mappers;
using Clocks = BerlinClock.Classes.Clocks;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            var berlinClock = new Clocks.BerlinClock(new LampToStringMapper());
            berlinClock.SetTime(aTime);
            return berlinClock.GetTime();
        }
    }
}
