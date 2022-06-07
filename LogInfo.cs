using System;

namespace Lab_1_Sensors
{
    internal class LogInfo
    {
        internal int SensorId { get; set; }
        internal int Time { get; set; }
        internal double SensorValue { get; set; }
        internal double SensorMinValue { get; set; }
        internal double SensorMaxValue { get; set; }
        internal double SensorCriticalValue { get; set; }
        
        internal LogInfo(int sensorId, int time, double sensorValue, double sensorMinValue, double sensorMaxValue, double sensorCriticalValue)
        {
            SensorId = sensorId;
            Time = time;
            SensorValue = sensorValue;
            SensorMinValue = sensorMinValue;
            SensorMaxValue = sensorMaxValue;
            SensorCriticalValue = sensorCriticalValue;
        }

        internal void PrintLogInfo()
        {
            if(SensorValue < SensorMinValue - SensorCriticalValue || SensorValue > SensorMaxValue + SensorCriticalValue)
                Console.WriteLine($"Sensor number {SensorId} at time {Time} ms had a critical value of {SensorValue}, when the standard is between {SensorMinValue}-{SensorCriticalValue} and {SensorMaxValue}+{SensorCriticalValue}. Please, check the sensor.");
            else
                Console.WriteLine($"Sensor number {SensorId} at time {Time} ms had a value of {SensorValue}, when the standard is between {SensorMinValue}-{SensorCriticalValue} and {SensorMaxValue}+{SensorCriticalValue}.");
        }
    }
}
