using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HackLeft4Dead2.Extension
{
    public static class MathExtension
    {
        public static Point WorldOfScreen(Matrix4x4 matrix, Vector3 vector, Size sizeScreen)
        {
            var vector4 = new Vector4
            {
                X = (matrix.M11 * vector.X) + (matrix.M12 * vector.Y) + (matrix.M13 * vector.Z) + matrix.M14,
                Y = (matrix.M21 * vector.X) + (matrix.M22 * vector.Y) + (matrix.M23 * vector.Z) + matrix.M24,
                Z = (matrix.M31 * vector.X) + (matrix.M32 * vector.Y) + (matrix.M33 * vector.Z) + matrix.M34,
                W = (matrix.M41 * vector.X) + (matrix.M42 * vector.Y) + (matrix.M43 * vector.Z) + matrix.M44
            };

            if (vector4.W < 0.1f) return Point.Empty;


            var vector3 = new Vector3
            {
                X = vector4.X / vector4.W,
                Y = vector4.Y / vector4.W,
                Z = vector4.Z / vector4.W
            };


            var point = new Point
            {
                X = (int)((sizeScreen.Width / 2 * vector3.X) + (vector3.X + sizeScreen.Width / 2)),
                Y = (int)((sizeScreen.Height / 2 * vector3.Y) + (vector3.Y + sizeScreen.Height / 2))
            };

            return point;
        }
    }
}
