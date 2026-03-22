using System;

namespace Alarm.Models
{
    public class AlarmEventArgs : EventArgs
    {
        public string Message { get; set; }      
        public TelemetrySample Sample { get; set; } 

        public AlarmEventArgs(string message, TelemetrySample sample)
        {
            Message = message;
            Sample = sample;
        }
    }
}