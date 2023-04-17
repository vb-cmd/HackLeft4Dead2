
namespace HackLeft4Dead2.Hack
{
    public class AimBot : ThreadBase
    {
        public AimBot(DataEntities data, WindowInformation windowInformation)
        {
            Data = data;
            WindowInformation = windowInformation;
        }

        public DataEntities Data { get; }
        public WindowInformation WindowInformation { get; }

        public override void Update()
        {
           /* var height = WindowInformation.WindowRectangleClient.Height;
            var wigth = WindowInformation.WindowRectangleClient.Width;

            var topLeftPoint = new Point(wigth / 3, height / 3);
            var bottomLeftPoint = new Point(topLeftPoint.X, topLeftPoint.Y + 100);
            var topRightPoint = new Point(wigth / 2, wigth / 2);
            var bottomRightPoint = new Point(topRightPoint.X, topRightPoint.Y + 100);

            //Debug.WriteLine($"topLeftPoint:{topLeftPoint} | bottomLeftPoint:{bottomLeftPoint} | topRightPoint:{topRightPoint} | bottomRightPoint:{bottomRightPoint}");

            var entity = Data.Entities.FirstOrDefault((e) =>
            {
                var topLeftX = topLeftPoint.X > e.PositionAim.X;
                var topLeftY = topLeftPoint.Y > e.PositionAim.Y;

                var bottomLeftX = bottomLeftPoint.X < e.PositionAim.X;
                var bottomLeftY = bottomLeftPoint.Y < e.PositionAim.Y;

                var topRightX = topRightPoint.X > e.PositionAim.X;
                var topRightY = topRightPoint.Y < e.PositionAim.Y;

                var bottomRightX = bottomRightPoint.X < e.PositionAim.X;
                var bottomRightY = bottomRightPoint.Y > e.PositionAim.Y;

                return topLeftX && topLeftY 
                && bottomLeftX && bottomLeftY 
                && topRightX && topRightY 
                && bottomRightX && bottomLeftY;
            });
*/

            /* if (Mouse.IsPressedLeftButton && (entity is not null))
             {
                 Mouse.SetCursorPosition(entity.PositionAim);
             }*/

        }
    }
}
