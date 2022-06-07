using System;
using System.Linq;

namespace Lab_1_Sensors
{
    internal static class InputValuesGenerator
    {
        private static Random rand = new Random();

        internal static bool[][] GeneratePassportDescriptions(int numberOfSensors, int numberOfCharacteristics)
        {
            bool[][] passportDescriptions = new bool[numberOfSensors][];

            for (int i = 0; i < numberOfSensors; i++)
            {
                passportDescriptions[i] = new bool[numberOfCharacteristics];
                // Default characteristic is mandatory
                passportDescriptions[i][0] = true;
                for (int j = 1; j < numberOfCharacteristics; j++)
                {
                    int boolean = rand.Next(2);
                    passportDescriptions[i][j] = boolean == 1;
                }
            }

            return passportDescriptions;
        }

        internal static bool[][] GenerateCharacteristicDescriptions(int numberOfCharacteristics, int numberOfSensors)
        {
            bool[][] result = new bool[numberOfCharacteristics][];

            for (int i = 0; i < numberOfCharacteristics; i++)
            {
                result[i] = new bool[numberOfSensors];
                if (i == 0)
                {
                    for(int j = 0; j < numberOfSensors; j++)
                    {
                        result[i][j] = true;
                    }
                }
                else
                {
                    for (int j = 1; j < numberOfSensors; j++)
                    {
                        int boolean = rand.Next(2);
                        result[i][j] = boolean == 1;
                    }
                }
            }

            return result;
        }

        internal static double[] GenerateUpperValues(int numberOfSensors)
        {
            double[] upperValues = new double[numberOfSensors];

            for (int i = 0; i < numberOfSensors; i++)
            {
                upperValues[i] = rand.Next(GlobalConsts.SensorMinValue, GlobalConsts.SensorMaxValue + 1);
            }

            return upperValues;
        }

        internal static double[] GenerateLowerValues(int numberOfSensors)
        {
            double[] lowerValues = new double[numberOfSensors];

            for (int i = 0; i < numberOfSensors; i++)
            {
                lowerValues[i] = rand.Next(GlobalConsts.SensorMinValue);
            }

            return lowerValues;
        }

        internal static double[] GenerateCriticalValues(int numberOfSensors)
        {
            double[] criticalValues = new double[numberOfSensors];

            for (int i = 0; i < numberOfSensors; i++)
            {
                criticalValues[i] = Math.Round(rand.Next(GlobalConsts.SensorMinValue + 1) * 0.1, 1);
            }

            return criticalValues;
        }

        internal static double[][] GenerateEmptyCurrentValues(bool[][] passportDescriptions, int numberOfSensors)
        {
            double[][] currentValues = new double[numberOfSensors][];

            for (int i = 0; i < numberOfSensors; i++)
            {
                int numberOfCharacteristics = passportDescriptions[i].Count(des => des);
                currentValues[i] = new double[numberOfCharacteristics];
            }

            return currentValues;
        }

        internal static double[][] GenerateEmptyCharacteristicCurrentValues(bool[][] passportDescriptions, int numberOfCharacteristics)
        {
            double[][] currentValues = new double[numberOfCharacteristics][];

            for (int i = 0; i < numberOfCharacteristics; i++)
            {
                int numberOfSensors = passportDescriptions[i].Count(des => des);
                currentValues[i] = new double[numberOfSensors];
            }

            return currentValues;
        }
    }
}
