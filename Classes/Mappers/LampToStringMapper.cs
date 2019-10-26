using BerlinClock.Classes.Lamps;
using System;
using System.Collections.Generic;

namespace BerlinClock.Classes.Mappers
{
    class LampToStringMapper : ILampToStringMapper
    {
        private const string _disabledLampSymbol = "O";
        private const string _yellowLampSymbol = "Y";
        private const string _redLampSymbol = "R";

        private IReadOnlyDictionary<Type, string> _lampMap = new Dictionary<Type, string>
        {
            [typeof(YellowLamp)] = _yellowLampSymbol,
            [typeof(RedLamp)] = _redLampSymbol
        };

        public string Map(ILamp lamp)
        {
            if (!lamp.Enabled)
            {
                return _disabledLampSymbol;
            }

            var lampType = lamp.GetType();

            if (_lampMap.TryGetValue(lampType, out var symbol))
            {
                return symbol;
            }

            throw new ArgumentException($"Can not map lamp {lampType.Name} to string.");
        }
    }
}
