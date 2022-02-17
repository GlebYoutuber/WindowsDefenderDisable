using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Diagnostics;

namespace WindowsDefenderDisable
{
    class Program
    {
        static void Main(string[] args) 
        {
            if(!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                Debug.WriteLine("Detected Run as Admin");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Disabling Windows Defender...");
            Thread.Sleep(1000);
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = "powershell";
            proc.Arguments = "Set-MpPreference -DisableRealtimeMonitoring $true";
            proc.Verb = "runas";
            proc.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc);
            Environment.Exit(-1233);
        }
    }
}
