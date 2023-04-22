namespace HackLeft4Dead2.Hack
{
    public class AimBot : ThreadBase
    {
        public SettingAimBot Setting { get; set; }
        public AimBot(Data data, WindowInformation windowInformation)
        {
            Data = data;
            WindowInformation = windowInformation;

            Setting = new SettingAimBot();
        }

        public Data Data { get; }
        public WindowInformation WindowInformation { get; }

        public override void Update()
        {
            int height = WindowInformation.WindowRectangleClient.Height;
            int width = WindowInformation.WindowRectangleClient.Width;
            var entity = Data.Entities
                .Where(e => e.IsAlive && CheckValidPositionAimOnScreen(width, height, e.PositionAim) && CheckIfTargetValid(e.ClassId))
                .MaxBy(e => e.PositionBox.Height);


            if (Mouse.IsPressedLeftButton && (entity is not null))
                Mouse.SetMouse(ConvertPositionAimForMouse(width, height, entity.PositionAim));
        }


        private bool CheckIfTargetValid(ClassID id)
        {
            if (id == ClassID.Tank && Setting.TargetTank)
            {
                return true;
            }
            else if (id == ClassID.Witch && Setting.TargetWitch)
            {
                return true;
            }
            else if (id == ClassID.Spitter && Setting.TargetSpitter)
            {
                return true;
            }
            else if (id == ClassID.Smoker && Setting.TargetSmoker)
            {
                return true;
            }
            else if (id == ClassID.Boomer && Setting.TargetBoomer)
            {
                return true;
            }
            else if (id == ClassID.Jockey && Setting.TargetJockey)
            {
                return true;
            }
            else if (id == ClassID.Charger && Setting.TargetCharger)
            {
                return true;
            }
            else if (id == ClassID.Hunter && Setting.TargetHunter)
            {
                return true;
            }
            else if (id == ClassID.Infected && Setting.TargetInfected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckValidPositionAimOnScreen(int width, int height, Point positionAim)
        {
            return positionAim.X < width && positionAim.X > 0 && positionAim.Y < height && positionAim.Y > 0;
        }

        private Point ConvertPositionAimForMouse(int width, int height, Point positionAim)
        {
            return new Point(positionAim.X - (width / 2), positionAim.Y - (height / 2));
        }
    }
}

