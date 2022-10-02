using HackLeft4Dead2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackLeft4Dead2.Features
{
    public class GraphicsRadar : IGraphics
    {
        private readonly Pen enemy;
        private readonly Pen team;
        private readonly Font font;
        private Brush rectangleBoxBrush;
        private readonly Rectangle rectangleBox;

        private readonly DataEntities data;
        public GraphicsRadar(DataEntities data)
        {
            this.enemy = new Pen(Color.Red, 1);
            this.team = new Pen(Color.Green, 1);
            this.font = new("Arial", 7);
            this.rectangleBox = new(0, 0, 300, 300);
            this.rectangleBoxBrush = Brushes.Chocolate;
            this.data = data;
        }

        public void Render(PaintEventArgs e)
        {
            DrawBox(e);

            var entityPlayer = data.Entities[0];

            //DrawArrow(e, 10, (LocalAndSizeBox.Width - 10) / 2, (LocalAndSizeBox.Height - 10) / 2, 100);

            for (int i = 1; i < data.Entities.Length; i++)
            {
                var entity = data.Entities[i];

                if (e.ClipRectangle.Width != 0 || e.ClipRectangle.Height != 0)
                {
                    //draw enetity
                    if (entity.Team == Team.BossZombie)
                    {
                        DrawEntity(e, entity, entityPlayer, enemy);
                    }
                    else if (entity.Team == Team.Survivors)
                    {
                        DrawEntity(e, entity, entityPlayer, team);
                    }
                }
            }
        }

        private void DrawBox(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.FillRectangle(rectangleBoxBrush, rectangleBox);
        }

        private void DrawEntity(PaintEventArgs e, Entity entity, Entity player, Pen pen)
        {
            int Cal(int LocalPlayer, int Entity, int size)
            {
                // Radar Info
                float RadarX = (LocalPlayer - Entity) * 0.1f;
                RadarX += size / 2;
                return (int)RadarX;
            }

            var x = Cal((int)player.PositionRadar.X, (int)entity.PositionRadar.X, rectangleBox.Width);
            var y = Cal((int)player.PositionRadar.Y, (int)entity.PositionRadar.Y, rectangleBox.Height);


            if (x < rectangleBox.Width && y < rectangleBox.Width && x > 0 && y > 0)
            {
                Rectangle rectagle = new(x, y, 5, 5);

                //draw reactagle with background
                e.Graphics.DrawRectangle(pen, rectagle);
                e.Graphics.FillRectangle(pen.Brush, rectagle);

                //draw line from entity to player
                e.Graphics.DrawLine(pen, x, y, rectangleBox.Width / 2, rectangleBox.Height / 2);

                //draw information about entity
                string value = $"#{entity.Id} H:{entity.Health}";
                e.Graphics.DrawString(value, font, pen.Brush, rectagle.X + 5, rectagle.Y);
            }
        }

        private void DrawArrow(PaintEventArgs e, int square, int x, int y, float angle)
        {
            var g = e.Graphics;
            var points = new Point[]
            {
                new Point((x+(square/2)), y),
                new Point(x, (y+square)),
                new Point((x+square), (y+square))
            };

            Point center = new(
            (points.Max(x => x.X) + points.Min(x => x.X)) / 2,
            (points.Max(x => x.Y) + points.Min(x => x.Y)) / 2);


            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(angle);
            g.TranslateTransform(-center.X, -center.Y);
            g.FillPolygon(Brushes.OrangeRed, points);

            g.ResetTransform();
        }
    }
}
