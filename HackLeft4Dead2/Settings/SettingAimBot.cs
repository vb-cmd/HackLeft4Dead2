using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackLeft4Dead2.Settings
{
    public class SettingAimBot
    {
        public bool TargetTank { get; set; } = true;
        public bool TargetWitch { get; set; } = true;
        public bool TargetSpitter { get; set; } = true;
        public bool TargetSmoker { get; set; } = true;
        public bool TargetBoomer { get; set; } = true;
        public bool TargetJockey { get; set; } = true;
        public bool TargetCharger { get; set; } = true;
        public bool TargetHunter { get; set; } = true;
        public bool TargetInfected { get; set; } = true;
    }
}
