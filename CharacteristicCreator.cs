using System;

namespace Lab_1_Sensors
{
    internal static class CharacteristicCreator
    {
        public static Characteristic[] CreateCharacteristics()
        {
            Characteristic[] result = new Characteristic[GlobalConsts.NumberOfCharacteristics];

            Characteristic defaultChar = new Characteristic(CharacteristicNumber.Default, DefaultValue);
            Characteristic logChar = new Characteristic(CharacteristicNumber.Log, Log);
            Characteristic squareChar = new Characteristic(CharacteristicNumber.Square, Square);
            Characteristic sqrtChar = new Characteristic(CharacteristicNumber.Sqrt, Sqrt);
            Characteristic doubleChar = new Characteristic(CharacteristicNumber.Double, Double);
            Characteristic tripleChar = new Characteristic(CharacteristicNumber.Triple, Triple);
            Characteristic halfChar = new Characteristic(CharacteristicNumber.Half, Half);
            Characteristic negativeChar = new Characteristic(CharacteristicNumber.Negative, Negative);
            Characteristic incrementChar = new Characteristic(CharacteristicNumber.Increment, Increment);
            Characteristic decrementChar = new Characteristic(CharacteristicNumber.Decrement, Decrement);
            Characteristic log10Char = new Characteristic(CharacteristicNumber.Log10, Log10);

            result[(int)CharacteristicNumber.Default] = defaultChar;
            result[(int)CharacteristicNumber.Log] = logChar;
            result[(int)CharacteristicNumber.Square] = squareChar;
            result[(int)CharacteristicNumber.Sqrt] = sqrtChar;
            result[(int)CharacteristicNumber.Double] = doubleChar;
            result[(int)CharacteristicNumber.Triple] = tripleChar;
            result[(int)CharacteristicNumber.Half] = halfChar;
            result[(int)CharacteristicNumber.Negative] = negativeChar;
            result[(int)CharacteristicNumber.Increment] = incrementChar;
            result[(int)CharacteristicNumber.Decrement] = decrementChar;

            return result;
        }

        private static double DefaultValue(double value)
        {
            return value;
        }

        private static double Log(double value)
        {
            return Math.Log(value);
        }

        private static double Square(double value)
        {
            return value * value;
        }

        private static double Sqrt(double value)
        {
            return Math.Sqrt(value);
        }

        private static double Double(double value)
        {
            return 2 * value;
        }

        private static double Triple(double value)
        {
            return 3 * value;
        }

        private static double Half(double value)
        {
            return value / 2.0;
        }

        private static double Negative(double value)
        {
            return -value;
        }

        private static double Increment(double value)
        {
            return value++;
        }

        private static double Decrement(double value)
        {
            return value--;
        }

        private static double Log10(double value)
        {
            return Math.Log10(value);
        }
    }
}
