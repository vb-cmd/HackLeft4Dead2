namespace CheatL4D2;

public partial class FormHack : Form
{
    GameWindow gameWindow;
    GameProcess gameProcess;
    Data gameDataEntities;
    BunnyHop gameBunnyHop;
    AimBot gameAimBot;

    ThreadBase[] threads;

    GraphicsFPS graphicsFps;
    GraphicsLineESP graphicsLineEsp;
    GraphicsBoxESP graphicsBoxEsp;
    GraphicsRadar graphicsRadar;

    public FormHack()
    {
        InitializeComponent();
    }

    #region Helper Methods

    private void InitializeFields()
    {
        gameWindow = new();
        gameProcess = new();
        gameDataEntities = new(gameProcess, gameWindow.WindowInformation);
        gameBunnyHop = new(gameProcess);
        gameAimBot = new(gameDataEntities, gameWindow.WindowInformation, gameProcess);


        graphicsFps = new GraphicsFPS();
        graphicsLineEsp = new GraphicsLineESP(gameDataEntities);
        graphicsBoxEsp = new GraphicsBoxESP(gameDataEntities);
        graphicsRadar = new(gameDataEntities);

        threads = new ThreadBase[] {
            gameDataEntities,
            gameBunnyHop,
            gameWindow,
            gameAimBot
        };
    }

    private void AddGraphicsToOverlayWindow()
    {
        var graphicsArray = new IGraphics[] { graphicsFps, graphicsLineEsp, graphicsBoxEsp, graphicsRadar };
        gameWindow.OverlayWindow.GraphicsCollection.AddRange(graphicsArray);
    }

    private void SearchGameProcess()
    {
        if (gameProcess.Search())
        {
            checkGameProcess.Start();
        }
        else
        {
            MessageBox.Show("The game process is not found. Run the game.");
            this.Close();
        }
    }

    private void StartThreads()
    {
        //start threads
        foreach (var thread in threads)
            thread.Start();
    }


    private static string ToggleText(bool toggle)
    {
        return "Turn " + (toggle ? "on" : "off");
    }

    private void SetPositionFps(PositionVertical positionVertical, PositionHorizontal positionHorizontal)
    {
        graphicsFps.Setting.PositionVertical = positionVertical;
        graphicsFps.Setting.PositionHorizontal = positionHorizontal;
    }

    private void SetPositionRadar(PositionVertical positionVertical, PositionHorizontal positionHorizontal)
    {
        graphicsRadar.Setting.PositionVertical = positionVertical;
        graphicsRadar.Setting.PositionHorizontal = positionHorizontal;
    }

    #endregion


    #region Default settings


    private void SetDefaultSettings()
    {
        DefaultSettingBorderWindow();
        DefaultSettingBoxESP();
        DefaultSettingBunnyHop();
        DefaultSettingFPS();
        DefaultSettingLineESP();
        DefaultSettingRadar();
        DefaultSettingAimBot();
    }

    private void DefaultSettingBorderWindow()
    {
        gameWindow.WindowInformation.IsWindowHasTopPanel = false;
        overlayWindowTopCheckBox.Checked = false;
    }

