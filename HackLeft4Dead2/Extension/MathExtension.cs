namespace HackLeft4Dead2.Extension
{
    public static class MathExtension
    {
        public static Point WorldOfScreen(this Matrix4x4 viewMatrix, Vector3 point3D, Size screenSize)
        {
            Point returnVector = Point.Empty;
            float w = viewMatrix.M31 * point3D.X + viewMatrix.M32 * point3D.Y + viewMatrix.M33 * point3D.Z + viewMatrix.M34;
            if (w >= 0.01f)
            {
                float inverseX = 1f / w;
                returnVector.X =
                   (int)((screenSize.Width / 2f) +
                    (0.5f * (
                    (viewMatrix.M11 * point3D.X + viewMatrix.M12 * point3D.Y + viewMatrix.M13 * point3D.Z + viewMatrix.M14)
                    * inverseX)
                    * screenSize.Width + 0.5f));
                returnVector.Y =
                    (int)((screenSize.Height / 2f) -
                    (0.5f * (
                    (viewMatrix.M21 * point3D.X + viewMatrix.M22 * point3D.Y + viewMatrix.M23 * point3D.Z + viewMatrix.M24)
                    * inverseX)
                    * screenSize.Height + 0.5f));
            }
            return returnVector;
        }
    }
}
