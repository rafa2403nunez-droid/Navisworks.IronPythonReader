using Autodesk.Navisworks.Api.Plugins;
using RNM.Navisworks.Balio.Commands;
using System;
using System.Windows;

namespace Navisworks.IronPythonReader
{
    /// <summary>
    /// Represents the main plugin application for executing IronPython scripts in Navisworks.
    /// Configures the ribbon layout, tabs, and commands for the plugin.
    /// </summary>
    [Plugin(name: "IronPythonReader", developerId: "RNM", DisplayName = "IronPython Reader", ToolTip = "IronPython Script Runner")]
    [RibbonLayout("IronPythonReader.xaml")]
    [RibbonTab("RNMReader", DisplayName = "IronPython Reader")]
    [Command("ReaderCommand", DisplayName = "Run Script", Icon = "Runner32.png", LargeIcon = "Reader32.png")]
    public class App : CommandHandlerPlugin
    {
        /// <summary>
        /// Executes the specified command for the plugin.
        /// </summary>
        /// <param name="name">The name of the command to execute.</param>
        /// <param name="parameters">Optional parameters for the command.</param>
        /// <returns>Returns 1 if the command executes successfully, 0 if an exception occurs.</returns>
        public override int ExecuteCommand(string name, params string[] parameters)
        {
            try
            {
                switch (name)
                {
                    case "ReaderCommand":
                        new ReaderCommand().Execute();
                        break;
                }
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }
}
