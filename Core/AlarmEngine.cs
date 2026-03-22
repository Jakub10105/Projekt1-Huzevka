using Alarm.Models;
using Alarm.Rules;
using System.Collections.Generic;

namespace Alarm.Core
{
    public class AlarmEngine
    {
        private List<AlarmRule> _rules;

        public AlarmEngine()
        {
            _rules = new List<AlarmRule>();
        }

        public void AddRule(AlarmRule newRule)
        {
            _rules.Add(newRule);
        }

        public void Process(TelemetrySample sample)
        {
            foreach (AlarmRule rule in _rules)
            {
                rule.Evaluate(sample);
            }
        }
    }
}