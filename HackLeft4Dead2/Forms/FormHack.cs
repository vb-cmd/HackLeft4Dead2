namespace HackLeft4Dead2
{
    public partial class FormHack : Form
    {
        private GameWindow gameWindow;
        private GameProcess gameProcess;
        private DataEntities dataEntities;
        private BunnyHop bunnyHop;

        private ThreadBase[] threads;

        private GraphicsFPS fps;
        private GraphicsBorderWindow borderWindow;
        private GraphicsLineESP lineESP;
        private GraphicsBoxESP boxESP;
        private GraphicsRadar radar;

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


            fps = new GraphicsFPS();
            borderWindow = new GraphicsBorderWindow();
            lineESP = new GraphicsLineESP(dataEntities);
            boxESP = new GraphicsBoxESP(dataEntities);
            radar = new(dataEntities);

            //add Graphics
            gameWindow.OverlayWindow.GraphicsCollection.AddRange(new IGraphics[] { fps, borderWindow, lineESP, boxESP, radar });


            //check process
            if (!gameProcess.SearchProcessAndModules())
            {
                MessageBox.Show("The game process is not found. Run the game.");
                Environment.Exit(0);
            }


            //add threads
            threads = new ThreadBase[] {
            gameProcess,
            dataEntities,
            bunnyHop,
            gameWindow,
            };

            //start threads
            foreach (var item in threads)
                item.Start();

            DefaultSettingBorderWindow();
            DefaultSettingBoxESP();
            DefaultSettingBunnyHop();
            DefaultSettingFPS();
            DefaultSettingLineESP();
            DefaultSettingRadar();
        }

        private void FormHack_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in threads)
                item?.Dispose();
        }


        private bool CheckUnBox(object sender)
        {
            var check = (CheckBox)sender;
            return check.Checked;
        }

        private int NumericUpDownUnBox(object sender)
        {
            var check = (NumericUpDown)sender;
            return (int)check.Value;
        }

        private void DefaultSettingBorderWindow()
        {
            borderWindow.Setting = new();
            checkBoxBorder.Checked = borderWindow.Setting.IsVisible;
            gameWindow.WindowInformation.IsWindowHasTopPanel = false;
            checkBox38.Checked = gameWindow.WindowInformation.IsWindowHasTopPanel;
        }

        private void DefaultSettingBoxESP()
        {
            //Main other functions
            boxESP.Setting = new();
            checkBox1.Checked = boxESP.Setting.IsVisible;
            numericUpDown1.Value = boxESP.Setting.SizeObject;


            //Show Models
            checkBoxSurvivorPlayer.Checked = boxESP.Setting.IsVisibleSurvivorPlayer;
            checkBoxSurvivorBot.Checked = boxESP.Setting.IsVisibleSurvivorBot;
            checkBoxHunter.Checked = boxESP.Setting.IsVisibleHunter;
            checkBoxTank.Checked = boxESP.Setting.IsVisibleTank;
            checkBoxWitch.Checked = boxESP.Setting.IsVisibleWitch;
            checkBoxSpitter.Checked = boxESP.Setting.IsVisibleSpitter;
            checkBox9.Checked = boxESP.Setting.IsVisibleSmoker;
            checkBox8.Checked = boxESP.Setting.IsVisibleBoomer;
            checkBox11.Checked = boxESP.Setting.IsVisibleJockey;
            checkBox10.Checked = boxESP.Setting.IsVisibleCharger;
            checkBox13.Checked = boxESP.Setting.IsVisibleInfected;
            checkBox12.Checked = boxESP.Setting.IsVisibleWeaponSpawn;
            checkBox14.Checked = boxESP.Setting.IsVisibleWeaponAmmoSpawn;
        }

        private void DefaultSettingBunnyHop()
        {
            bunnyHop.IsRunning = true;
            checkBoxBunnyHop.Checked = true;
        }

        private void DefaultSettingFPS()
        {
            fps.Setting = new();
            checkBox2.Checked = fps.Setting.IsVisible;
            numericUpDown2.Value = (int)fps.Setting.Position.X;
            numericUpDown3.Value = (int)fps.Setting.Position.Y;
        }

        private void DefaultSettingLineESP()
        {
            lineESP.Setting = new();

            checkBox23.Checked = lineESP.Setting.IsVisible;

            //Show models
            checkBox22.Checked = lineESP.Setting.IsVisibleSurvivorPlayer;
            checkBox21.Checked = lineESP.Setting.IsVisibleSurvivorBot;
            checkBox20.Checked = lineESP.Setting.IsVisibleHunter;
            checkBox19.Checked = lineESP.Setting.IsVisibleTank;
            checkBox18.Checked = lineESP.Setting.IsVisibleWitch;
            checkBox17.Checked = lineESP.Setting.IsVisibleSpitter;
            checkBox16.Checked = lineESP.Setting.IsVisibleSmoker;
            checkBox15.Checked = lineESP.Setting.IsVisibleBoomer;
            checkBox7.Checked = lineESP.Setting.IsVisibleJockey;
            checkBox6.Checked = lineESP.Setting.IsVisibleCharger;
            checkBox5.Checked = lineESP.Setting.IsVisibleInfected;
            checkBox4.Checked = lineESP.Setting.IsVisibleWeaponSpawn;
            checkBox3.Checked = lineESP.Setting.IsVisibleWeaponAmmoSpawn;
        }

        private void DefaultSettingRadar()
        {
            radar.Setting = new();

            numericUpDown4.Value = radar.Setting.BoxSizeObject;
            numericUpDown5.Value = radar.Setting.BoxSizePlayer;

            numericUpDown6.Value = radar.Setting.BoxRectangle.Height;
            numericUpDown7.Value = radar.Setting.BoxRectangle.X;
            numericUpDown8.Value = radar.Setting.BoxRectangle.Y;

            //Show models
            checkBox36.Checked = radar.Setting.IsVisibleSurvivorPlayer;
            checkBox35.Checked = radar.Setting.IsVisibleSurvivorBot;
            checkBox34.Checked = radar.Setting.IsVisibleHunter;
            checkBox33.Checked = radar.Setting.IsVisibleTank;
            checkBox32.Checked = radar.Setting.IsVisibleWitch;
            checkBox31.Checked = radar.Setting.IsVisibleSpitter;
            checkBox30.Checked = radar.Setting.IsVisibleSmoker;
            checkBox29.Checked = radar.Setting.IsVisibleBoomer;
            checkBox28.Checked = radar.Setting.IsVisibleJockey;
            checkBox27.Checked = radar.Setting.IsVisibleCharger;
            checkBox26.Checked = radar.Setting.IsVisibleInfected;
            checkBox25.Checked = radar.Setting.IsVisibleWeaponSpawn;
            checkBox24.Checked = radar.Setting.IsVisibleWeaponAmmoSpawn;
        }



        #region BorderWindow
        private void checkBoxBorder_CheckedChanged(object sender, EventArgs e)
        {
            borderWindow.Setting.IsVisible = CheckUnBox(sender);
        }

        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {

            gameWindow.WindowInformation.IsWindowHasTopPanel = CheckUnBox(sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DefaultSettingBorderWindow();
        }
        #endregion

        #region Box ESP

        #region Show Model
        private void checkBoxSurvivorPlayer_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.IsVisibleSurvivorPlayer = CheckUnBox(sender);
        }

        private void checkBoxSurvivorBot_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.IsVisibleSurvivorBot = CheckUnBox(sender);
        }

        private void checkBoxHunter_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.IsVisibleHunter = CheckUnBox(sender);
        }

        private void checkBoxTank_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.IsVisibleTank = CheckUnBox(sender);
        }

        private void checkBoxWitch_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.IsVisibleWitch = CheckUnBox(sender);
        }

        private void checkBoxSpitter_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.IsVisibleSpitter = CheckUnBox(sender);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.IsVisibleSmoker = CheckUnBox(sender);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.IsVisibleBoomer = CheckUnBox(sender);
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.IsVisibleJockey = CheckUnBox(sender);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.IsVisibleCharger = CheckUnBox(sender);
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.IsVisibleInfected = CheckUnBox(sender);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.IsVisibleWeaponSpawn = CheckUnBox(sender);
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.IsVisibleWeaponAmmoSpawn = CheckUnBox(sender);
        }

        #endregion


        #region Other Functions
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.IsVisible = CheckUnBox(sender);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            boxESP.Setting.SizeObject = NumericUpDownUnBox(sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DefaultSettingBoxESP();
        }

        #endregion

        #endregion

        #region FPS
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            fps.Setting.IsVisible = CheckUnBox(sender);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            fps.Setting.Position = new PointF(NumericUpDownUnBox(sender), fps.Setting.Position.Y);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            fps.Setting.Position = new PointF(fps.Setting.Position.X, NumericUpDownUnBox(sender));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DefaultSettingFPS();
        }
        #endregion

        #region Line ESP
        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.IsVisible = CheckUnBox(sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DefaultSettingLineESP();
        }

        #region Show Models
        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.IsVisibleSurvivorPlayer = CheckUnBox(sender);
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.IsVisibleSurvivorBot = CheckUnBox(sender);
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.IsVisibleHunter = CheckUnBox(sender);
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.IsVisibleTank = CheckUnBox(sender);
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.IsVisibleWitch = CheckUnBox(sender);
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.IsVisibleSpitter = CheckUnBox(sender);
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.IsVisibleSmoker = CheckUnBox(sender);
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.IsVisibleBoomer = CheckUnBox(sender);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.IsVisibleJockey = CheckUnBox(sender);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.IsVisibleCharger = CheckUnBox(sender);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.IsVisibleInfected = CheckUnBox(sender);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.IsVisibleWeaponSpawn = CheckUnBox(sender);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.IsVisibleWeaponAmmoSpawn = CheckUnBox(sender);
        }
        #endregion


        #endregion

        #region Radar

        #region Other Functions
        private void checkBox37_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.IsVisible = CheckUnBox(sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DefaultSettingRadar();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            radar.Setting.BoxSizeObject = NumericUpDownUnBox(sender);
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            radar.Setting.BoxSizePlayer = NumericUpDownUnBox(sender);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            int height = NumericUpDownUnBox(sender);
            int width = height;
            int x = radar.Setting.BoxRectangle.X;
            int y = radar.Setting.BoxRectangle.Y;
            radar.Setting.BoxRectangle = new Rectangle(x, y, width, height);
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            int height = radar.Setting.BoxRectangle.Height;
            int width = radar.Setting.BoxRectangle.Width;
            int x = NumericUpDownUnBox(sender);
            int y = radar.Setting.BoxRectangle.Y;
            radar.Setting.BoxRectangle = new Rectangle(x, y, width, height);
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            int height = radar.Setting.BoxRectangle.Height;
            int width = radar.Setting.BoxRectangle.Width;
            int x = radar.Setting.BoxRectangle.X;
            int y = NumericUpDownUnBox(sender);
            radar.Setting.BoxRectangle = new Rectangle(x, y, width, height);
        }
        #endregion

        #region Show Models
        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.IsVisibleSurvivorPlayer = CheckUnBox(sender);
        }

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.IsVisibleSurvivorBot = CheckUnBox(sender);
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.IsVisibleHunter = CheckUnBox(sender);
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.IsVisibleTank = CheckUnBox(sender);
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.IsVisibleWitch = CheckUnBox(sender);
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.IsVisibleSpitter = CheckUnBox(sender);
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.IsVisibleSmoker = CheckUnBox(sender);
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.IsVisibleBoomer = CheckUnBox(sender);
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.IsVisibleJockey = CheckUnBox(sender);
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.IsVisibleCharger = CheckUnBox(sender);
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.IsVisibleInfected = CheckUnBox(sender);
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.IsVisibleWeaponSpawn = CheckUnBox(sender);
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.IsVisibleWeaponAmmoSpawn = CheckUnBox(sender);
        }
        #endregion

        #endregion


        #region BunnyHop
        private void checkBoxBunnyHop_CheckedChanged(object sender, EventArgs e)
        {
            bunnyHop.IsRunning = CheckUnBox(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DefaultSettingBunnyHop();
        }
        #endregion

        #region AimBot

        #endregion
    }
}