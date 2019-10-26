using BerlinClock.Classes.Lamps;

namespace BerlinClock.Classes.Mappers
{
    interface ILampToStringMapper
    {
        string Map(ILamp lamp);
    }
}
