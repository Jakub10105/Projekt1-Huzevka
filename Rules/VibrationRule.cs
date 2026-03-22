using Alarm.Models;

namespace Alarm.Rules
{
    public class VibrationRule : AlarmRule
    {
        private double _limit;

        public VibrationRule(double limitValue)
        {
            _limit = limitValue;
        }

        public override void Evaluate(TelemetrySample sample)
        {
            if (sample.Vibration > _limit)
            {
                RaiseAlarm("Vibration limit exceeded!", sample);
            }
        }
    }
}