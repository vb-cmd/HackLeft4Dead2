namespace HackLeft4Dead2
{
    public partial class FormHack : Form
    {
        GameWindow gameWindow;
        GameProcess gameProcess;
        DataEntities dataEntities;
        BunnyHop bunnyHop;
        AimBot aimBot;

        ThreadBase[] threads;

        GraphicsFPS fps;
        GraphicsBorderWindow borderWindow;
        GraphicsLineESP lineESP;
        GraphicsBoxESP boxESP;
        GraphicsRadar radar;

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
            aimBot = new(dataEntities, gameWindow.WindowInformation);


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
            threads = new ThreadBase[] { gameProcess, dataEntities, bunnyHop, gameWindow, aimBot };

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
            checkBoxSurvivorPlayer.Checked = boxESP.Setting.SurvivorPlayer.IsVisible;
            checkBoxSurvivorBot.Checked = boxESP.Setting.SurvivorBot.IsVisible;
            checkBoxHunter.Checked = boxESP.Setting.Hunter.IsVisible;
            checkBoxTank.Checked = boxESP.Setting.Tank.IsVisible;
            checkBoxWitch.Checked = boxESP.Setting.Witch.IsVisible;
            checkBoxSpitter.Checked = boxESP.Setting.Spitter.IsVisible;
            checkBox9.Checked = boxESP.Setting.Smoker.IsVisible;
            checkBox8.Checked = boxESP.Setting.Boomer.IsVisible;
            checkBox11.Checked = boxESP.Setting.Jockey.IsVisible;
            checkBox10.Checked = boxESP.Setting.Charger.IsVisible;
            checkBox13.Checked = boxESP.Setting.Infected.IsVisible;
            checkBox12.Checked = boxESP.Setting.WeaponSpawn.IsVisible;
            checkBox14.Checked = boxESP.Setting.WeaponAmmoSpawn.IsVisible;
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
            checkBox22.Checked = lineESP.Setting.SurvivorPlayer.IsVisible;
            checkBox21.Checked = lineESP.Setting.SurvivorBot.IsVisible;
            checkBox20.Checked = lineESP.Setting.Hunter.IsVisible;
            checkBox19.Checked = lineESP.Setting.Tank.IsVisible;
            checkBox18.Checked = lineESP.Setting.Witch.IsVisible;
            checkBox17.Checked = lineESP.Setting.Spitter.IsVisible;
            checkBox16.Checked = lineESP.Setting.Smoker.IsVisible;
            checkBox15.Checked = lineESP.Setting.Boomer.IsVisible;
            checkBox7.Checked = lineESP.Setting.Jockey.IsVisible;
            checkBox6.Checked = lineESP.Setting.Charger.IsVisible;
            checkBox5.Checked = lineESP.Setting.Infected.IsVisible;
            checkBox4.Checked = lineESP.Setting.WeaponSpawn.IsVisible;
            checkBox3.Checked = lineESP.Setting.WeaponAmmoSpawn.IsVisible;
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
            checkBox36.Checked = radar.Setting.SurvivorPlayer.IsVisible;
            checkBox35.Checked = radar.Setting.SurvivorBot.IsVisible;
            checkBox34.Checked = radar.Setting.Hunter.IsVisible;
            checkBox33.Checked = radar.Setting.Tank.IsVisible;
            checkBox32.Checked = radar.Setting.Witch.IsVisible;
            checkBox31.Checked = radar.Setting.Spitter.IsVisible;
            checkBox30.Checked = radar.Setting.Smoker.IsVisible;
            checkBox29.Checked = radar.Setting.Boomer.IsVisible;
            checkBox28.Checked = radar.Setting.Jockey.IsVisible;
            checkBox27.Checked = radar.Setting.Charger.IsVisible;
            checkBox26.Checked = radar.Setting.Infected.IsVisible;
            checkBox25.Checked = radar.Setting.WeaponSpawn.IsVisible;
            checkBox24.Checked = radar.Setting.WeaponAmmoSpawn.IsVisible;
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
            boxESP.Setting.SurvivorPlayer.IsVisible = CheckUnBox(sender);
        }

        private void checkBoxSurvivorBot_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.SurvivorBot.IsVisible = CheckUnBox(sender);
        }

        private void checkBoxHunter_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.Hunter.IsVisible = CheckUnBox(sender);
        }

        private void checkBoxTank_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.Tank.IsVisible = CheckUnBox(sender);
        }

        private void checkBoxWitch_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.Witch.IsVisible = CheckUnBox(sender);
        }

        private void checkBoxSpitter_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.Spitter.IsVisible = CheckUnBox(sender);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.Smoker.IsVisible = CheckUnBox(sender);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.Boomer.IsVisible = CheckUnBox(sender);
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.Jockey.IsVisible = CheckUnBox(sender);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.Charger.IsVisible = CheckUnBox(sender);
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.Infected.IsVisible = CheckUnBox(sender);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.WeaponSpawn.IsVisible = CheckUnBox(sender);
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            boxESP.Setting.WeaponAmmoSpawn.IsVisible = CheckUnBox(sender);
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
            lineESP.Setting.SurvivorPlayer.IsVisible = CheckUnBox(sender);
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.SurvivorBot.IsVisible = CheckUnBox(sender);
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.Hunter.IsVisible = CheckUnBox(sender);
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.Tank.IsVisible = CheckUnBox(sender);
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.Witch.IsVisible = CheckUnBox(sender);
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.Spitter.IsVisible = CheckUnBox(sender);
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.Smoker.IsVisible = CheckUnBox(sender);
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.Boomer.IsVisible = CheckUnBox(sender);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.Jockey.IsVisible = CheckUnBox(sender);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.Charger.IsVisible = CheckUnBox(sender);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.Infected.IsVisible = CheckUnBox(sender);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.WeaponSpawn.IsVisible = CheckUnBox(sender);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            lineESP.Setting.WeaponAmmoSpawn.IsVisible = CheckUnBox(sender);
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
            radar.Setting.SurvivorPlayer.IsVisible = CheckUnBox(sender);
        }

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.SurvivorBot.IsVisible = CheckUnBox(sender);
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.Hunter.IsVisible = CheckUnBox(sender);
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.Tank.IsVisible = CheckUnBox(sender);
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.Witch.IsVisible = CheckUnBox(sender);
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.Spitter.IsVisible = CheckUnBox(sender);
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.Smoker.IsVisible = CheckUnBox(sender);
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.Boomer.IsVisible = CheckUnBox(sender);
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.Jockey.IsVisible = CheckUnBox(sender);
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.Charger.IsVisible = CheckUnBox(sender);
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.Infected.IsVisible = CheckUnBox(sender);
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.WeaponSpawn.IsVisible = CheckUnBox(sender);
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            radar.Setting.WeaponAmmoSpawn.IsVisible = CheckUnBox(sender);
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