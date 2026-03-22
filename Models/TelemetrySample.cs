namespace Alarm.Models



{
    public class TelemetrySample
    {
        public DateTime Timestamp { get; set; }

        public string? MachineId { get; set; }

        public double Temperature { get; set; }

        public double Vibration { get; set; }

        public double Current { get; set; }

    }
}