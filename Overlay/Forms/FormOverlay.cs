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

            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();
            // 
            // FormOverlay
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Gray;
            this.ClientSize = new Size(27, 31);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "FormOverlay";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "FormOverlay";
            this.TransparencyKey = Color.Gray;
            this.Load += new EventHandler(this.FormOverlay_Load);
            this.ResumeLayout(false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //render all graphics
            this.graphicsCollection.ForEach(g => g.Render(e));

            base.OnPaint(e);
        }

        public void UpdateGraphics()
        {
            //update the window
            this.HookWindowUpdate();
            //Refresh the window.
            this.Refresh();
        }

        private void FormOverlay_Load(object sender, EventArgs e)
        {
            //https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-reduce-graphics-flicker-with-double-buffering-for-forms-and-controls?view=netframeworkdesktop-4.8
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            this.WindowTransparent();
        }

        /// <summary>
        /// Update the window when the game window has changed size.
        /// </summary>
        private void HookWindowUpdate()
        {
            //update information the window
            windowInformation.UpdateWindow();

            if (windowInformation.ForegroundWindow)
            {
                var rect = windowInformation.WindowRectangleClient;
                this.Size = rect.Size;
                this.Top = rect.Top;
                this.Left = rect.Left;
                this.WindowState = FormWindowState.Normal;
                this.TopMost = true;
            }
            else
            {
                this.Size = Size.Empty;
                this.Top = 0;
                this.Left = 0;

                this.WindowState = FormWindowState.Minimized;
            }
        }

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}