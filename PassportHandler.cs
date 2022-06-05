using System.Collections.Generic;
using System.Threading;

namespace Lab_1_Sensors
{
    internal class PassportHandler
    {
        private bool[][] _passportDescriptions;
        private double[] _upperValues;
        private double[] _lowerValues;
        private double[] _criticalValues;
        private double[][] _currentValues;
        private Characteristic[] _characteristics;

        internal PassportHandler()
        {
            _characteristics = CharacteristicCreator.CreateCharacteristics();
            _passportDescriptions = InputValuesGenerator.GeneratePassportDescriptions();
            _upperValues = InputValuesGenerator.GenerateUpperValues();
            _lowerValues = InputValuesGenerator.GenerateLowerValues();
            _criticalValues = InputValuesGenerator.GenerateCriticalValues();
            _currentValues = InputValuesGenerator.GenerateEmptyCurrentValues(_passportDescriptions);
        }

        internal void CyclicalMethod()
        {
            int currentSensor = 0;
            int time = 0;
            List<LogInfo> logInfoList = new List<LogInfo>();
            while (currentSensor < GlobalConsts.NumberOfSensors)
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
                LogInfo newLog = new LogInfo(sensorId, time, sensorValue, _lowerValues[sensorId], _upperValues[sensorId]);
                logInfoList.Add(newLog);
                if (sensorValue > _upperValues[sensorId] + _criticalValues[sensorId])
                {
                    newLog.PrintCriticalLogInfo();
                }
            }
            else if (sensorValue < _lowerValues[sensorId])
            {
                LogInfo newLog = new LogInfo(sensorId, time, sensorValue, _lowerValues[sensorId], _upperValues[sensorId]);
                logInfoList.Add(newLog);
                if (sensorValue < _lowerValues[sensorId] - _criticalValues[sensorId])
                {
                    newLog.PrintCriticalLogInfo();
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
