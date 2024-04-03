using Overlay;
using Overlay.Extension;

namespace Overlay.Forms
{
    internal class FormOverlay : Form
    {
        private readonly List<IGraphics> graphicsCollection;
        private readonly WindowInformation windowInformation;
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public FormOverlay(List<IGraphics> graphicsCollection, WindowInformation windowInformation)
        {
            this.windowInformation = windowInformation;
            this.graphicsCollection = graphicsCollection;

            components = new System.ComponentModel.Container();
            SuspendLayout();
            // 
            // FormOverlay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(27, 31);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormOverlay";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormOverlay";
            TransparencyKey = Color.Gray;
            Load += new EventHandler(FormOverlay_Load);
            ResumeLayout(false);
            ShowInTaskbar = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //render all graphics
            graphicsCollection.ForEach(g => g.Render(e));

            base.OnPaint(e);
        }

        public void UpdateGraphics()
        {
            //update the window
            HookWindowUpdate();
            //Refresh the window.
            Refresh();
        }

        private void FormOverlay_Load(object sender, EventArgs e)
        {
            //https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-reduce-graphics-flicker-with-double-buffering-for-forms-and-controls?view=netframeworkdesktop-4.8
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.WindowTransparent();
        }

        /// <summary>
        /// Update the window when the game window has changed size.
        /// </summary>
        private void HookWindowUpdate()
        {
            //update information the window
            windowInformation.UpdateWindow();

            if (windowInformation.IsValid)
            {
                var rect = windowInformation.WindowRectangleClient;

                Size = rect.Size;
                Top = rect.Top;
                Left = rect.Left;
                TopMost = true;
                WindowState = FormWindowState.Normal;
            }
            else
            {
                Size = Size.Empty;
                Top = 0;
                Left = 0;
                TopMost = false;
            }
        }

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
