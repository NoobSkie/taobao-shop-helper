namespace Shove._System
{
    using System;
    using System.Diagnostics;

    public class Processes
    {
        public static void KillProcesses(string ProcessesName)
        {
            foreach (Process process in Process.GetProcessesByName(ProcessesName))
            {
                process.Kill();
            }
        }
    }
}

