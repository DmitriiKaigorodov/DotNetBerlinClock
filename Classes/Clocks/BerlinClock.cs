using BerlinClock.Classes.Lamps;
using BerlinClock.Classes.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BerlinClock.Classes.Clocks
{
    class BerlinClock : IClock
    {
        private ILamp _secondsLamp = new YellowLamp();

        private IList<ILamp> _fiveHoursLamps = new List<ILamp>(4);

        private IList<ILamp> _oneHourLamps = new List<ILamp>(4);

        private IList<ILamp> _fiveMinutesLamps = new List<ILamp>(11);

        private IList<ILamp> _oneMinuteLamps = new List<ILamp>(4);

        private readonly ILampToStringMapper _lampToStringMapper;

        public BerlinClock(ILampToStringMapper lampToStringMapper)
        {
            _lampToStringMapper = lampToStringMapper
                            ?? throw new ArgumentNullException(nameof(lampToStringMapper));

            for (int i = 0; i < 4; i++)
            {
                _fiveHoursLamps.Add(new RedLamp());
                _oneHourLamps.Add(new RedLamp());
                _oneMinuteLamps.Add(new YellowLamp());
            }

            for (int i = 0; i < 11; i++)
            {
                var lamp = (i + 1) % 3 == 0 ? (ILamp)new RedLamp()
                    : new YellowLamp();

                _fiveMinutesLamps.Add(lamp);
            }
        }

        public void SetTime(string time)
        {
            var timeParts = time.Split(':');

            var hours = int.Parse(timeParts[0]);
            var minutes = int.Parse(timeParts[1]);
            var seconds = int.Parse(timeParts[2]);

            EnableHoursLamps(hours);
            EnableMinutesLamps(minutes);
            EnableSecondsLamp(seconds);
        }

        public string GetTime()
        {
            var timeBuilder = new StringBuilder();

            AppendSeconds(timeBuilder);
            AppendHours(timeBuilder);
            AppendMinutes(timeBuilder);

            return timeBuilder.ToString();
        }

        private void AppendSeconds(StringBuilder timeBuilder)
        {
            timeBuilder.AppendLine(_lampToStringMapper.Map(_secondsLamp));
        }

        private void AppendMinutes(StringBuilder timeBuilder)
        {
            foreach (var lamp in _fiveMinutesLamps)
            {
                timeBuilder.Append(_lampToStringMapper.Map(lamp));
            }

            timeBuilder.Append(Environment.NewLine);

            foreach (var lamp in _oneMinuteLamps)
            {
                timeBuilder.Append(_lampToStringMapper.Map(lamp));
            }
        }

        private void AppendHours(StringBuilder timeBuilder)
        {
            foreach (var lamp in _fiveHoursLamps)
            {
                timeBuilder.Append(_lampToStringMapper.Map(lamp));
            }

            timeBuilder.Append(Environment.NewLine);

            foreach (var lamp in _oneHourLamps)
            {
                timeBuilder.Append(_lampToStringMapper.Map(lamp));
            }

            timeBuilder.Append(Environment.NewLine);
        }

        private void EnableHoursLamps(int hours)
        {
            var fiveHoursLampsCount = hours / 5;
            var oneHourLampsCount = hours % 5;

            for (int i = 0; i < fiveHoursLampsCount; i++)
            {
                _fiveHoursLamps[i].On();
            }

            for (int i = 0; i < oneHourLampsCount; i++)
            {
                _oneHourLamps[i].On();
            }
        }

        private void EnableMinutesLamps(int minutes)
        {
            var fiveMinutesLampsCount = minutes / 5;
            var oneMinuteLampsCount = minutes % 5;

            for (int i = 0; i < fiveMinutesLampsCount; i++)
            {
                _fiveMinutesLamps[i].On();
            }

            for (int i = 0; i < oneMinuteLampsCount; i++)
            {
                _oneMinuteLamps[i].On();
            }
        }

        private void EnableSecondsLamp(int seconds)
        {
            if (seconds % 2 == 0)
            {
                _secondsLamp.On();
            }
        }


    }
}
