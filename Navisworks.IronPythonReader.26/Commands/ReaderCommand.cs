using Autodesk.Navisworks.Api.Plugins;
using Navisworks.IronPythonReader.Services;
using RNM.Navisworks.Reader.Services;
using System;
using System.Windows;

namespace RNM.Navisworks.Reader.Commands
{
    internal class ReaderCommand : AddInPlugin
    {
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