    private void DefaultSettingBoxESP()
    {
        // Reset Setting
        graphicsBoxEsp.Setting = new();

        // Visible EspBox
        overlayEspBoxShow.Checked = graphicsBoxEsp.Setting.IsVisible;
        overlayEspBoxShow.TextButton = ToggleText(overlayEspBoxShow.Checked);
        overlayEspBoxBorderSizeTrack.Value = graphicsBoxEsp.Setting.SizeObject;


        //Show Models
        overlayEspBoxSirvivorPlayer.Checked = graphicsBoxEsp.Setting.SurvivorPlayer.IsVisible;
        overlayEspBoxSurvivorBot.Checked = graphicsBoxEsp.Setting.SurvivorBot.IsVisible;
        overlayEspBoxHunter.Checked = graphicsBoxEsp.Setting.Hunter.IsVisible;
        overlayEspBoxTank.Checked = graphicsBoxEsp.Setting.Tank.IsVisible;
        overlayEspBoxWitch.Checked = graphicsBoxEsp.Setting.Witch.IsVisible;
        overlayEspBoxSpitter.Checked = graphicsBoxEsp.Setting.Spitter.IsVisible;
        overlayEspBoxSmoker.Checked = graphicsBoxEsp.Setting.Smoker.IsVisible;
        overlayEspBoxBoomer.Checked = graphicsBoxEsp.Setting.Boomer.IsVisible;
        overlayEspBoxJockey.Checked = graphicsBoxEsp.Setting.Jockey.IsVisible;
        overlayEspBoxCharger.Checked = graphicsBoxEsp.Setting.Charger.IsVisible;
        overlayEspBoxInfected.Checked = graphicsBoxEsp.Setting.Infected.IsVisible;
        overlayEspBoxWeaponSpawn.Checked = graphicsBoxEsp.Setting.WeaponSpawn.IsVisible;
        overlayEspBoxWeaponAmmoSpawn.Checked = graphicsBoxEsp.Setting.WeaponAmmoSpawn.IsVisible;
    }

    private void DefaultSettingBunnyHop()
    {
        // Turn on BunnyHop
        gameBunnyHop.IsRunning = true;
        checkBoxBunnyHop.Checked = true;
        checkBoxBunnyHop.TextButton = ToggleText(checkBoxBunnyHop.Checked);
    }

    private void DefaultSettingFPS()
    {
        // Reset setting
        graphicsFps.Setting = new();
        // Visible fps
        overlayFpsCheckBox.Checked = graphicsFps.Setting.IsVisible;
        overlayFpsCheckBox.TextButton = ToggleText(overlayFpsCheckBox.Checked);
    }

    private void DefaultSettingLineESP()
    {
        // Reset setting
        graphicsLineEsp.Setting = new();

        // Visible line
        overlayEspLineShow.Checked = graphicsLineEsp.Setting.IsVisible;
        overlayEspLineShow.TextButton = ToggleText(overlayEspLineShow.Checked);

        //Show models
        overlayEspLineSurviverPlayer.Checked = graphicsLineEsp.Setting.SurvivorPlayer.IsVisible;
        overlayEspLineSurviverBot.Checked = graphicsLineEsp.Setting.SurvivorBot.IsVisible;
        overlayEspLineHunter.Checked = graphicsLineEsp.Setting.Hunter.IsVisible;
        overlayEspLineTank.Checked = graphicsLineEsp.Setting.Tank.IsVisible;
        overlayEspLineWitch.Checked = graphicsLineEsp.Setting.Witch.IsVisible;
        overlayEspLineSpitter.Checked = graphicsLineEsp.Setting.Spitter.IsVisible;
        overlayEspLineSmoker.Checked = graphicsLineEsp.Setting.Smoker.IsVisible;
        overlayEspLineBoomer.Checked = graphicsLineEsp.Setting.Boomer.IsVisible;
        overlayEspLineJockey.Checked = graphicsLineEsp.Setting.Jockey.IsVisible;
        overlayEspLineCharger.Checked = graphicsLineEsp.Setting.Charger.IsVisible;
        overlayEspLineInfected.Checked = graphicsLineEsp.Setting.Infected.IsVisible;
        overlayEspLineWeaponSpawn.Checked = graphicsLineEsp.Setting.WeaponSpawn.IsVisible;
        overlayEspLineWeaponAmmoSpawn.Checked = graphicsLineEsp.Setting.WeaponAmmoSpawn.IsVisible;
    }

