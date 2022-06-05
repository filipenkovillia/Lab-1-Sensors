using System;

namespace Lab_1_Sensors
{
    internal class Characteristic
    {
        private CharacteristicNumber _number;
        private Func<double, double> _mainFunction;

        internal Characteristic(CharacteristicNumber number, Func<double, double> func)
        {
            _number = number;
            _mainFunction = func;
        }

        internal double GetCharacteristicValue(double value)
        {
            return _mainFunction(value);
        }
    }
}
