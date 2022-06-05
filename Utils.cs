using System;

namespace Lab_1_Sensors
{
    internal static class Utils
    {
        internal static Random rand = new Random();

        internal static void OutputArray<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        internal static double GenerateSensorValue()
        {
            return Math.Round(rand.Next((GlobalConsts.SensorMaxValue + 1) * 10) * 0.1, 1);
        }
    }
}
