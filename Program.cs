using Alarm.Models;
using Alarm.Rules;
using Alarm.Core;
using System;
using System.IO;
using System.Globalization; 

namespace Alarm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Monitoring started");
            
            AlarmEngine engine = new AlarmEngine();

            TemperatureRule tempRule = new TemperatureRule(70.0);
            VibrationRule vibRule = new VibrationRule(10.0);

            tempRule.OnAlarmDetected += HandleAlarm;
            vibRule.OnAlarmDetected += HandleAlarm;

            engine.AddRule(tempRule);
            engine.AddRule(vibRule);

            string filePath = "Data/telemetry.csv";

            if (File.Exists(filePath))
            {
                StreamReader reader = new StreamReader(filePath);
                reader.ReadLine(); 

                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (line != "" && line != null)
                    {
                        string[] parts = line.Split(';');

                        double temp = double.Parse(parts[2], CultureInfo.InvariantCulture);
                        double vib = double.Parse(parts[3], CultureInfo.InvariantCulture);
                        double curr = double.Parse(parts[4], CultureInfo.InvariantCulture);

                        TelemetrySample sample = new TelemetrySample();
                        sample.Timestamp = DateTime.Parse(parts[0]);
                        sample.MachineId = parts[1];
                        sample.Temperature = temp;
                        sample.Vibration = vib;
                        sample.Current = curr;

                        engine.Process(sample);
                    }
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("Error: File not found!");
            }

            Console.WriteLine("Finished - Press Enter");
            Console.ReadLine();
        }

        static void HandleAlarm(object? sender, AlarmEventArgs e)
        {
            if (e.Sample.MachineId == "M2")
            {
                Console.WriteLine("Alarm M2 time: " + e.Sample.Timestamp + " - " + e.Message);
            }
        }
    }
}