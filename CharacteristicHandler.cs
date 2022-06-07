using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lab_1_Sensors
{
    internal class CharacteristicHandler
    {
        private const int NumberOfSensors = 5;

        private bool[][] _characteristicDescriptions;
        private double[] _upperValues;
        private double[] _lowerValues;
        private double[] _criticalValues;
        private double[][] _characteristicCurrentValues;
        private Characteristic[] _characteristics;

        private List<Sensor> _sensorList = new List<Sensor>();

        internal CharacteristicHandler()
        {
            _characteristics = CharacteristicCreator.CreateCharacteristics();
            _characteristicDescriptions = InputValuesGenerator.GenerateCharacteristicDescriptions(GlobalConsts.NumberOfCharacteristics, NumberOfSensors);
            _upperValues = InputValuesGenerator.GenerateUpperValues(NumberOfSensors);
            _lowerValues = InputValuesGenerator.GenerateLowerValues(NumberOfSensors);
            _criticalValues = InputValuesGenerator.GenerateCriticalValues(NumberOfSensors);
            _characteristicCurrentValues = InputValuesGenerator.GenerateEmptyCharacteristicCurrentValues(_characteristicDescriptions, GlobalConsts.NumberOfCharacteristics);

            InitSensors();
        }

        private void InitSensors()
        {
            Sensor firstSensor = new Sensor(0, 5, 0);
            Sensor secondSensor = new Sensor(1, 3, 4);
            Sensor thirdSensor = new Sensor(2, 4, 1);
            Sensor fourthSensor = new Sensor(3, 2, 2);
            Sensor fifthSensor = new Sensor(4, 7, 3);

            _sensorList.Add(firstSensor);
            _sensorList.Add(secondSensor);
            _sensorList.Add(thirdSensor);
            _sensorList.Add(fourthSensor);
            _sensorList.Add(fifthSensor);
        }

        public void RequestSingleSensor(int sensorId)
        {
            double sensorValue = Utils.GenerateSensorValue();
            LogInfo newLog = new LogInfo(sensorId, 0, sensorValue, _lowerValues[sensorId], _upperValues[sensorId], _criticalValues[sensorId]);
            newLog.PrintLogInfo();
            SaveSensorValue(sensorId, sensorValue);
        }

        public void AddressMethod()
        {
            int seconds = 0;
            while (seconds < 100)
            {
                List<LogInfo> logInfoList = new List<LogInfo>();
                List<Sensor> currentSensors = _sensorList.Where(sensor => seconds % sensor.Period == 0)
                                                        .OrderBy(sensor => sensor.Priority)
                                                        .ToList();
                foreach (Sensor sensor in currentSensors)
                {
                    HandleSensor(sensor, seconds * 1000, logInfoList);
                }

                Console.WriteLine();
                foreach(LogInfo logInfo in logInfoList)
                {
                    logInfo.PrintLogInfo();
                }

                Thread.Sleep(1000);
                seconds++;
            }
        }

        private void HandleSensor(Sensor sensor, int time, List<LogInfo> logInfoList)
        {
            double sensorValue = Utils.GenerateSensorValue();

            LogInfo newLog = new LogInfo(sensor.Id, time, sensorValue, _lowerValues[sensor.Id], _upperValues[sensor.Id], _criticalValues[sensor.Id]);
            if (sensorValue > _upperValues[sensor.Id])
            {
                if (sensorValue > _upperValues[sensor.Id] + _criticalValues[sensor.Id])
                    newLog.PrintLogInfo();
                else
                    logInfoList.Add(newLog);
            }
            else if (sensorValue < _lowerValues[sensor.Id])
            {
                if (sensorValue < _lowerValues[sensor.Id] - _criticalValues[sensor.Id])
                    newLog.PrintLogInfo();
                else
                    logInfoList.Add(newLog);
            }

            SaveSensorValue(sensor.Id, sensorValue);
        }

        private void SaveSensorValue(int sensorId, double sensorValue)
        {
            for (int i = 0; i < GlobalConsts.NumberOfCharacteristics; i++)
            {
                if (_characteristicDescriptions[i][sensorId])
                {
                    int index = _characteristicDescriptions[i].Take(sensorId + 1).Where(c => c).Count() - 1;
                    _characteristicCurrentValues[i][index] = _characteristics[i].GetCharacteristicValue(sensorValue);
                }
            }
        }
    }
}
