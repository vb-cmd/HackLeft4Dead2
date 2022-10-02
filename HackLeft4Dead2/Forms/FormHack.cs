using HackLeft4Dead2.Data;
using HackLeft4Dead2.Features;
using System.Threading;

namespace HackLeft4Dead2
{
    public partial class FormHack : Form
    {
#nullable disable
        private GameWindow gameWindow;
        private GameProcess gameProcess;
        private DataEntities dataEntities;
        private BunnyHop bunnyHop;

        private ThreadBase[] threads;

        private FPS fps;
        private BorderWindow borderWindow;
        private GraphicsLine graphicsLine;
        private GraphicsRectangle graphicsRectangle;
        private GraphicsRadar graphicsRadar;
#nullable enable

        public FormHack()
        {
            InitializeComponent();
        }

        private void FormHack_Load(object sender, EventArgs e)
        {
            //create
            gameWindow = new();
            gameProcess = new();
            dataEntities = new(gameProcess, gameWindow.WindowInformation);
            bunnyHop = new(gameProcess);

            fps = new FPS();
            borderWindow = new BorderWindow();
            graphicsLine = new GraphicsLine(dataEntities);
            graphicsRectangle = new GraphicsRectangle(dataEntities);
            graphicsRadar = new(dataEntities);

            //add Graphics
            gameWindow.OverlayWindow.GraphicsCollection.AddRange(new IGraphics[] { fps, borderWindow, graphicsLine, graphicsRectangle, graphicsRadar});


            //check process
            if (gameProcess.SearchProcessAndModules() is false)
            {
                MessageBox.Show("The game process not found. Run the game.");
                Environment.Exit(0);
            }


            //add threads
            threads = new ThreadBase[] {
            gameProcess,
            dataEntities,
            bunnyHop,
            gameWindow
            };

            //start threads
            foreach (var item in threads)
                item.Start();
        }

        private void FormHack_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in threads)
            {
                item.Stop();
                item?.Dispose();
            }
        }
    }
}