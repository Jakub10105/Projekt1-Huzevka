using Alarm.Models;
using Alarm.Rules;

namespace Alarm.Rules
{
    public class TemperatureRule : AlarmRule
    {
        private double _limit;
        public TemperatureRule(double limit) => _limit = limit;

        public override void Evaluate(TelemetrySample sample)
        {
            if (sample.Temperature > _limit)
            {
                RaiseAlarm($"Alarm High temperature on {sample.MachineId} ({sample.Temperature}°C)", sample);
            }
        }
    }
}