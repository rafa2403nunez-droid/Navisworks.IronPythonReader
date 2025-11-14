using Autodesk.Navisworks.Api.Plugins;
using Navisworks.IronPythonReader.Services;
using RNM.Navisworks.Balio.Services;
using System;
using System.Windows;

namespace RNM.Navisworks.Balio.Commands
{
    /// <summary>
    /// Represents a Navisworks Add-in plugin that executes Python scripts.
    /// </summary>
    internal class ReaderCommand : AddInPlugin
    {
        /// <summary>
        /// Executes the plugin logic when triggered.
        /// </summary>
        /// <param name="parameters">Optional parameters passed to the plugin.</param>
        /// <returns>Returns 1 if the execution is successful, 0 if an exception occurs.</returns>
        public override int Execute(params string[] parameters)
        {
            try
            {
                IPythonService pythonService = new PythonService();
                pythonService.ExecuteCode();

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
