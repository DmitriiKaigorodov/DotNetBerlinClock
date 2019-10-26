namespace BerlinClock.Classes.Clocks
{
    interface IClock
    {
        void SetTime(string time);

        string GetTime();
    }
}