    private void DefaultSettingRadar()
    {
        // Reset setting
        graphicsRadar.Setting = new();

        // Visible radar
        overlayRadarCheckBox.Checked = graphicsRadar.Setting.IsVisible;
        overlayRadarCheckBox.TextButton = ToggleText(overlayRadarCheckBox.Checked);

        // Size models
        overlayRadarSizeModelOtherTrack.Value = graphicsRadar.Setting.SizeObject;
        overlayRadarSizeModelPlayerTrack.Value = graphicsRadar.Setting.SizePlayer;

        // Size Radar
        overlayRadarSizeRadarTrack.Value = graphicsRadar.Setting.CustomPositionAndSize.Height;

        //Show models
        overlayRadarTargetsSurvivorPlayer.Checked = graphicsRadar.Setting.SurvivorPlayer.IsVisible;
        overlayRadarTargetsSurvivorBot.Checked = graphicsRadar.Setting.SurvivorBot.IsVisible;
        overlayRadarTargetsHunter.Checked = graphicsRadar.Setting.Hunter.IsVisible;
        overlayRadarTargetsTank.Checked = graphicsRadar.Setting.Tank.IsVisible;
        overlayRadarTargetsWitch.Checked = graphicsRadar.Setting.Witch.IsVisible;
        overlayRadarTargetsSpitter.Checked = graphicsRadar.Setting.Spitter.IsVisible;
        overlayRadarTargetsSmoker.Checked = graphicsRadar.Setting.Smoker.IsVisible;
        overlayRadarTargetsBoomer.Checked = graphicsRadar.Setting.Boomer.IsVisible;
        overlayRadarTargetsJockey.Checked = graphicsRadar.Setting.Jockey.IsVisible;
        overlayRadarTargetsCharger.Checked = graphicsRadar.Setting.Charger.IsVisible;
        overlayRadarTargetsInfected.Checked = graphicsRadar.Setting.Infected.IsVisible;
        overlayRadarTargetsWeaponSpawn.Checked = graphicsRadar.Setting.WeaponSpawn.IsVisible;
        overlayRadarTargetsWeaponAmmoSpawn.Checked = graphicsRadar.Setting.WeaponAmmoSpawn.IsVisible;
    }

    private void DefaultSettingAimBot()
    {
        gameAimBot.IsRunning = true;
        checkBoxAimBot.Checked = gameAimBot.IsRunning;
        checkBoxAimBot.TextButton = ToggleText(checkBoxAimBot.Checked);

        aimBotTargetsTank.Checked = gameAimBot.TargetTank;
        aimBotTargetsHunter.Checked = gameAimBot.TargetHunter;
        aimBotTargetsWitch.Checked = gameAimBot.TargetWitch;
        aimBotTargetsSpitter.Checked = gameAimBot.TargetSpitter;
        aimBotTargetsSmoker.Checked = gameAimBot.TargetSmoker;
        aimBotTargetsBoomer.Checked = gameAimBot.TargetBoomer;
        aimBotTargetsJockey.Checked = gameAimBot.TargetJockey;
        aimBotTargetsCharger.Checked = gameAimBot.TargetCharger;
        aimBotTargetsInfected.Checked = gameAimBot.TargetInfected;
    }

    #endregion


    #region Form Event

    #region Load and closing

    private void FormHack_Load(object sender, EventArgs e)
    {
        InitializeFields();
        AddGraphicsToOverlayWindow();
        SearchGameProcess();
        StartThreads();
        SetDefaultSettings();
    }

    private void FormHack_FormClosing(object sender, FormClosingEventArgs e)
    {
        checkGameProcess.Stop();

        var cleanList = new IDisposable[] {
            gameAimBot,
            gameBunnyHop,
            gameDataEntities,
            gameProcess,
            gameWindow
        };

        foreach (var item in cleanList)
            item?.Dispose();
    }

    #endregion

    #region Navigation for Top Panel

