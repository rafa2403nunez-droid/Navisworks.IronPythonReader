using Autodesk.Navisworks.Api.Plugins;
using RNM.Navisworks.Balio.Commands;
using System;
using System.Windows;

namespace Navisworks.IronPythonReader
{
    [Plugin(name: "IronPythonReader",
            developerId: "RNM",
            DisplayName = "IronPython Reader",
            ToolTip = "IronPython Script Runner")]

    [RibbonLayout("IronPythonReader.xaml")]
    [RibbonTab("RNMReader", DisplayName = "IronPython Reader")]
    [Command("ReaderCommand", DisplayName = "Run Script", Icon = "Runner32.png", LargeIcon = "Reader32.png")]

    public class App : CommandHandlerPlugin
    {
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
