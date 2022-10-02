namespace Overlay
{
    /// <summary>
    /// Implement an interface for rendering in a window
    /// </summary>
    public interface IGraphics
    {
        /// <summary>
        /// Call method to rendering in window.
        /// </summary>
        /// <param name="e"></param>
        void Render(PaintEventArgs e);
    }
}
