namespace BerlinClock.Classes.Lamps
{
    interface ILamp
    {
        bool Enabled { get; }

        void On();

        void Off();
    }
}
