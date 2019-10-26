namespace BerlinClock.Classes.Lamps
{
    abstract class Lamp : ILamp
    {
        public bool Enabled { get; private set; }

        public void Off()
        {
            Enabled = false;
        }

        public void On()
        {
            Enabled = true;
        }
    }
}