    private void buttonCloseWindow_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void buttonMinimal_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }

    bool dragging;
    Point startPosition = Point.Empty;

    private void FormHack_MouseDown(object sender, MouseEventArgs e)
    {
        dragging = true;
        startPosition = new Point(e.X, e.Y);
    }

    private void FormHack_MouseMove(object sender, MouseEventArgs e)
    {
        if (dragging)
        {
            var point = PointToScreen(e.Location);
            Location = new Point(point.X - startPosition.X, point.Y - startPosition.Y);
        }
    }

    private void FormHack_MouseUp(object sender, MouseEventArgs e)
    {
        dragging = false;
    }

    #endregion

    private void checkGameProcess_Tick(object sender, EventArgs e)
    {
        if (checkGameProcess.Enabled)
        {
            if (!gameProcess.IsRunningGame)
            {
                checkGameProcess.Stop();
                this.Close();
            }
        }
    }

    #endregion

    #region Overlay

    #region Window

    private void overlayWindowTopCheckBox_CheckedChanged()
    {
        gameWindow.WindowInformation.IsWindowHasTopPanel = overlayWindowTopCheckBox.Checked;
    }

    private void overlayWindowTopDefault_Click(object sender, EventArgs e)
    {
        DefaultSettingBorderWindow();
    }

    #endregion

    #region ESP

    #region Box

    #region Other
    private void overlayEspBoxBorderSizeTrack_ValueChanged(object sender, EventArgs e)
    {
        graphicsBoxEsp.Setting.SizeObject = overlayEspBoxBorderSizeTrack.Value;
    }

    private void overlayEspBoxShow_CheckedChanged()
    {
        graphicsBoxEsp.Setting.IsVisible = overlayEspBoxShow.Checked;
        overlayEspBoxShow.TextButton = ToggleText(overlayEspBoxShow.Checked);
    }

    private void overlayEspBoxDefault_Click(object sender, EventArgs e)
    {
        DefaultSettingBoxESP();
    }

    #endregion

    #region Show Model
    private void overlayEspBoxSirvivorPlayer_CheckedChanged()
    {
        graphicsBoxEsp.Setting.SurvivorPlayer.IsVisible = overlayEspBoxSirvivorPlayer.Checked;
    }

    private void overlayEspBoxSurvivorBot_CheckedChanged()
    {
        graphicsBoxEsp.Setting.SurvivorBot.IsVisible = overlayEspBoxSurvivorBot.Checked;
    }

    private void overlayEspBoxTank_CheckedChanged()
    {
        graphicsBoxEsp.Setting.Tank.IsVisible = overlayEspBoxTank.Checked;
    }

    private void overlayEspBoxWitch_CheckedChanged()
    {
        graphicsBoxEsp.Setting.Witch.IsVisible = overlayEspBoxWitch.Checked;
    }

    private void overlayEspBoxSpitter_CheckedChanged()
    {
        graphicsBoxEsp.Setting.Spitter.IsVisible = overlayEspBoxSpitter.Checked;
    }

    private void overlayEspBoxSmoker_CheckedChanged()
    {
        graphicsBoxEsp.Setting.Smoker.IsVisible = overlayEspBoxSmoker.Checked;
    }

    private void overlayEspBoxBoomer_CheckedChanged()
    {
        graphicsBoxEsp.Setting.Boomer.IsVisible = overlayEspBoxBoomer.Checked;
    }

    private void overlayEspBoxJockey_CheckedChanged()
    {
        graphicsBoxEsp.Setting.Jockey.IsVisible = overlayEspBoxJockey.Checked;
    }

    private void overlayEspBoxCharger_CheckedChanged()
    {
        graphicsBoxEsp.Setting.Charger.IsVisible = overlayEspBoxCharger.Checked;
    }

    private void overlayEspBoxHunter_CheckedChanged()
    {
        graphicsBoxEsp.Setting.Hunter.IsVisible = overlayEspBoxHunter.Checked;
    }

    private void overlayEspBoxInfected_CheckedChanged()
    {
        graphicsBoxEsp.Setting.Infected.IsVisible = overlayEspBoxInfected.Checked;
    }

    private void overlayEspBoxWeaponSpawn_CheckedChanged()
    {
        graphicsBoxEsp.Setting.WeaponSpawn.IsVisible = overlayEspBoxWeaponSpawn.Checked;
    }

    private void overlayEspBoxWeaponAmmoSpawn_CheckedChanged()
    {
        graphicsBoxEsp.Setting.WeaponAmmoSpawn.IsVisible = overlayEspBoxWeaponAmmoSpawn.Checked;
    }

    #endregion

    #endregion

    #region Line

    #region Other

    private void overlayEspLineShow_CheckedChanged()
    {
        graphicsLineEsp.Setting.IsVisible = overlayEspLineShow.Checked;
        overlayEspLineShow.TextButton = ToggleText(overlayEspLineShow.Checked);
    }

    private void overlayEspLineDefault_Click(object sender, EventArgs e)
    {
        DefaultSettingLineESP();
    }

    #endregion

    #region Show Models

    private void overlayEspLineSurviverPlayer_CheckedChanged()
    {
        graphicsLineEsp.Setting.SurvivorPlayer.IsVisible = overlayEspLineSurviverPlayer.Checked;
    }

    private void overlayEspLineSurviverBot_CheckedChanged()
    {
        graphicsLineEsp.Setting.SurvivorBot.IsVisible = overlayEspLineSurviverBot.Checked;
    }

    private void overlayEspLineTank_CheckedChanged()
    {
        graphicsLineEsp.Setting.Tank.IsVisible = overlayEspLineTank.Checked;
    }

    private void overlayEspLineWitch_CheckedChanged()
    {
        graphicsLineEsp.Setting.Witch.IsVisible = overlayEspLineWitch.Checked;
    }

    private void overlayEspLineSpitter_CheckedChanged()
    {
        graphicsLineEsp.Setting.Spitter.IsVisible = overlayEspLineSpitter.Checked;
    }

    private void overlayEspLineSmoker_CheckedChanged()
    {
        graphicsLineEsp.Setting.Smoker.IsVisible = overlayEspLineSmoker.Checked;
    }

    private void overlayEspLineBoomer_CheckedChanged()
    {
        graphicsLineEsp.Setting.Boomer.IsVisible = overlayEspLineBoomer.Checked;
    }

    private void overlayEspLineJockey_CheckedChanged()
    {
        graphicsLineEsp.Setting.Jockey.IsVisible = overlayEspLineJockey.Checked;
    }

    private void overlayEspLineCharger_CheckedChanged()
    {
        graphicsLineEsp.Setting.Charger.IsVisible = overlayEspLineCharger.Checked;
    }

    private void overlayEspLineHunter_CheckedChanged()
    {
        graphicsLineEsp.Setting.Hunter.IsVisible = overlayEspLineHunter.Checked;
    }

    private void overlayEspLineInfected_CheckedChanged()
    {
        graphicsLineEsp.Setting.Infected.IsVisible = overlayEspLineInfected.Checked;
    }

    private void overlayEspLineWeaponSpawn_CheckedChanged()
    {
        graphicsLineEsp.Setting.WeaponSpawn.IsVisible = overlayEspLineWeaponSpawn.Checked;
    }

    private void overlayEspLineWeaponAmmoSpawn_CheckedChanged()
    {
        graphicsLineEsp.Setting.WeaponAmmoSpawn.IsVisible = overlayEspLineWeaponAmmoSpawn.Checked;
    }

    #endregion

    #endregion

    #endregion


    #region Fps

    private void overlayFpsCheckBox_CheckedChanged()
    {
        graphicsFps.Setting.IsVisible = overlayFpsCheckBox.Checked;
        overlayFpsCheckBox.TextButton = ToggleText(overlayFpsCheckBox.Checked);
    }

    private void overlayFpsDefault_Click(object sender, EventArgs e)
    {
        DefaultSettingFPS();
    }

    private void overlayFpsPositionTopLeft_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionFps(PositionVertical.Top, PositionHorizontal.Left);
    }

    private void overlayFpsPositionTopCenter_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionFps(PositionVertical.Top, PositionHorizontal.Center);
    }

    private void overlayFpsPositionTopRight_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionFps(PositionVertical.Top, PositionHorizontal.Right);
    }

    private void overlayFpsPositionCenterLeft_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionFps(PositionVertical.Center, PositionHorizontal.Left);
    }

    private void overlayFpsPositionCenterCenter_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionFps(PositionVertical.Center, PositionHorizontal.Center);
    }

    private void overlayFpsPositionCenterRight_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionFps(PositionVertical.Center, PositionHorizontal.Right);
    }

    private void overlayFpsPositionBottomLeft_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionFps(PositionVertical.Bottom, PositionHorizontal.Left);
    }

    private void overlayFpsPositionBottomCenter_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionFps(PositionVertical.Bottom, PositionHorizontal.Center);
    }

    private void overlayFpsPositionBottomRight_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionFps(PositionVertical.Bottom, PositionHorizontal.Right);
    }

    #endregion


    #region Radar

    #region Other

    private void overlayRadarCheckBox_CheckedChanged()
    {
        graphicsRadar.Setting.IsVisible = overlayRadarCheckBox.Checked;
        overlayRadarCheckBox.TextButton = ToggleText(overlayRadarCheckBox.Checked);
    }

    private void overlayRadarDefault_Click(object sender, EventArgs e)
    {
        DefaultSettingRadar();
    }

    private void overlayRadarPositionTopLeft_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionRadar(PositionVertical.Top, PositionHorizontal.Left);
    }

    private void overlayRadarPositionTopCenter_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionRadar(PositionVertical.Top, PositionHorizontal.Center);
    }

    private void overlayRadarPositionTopRight_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionRadar(PositionVertical.Top, PositionHorizontal.Right);
    }

    private void overlayRadarPositionCenterLeft_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionRadar(PositionVertical.Center, PositionHorizontal.Left);
    }

    private void overlayRadarPositionCenterCenter_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionRadar(PositionVertical.Center, PositionHorizontal.Center);
    }

    private void overlayRadarPositionCenterRight_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionRadar(PositionVertical.Center, PositionHorizontal.Right);
    }

    private void overlayRadarPositionButtonLeft_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionRadar(PositionVertical.Bottom, PositionHorizontal.Left);
    }

    private void overlayRadarPositionButtonCenter_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionRadar(PositionVertical.Bottom, PositionHorizontal.Center);
    }

    private void overlayRadarPositionButtonRight_CheckedChanged(object sender, EventArgs e)
    {
        SetPositionRadar(PositionVertical.Bottom, PositionHorizontal.Right);
    }

    private void overlayRadarSizeRadarTrack_ValueChanged(object sender, EventArgs e)
    {
        var rect = graphicsRadar.Setting.CustomPositionAndSize;

        rect.Width = overlayRadarSizeRadarTrack.Value;
        rect.Height = overlayRadarSizeRadarTrack.Value;

        graphicsRadar.Setting.CustomPositionAndSize = rect;
    }

    private void overlayRadarSizeModelPlayerTrack_ValueChanged(object sender, EventArgs e)
    {
        graphicsRadar.Setting.SizePlayer = overlayRadarSizeModelPlayerTrack.Value;
    }

    private void overlayRadarSizeModelOtherTrack_ValueChanged(object sender, EventArgs e)
    {
        graphicsRadar.Setting.SizeObject = overlayRadarSizeModelOtherTrack.Value;
    }

    #endregion



    #region Show Models

    private void overlayRadarTargetsSurvivorPlayer_CheckedChanged()
    {
        graphicsRadar.Setting.SurvivorPlayer.IsVisible = overlayRadarTargetsSurvivorPlayer.Checked;
    }

    private void overlayRadarTargetsSurvivorBot_CheckedChanged()
    {
        graphicsRadar.Setting.SurvivorBot.IsVisible = overlayRadarTargetsSurvivorBot.Checked;
    }

    private void overlayRadarTargetsWeaponSpawn_CheckedChanged()
    {
        graphicsRadar.Setting.WeaponSpawn.IsVisible = overlayRadarTargetsWeaponSpawn.Checked;
    }

    private void overlayRadarTargetsWeaponAmmoSpawn_CheckedChanged()
    {
        graphicsRadar.Setting.WeaponAmmoSpawn.IsVisible = overlayRadarTargetsWeaponAmmoSpawn.Checked;
    }

    private void overlayRadarTargetsTank_CheckedChanged()
    {
        graphicsRadar.Setting.Tank.IsVisible = overlayRadarTargetsTank.Checked;
    }

    private void overlayRadarTargetsWitch_CheckedChanged()
    {
        graphicsRadar.Setting.Witch.IsVisible = overlayRadarTargetsWitch.Checked;
    }

    private void overlayRadarTargetsSpitter_CheckedChanged()
    {
        graphicsRadar.Setting.Spitter.IsVisible = overlayRadarTargetsSpitter.Checked;
    }

    private void overlayRadarTargetsSmoker_CheckedChanged()
    {
        graphicsRadar.Setting.Smoker.IsVisible = overlayRadarTargetsSmoker.Checked;
    }

    private void overlayRadarTargetsBoomer_CheckedChanged()
    {
        graphicsRadar.Setting.Boomer.IsVisible = overlayRadarTargetsBoomer.Checked;
    }

    private void overlayRadarTargetsJockey_CheckedChanged()
    {
        graphicsRadar.Setting.Jockey.IsVisible = overlayRadarTargetsJockey.Checked;
    }

    private void overlayRadarTargetsCharger_CheckedChanged()
    {
        graphicsRadar.Setting.Charger.IsVisible = overlayRadarTargetsCharger.Checked;
    }

    private void overlayRadarTargetsHunter_CheckedChanged()
    {
        graphicsRadar.Setting.Hunter.IsVisible = overlayRadarTargetsHunter.Checked;
    }

    private void overlayRadarTargetsInfected_CheckedChanged()
    {
        graphicsRadar.Setting.Infected.IsVisible = overlayRadarTargetsInfected.Checked;
    }

    #endregion


    #endregion


    #endregion

    #region BunnyHop

    private void checkBoxBunnyHop_CheckedChanged()
    {
        gameBunnyHop.IsRunning = checkBoxBunnyHop.Checked;
        checkBoxBunnyHop.TextButton = ToggleText(checkBoxBunnyHop.Checked);
    }

    private void bunnyHopDefault_Click(object sender, EventArgs e)
    {
        DefaultSettingBunnyHop();
    }

    #endregion

    #region AimBot

    private void checkBoxAimBot_CheckedChanged()
    {
        gameAimBot.IsRunning = checkBoxAimBot.Checked;
        checkBoxAimBot.TextButton = ToggleText(checkBoxAimBot.Checked);
    }

    private void aimBotDefault_Click(object sender, EventArgs e)
    {
        DefaultSettingAimBot();
    }

    private void aimBotTargetsTank_CheckedChanged()
    {
        gameAimBot.TargetTank = aimBotTargetsTank.Checked;
    }

    private void aimBotTargetsWitch_CheckedChanged()
    {
        gameAimBot.TargetWitch = aimBotTargetsWitch.Checked;
    }

    private void aimBotTargetsSpitter_CheckedChanged()
    {
        gameAimBot.TargetSpitter = aimBotTargetsSpitter.Checked;
    }

    private void aimBotTargetsSmoker_CheckedChanged()
    {
        gameAimBot.TargetSmoker = aimBotTargetsSmoker.Checked;
    }

    private void aimBotTargetsBoomer_CheckedChanged()
    {
        gameAimBot.TargetBoomer = aimBotTargetsBoomer.Checked;
    }

    private void aimBotTargetsJockey_CheckedChanged()
    {
        gameAimBot.TargetJockey = aimBotTargetsJockey.Checked;
    }

    private void aimBotTargetsCharger_CheckedChanged()
    {
        gameAimBot.TargetCharger = aimBotTargetsCharger.Checked;
    }

    private void aimBotTargetsHunter_CheckedChanged()
    {
        gameAimBot.TargetHunter = aimBotTargetsHunter.Checked;
    }

    private void aimBotTargetsInfected_CheckedChanged()
    {
        gameAimBot.TargetInfected = aimBotTargetsInfected.Checked;
    }

    #endregion

}