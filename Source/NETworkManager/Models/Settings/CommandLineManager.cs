﻿using NETworkManager.Views.Settings;
using System;
using System.Windows;

namespace NETworkManager.Models.Settings
{
    public static class CommandLineManager
    {
        public const string ParameterIdentifier = "--";
        public const string ParameterAutostart = "autostart";
        public const string ParameterResetSettings = "reset-settings";

        public static CommandLineInfo Current { get; set; }

        /// <summary>
        /// Get the arguments passed by the command line
        /// </summary>
        /// <returns>CommandLineInfo</returns>
        public static void Parse()
        {
            Current = new CommandLineInfo();

            // Get the command line args
            string[] parameters = Environment.GetCommandLineArgs();

            char[] trimChars = ParameterIdentifier.ToCharArray();

            // Detect start parameters
            foreach (string parameter in parameters)
            {
                if (parameter.StartsWith(ParameterIdentifier))
                {
                    // Autostart
                    if (parameter.TrimStart(trimChars).Equals(ParameterAutostart, StringComparison.InvariantCultureIgnoreCase))
                        Current.Autostart = true;
                    else if (parameter.TrimStart(trimChars).Equals(ParameterResetSettings, StringComparison.InvariantCultureIgnoreCase))
                        Current.ResetSettings = true;
                    else
                    {
                        MetroMessageBox msg = new MetroMessageBox();
                        msg.ShowDialog();
                    }
                }
            }
        }

        public static string GetCommandLineParameter(string parameter)
        {
            return string.Format("{0}{1}", ParameterIdentifier, parameter);
        }
    }
}
