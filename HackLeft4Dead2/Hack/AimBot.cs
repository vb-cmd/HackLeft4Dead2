using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackLeft4Dead2.Hack
{
    public class AimBot : ThreadBase
    {
        private readonly DataEntities data;
        private readonly WindowInformation window;

        public AimBot(DataEntities data, WindowInformation window)
        {
            this.data = data;
            this.window = window;
        }

        public override void Update()
        {
            if (Mouse.IsPressedLeftButton)
            {
                var position = data.Entities
                   .Where(a => a.IsAlive 
                   && a.ClassId == ClassID.Smoker 
                   || a.ClassId == ClassID.Charger 
                   || a.ClassId == ClassID.Jockey 
                   || a.ClassId == ClassID.Witch 
                   || a.ClassId == ClassID.Tank 
                   || a.ClassId == ClassID.Infected
                   || a.ClassId == ClassID.Boomer
                   || a.ClassId == ClassID.Hunter
                   || a.ClassId == ClassID.Spitter)
                   .MinBy(a => a.PositionAim.Y+ a.PositionAim.X);

                if (position is not null)
                {
                    if (window.IsValid)
                    {
                        Mouse.SetCursorPosition(position.PositionAim.X, position.PositionAim.Y);
                    }
                }
            }
        }
    }
}
