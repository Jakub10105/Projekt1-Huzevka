using Alarm.Models;
using System;

namespace Alarm.Rules
{
    public abstract class AlarmRule
    {
        public event EventHandler<AlarmEventArgs>? OnAlarmDetected;

        public abstract void Evaluate(TelemetrySample sample);

        protected void RaiseAlarm(string message, TelemetrySample sample)
        {
            if (OnAlarmDetected != null)
            {
                AlarmEventArgs args = new AlarmEventArgs(message, sample);
                OnAlarmDetected(this, args);
            }
        }
    }
}