global using HackLeft4Dead2.Extensions;
global using HackLeft4Dead2.Hack;
global using HackLeft4Dead2.Hack.Models;
global using HackLeft4Dead2.Graphics;
global using HackLeft4Dead2.Settings;
global using HackLeft4Dead2.Features;
global using OverlayManagement;
global using MemoryManagement;


global using System.Numerics;
global using System.Diagnostics;
global using System.Runtime.InteropServices;
global using System.Text;
global using System;
global using System.Windows.Forms;
global using System.Threading;
global using System.Drawing;
global using System.Linq;
global using System.Collections.Generic;

namespace HackLeft4Dead2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormHack());
        }
    }
}