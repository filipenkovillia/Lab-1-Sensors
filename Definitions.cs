namespace Lab_1_Sensors
{
    public static class GlobalConsts
    {
        public const int NumberOfSensors = 10;
        public const int NumberOfCharacteristics = 10;
        public const int SensorMinValue = 10;
        public const int SensorMaxValue = 30;
        public const int PeriodMs = 2000;
    }

    public enum CharacteristicNumber
    {
        Default = 0,
        Log = 1,
        Square = 2,
        Sqrt = 3,
        Double = 4,
        Triple = 5,
        Half = 6,
        Negative = 7,
        Increment = 8,
        Decrement = 9,
        Log10 = 10
    }
}
