using System.Collections.Generic;
using System.Threading;

namespace Lab_1_Sensors
{
    internal class PassportHandler
    {
        private const int NumberOfSensors = 10;

        private bool[][] _passportDescriptions;
        private double[] _upperValues;
        private double[] _lowerValues;
        private double[] _criticalValues;
        private double[][] _currentValues;
        private Characteristic[] _characteristics;

        internal PassportHandler()
        {
            _characteristics = CharacteristicCreator.CreateCharacteristics();
            _passportDescriptions = InputValuesGenerator.GeneratePassportDescriptions(NumberOfSensors, GlobalConsts.NumberOfCharacteristics);
            _upperValues = InputValuesGenerator.GenerateUpperValues(NumberOfSensors);
            _lowerValues = InputValuesGenerator.GenerateLowerValues(NumberOfSensors);
            _criticalValues = InputValuesGenerator.GenerateCriticalValues(NumberOfSensors);
            _currentValues = InputValuesGenerator.GenerateEmptyCurrentValues(_passportDescriptions, NumberOfSensors);
        }

        internal void CyclicalMethod()
        {
            int currentSensor = 0;
            int time = 0;
            List<LogInfo> logInfoList = new List<LogInfo>();
            while (currentSensor < NumberOfSensors)
            {
                HandleSensor(currentSensor, time, logInfoList);
                currentSensor++;
                time += GlobalConsts.PeriodMs;
                Thread.Sleep(GlobalConsts.PeriodMs);
            }

            foreach (LogInfo item in logInfoList)
            {
                item.PrintLogInfo();
            }
        }

        private void HandleSensor(int sensorId, int time, List<LogInfo> logInfoList)
        {
            double sensorValue = Utils.GenerateSensorValue();

            if (sensorValue > _upperValues[sensorId])
            {
                LogInfo newLog = new LogInfo(sensorId, time, sensorValue, _lowerValues[sensorId], _upperValues[sensorId], _criticalValues[sensorId]);
                logInfoList.Add(newLog);
                if (sensorValue > _upperValues[sensorId] + _criticalValues[sensorId])
                {
                    newLog.PrintLogInfo();
                }
            }
            else if (sensorValue < _lowerValues[sensorId])
            {
                LogInfo newLog = new LogInfo(sensorId, time, sensorValue, _lowerValues[sensorId], _upperValues[sensorId], _criticalValues[sensorId]);
                logInfoList.Add(newLog);
                if (sensorValue < _lowerValues[sensorId] - _criticalValues[sensorId])
                {
                    newLog.PrintLogInfo();
                }
            }

            int charCount = 0;
            for (int i = 0; i < GlobalConsts.NumberOfCharacteristics; i++)
            {
                if (_passportDescriptions[sensorId][i])
                {
                    _currentValues[sensorId][charCount] = _characteristics[i].GetCharacteristicValue(sensorValue);
                    charCount++;
                }
            }
        }
    }
}
