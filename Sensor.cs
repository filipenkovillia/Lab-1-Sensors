namespace Lab_1_Sensors
{
    internal class Sensor
    {
        internal int Id { get; set; }
        internal int Period { get; set; }
        internal int Priority { get; set; }

        internal Sensor(int id, int period, int priority)
        {
            Id = id;
            Period = period;
            Priority = priority;
        }
    }
}
