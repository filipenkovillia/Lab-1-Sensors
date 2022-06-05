using System;
using System.Linq;

namespace Lab_1_Sensors
{
    internal static class InputValuesGenerator
    {
        private static Random rand = new Random();

        internal static bool[][] GeneratePassportDescriptions()
        {
            bool[][] passportDescriptions = new bool[GlobalConsts.NumberOfSensors][];

            for (int i = 0; i < GlobalConsts.NumberOfSensors; i++)
            {
                passportDescriptions[i] = new bool[GlobalConsts.NumberOfCharacteristics];
                // Default characteristic is mandatory
                passportDescriptions[i][0] = true;
                for (int j = 1; j < GlobalConsts.NumberOfCharacteristics; j++)
                {
                    int boolean = rand.Next(2);
                    passportDescriptions[i][j] = boolean == 1;
                }
            }

            return passportDescriptions;
        }

        internal static double[] GenerateUpperValues()
        {
            double[] upperValues = new double[GlobalConsts.NumberOfCharacteristics];

            for (int i = 0; i < GlobalConsts.NumberOfSensors; i++)
            {
                upperValues[i] = rand.Next(GlobalConsts.SensorMinValue, GlobalConsts.SensorMaxValue + 1);
            }

            return upperValues;
        }

        internal static double[] GenerateLowerValues()
        {
            double[] lowerValues = new double[GlobalConsts.NumberOfCharacteristics];

            for (int i = 0; i < GlobalConsts.NumberOfSensors; i++)
            {
                lowerValues[i] = rand.Next(GlobalConsts.SensorMinValue);
            }

            return lowerValues;
        }

        internal static double[] GenerateCriticalValues()
        {
            double[] criticalValues = new double[GlobalConsts.NumberOfCharacteristics];

            for (int i = 0; i < GlobalConsts.NumberOfSensors; i++)
            {
                criticalValues[i] = Math.Round(rand.Next(GlobalConsts.SensorMinValue + 1) * 0.1, 1);
            }

            return criticalValues;
        }

        internal static double[][] GenerateEmptyCurrentValues(bool[][] passportDescriptions)
        {
            double[][] currentValues = new double[GlobalConsts.NumberOfCharacteristics][];

            for (int i = 0; i < GlobalConsts.NumberOfSensors; i++)
            {
                int numberOfCharacteristics = passportDescriptions[i].Count(des => des);
                currentValues[i] = new double[numberOfCharacteristics];
            }

            return currentValues;
        }
    }
}
