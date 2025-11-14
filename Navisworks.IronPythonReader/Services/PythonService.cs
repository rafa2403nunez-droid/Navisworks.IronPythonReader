using Autodesk.Navisworks.Api;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Navisworks.IronPythonReader.Services;
using System;

namespace RNM.Navisworks.Balio.Services
{
    /// <summary>
    /// Provides functionality to execute Python scripts within Navisworks.
    /// </summary>
    internal class PythonService : IPythonService
    {
        private readonly IDialogService dialogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PythonService"/> class
        /// and sets up the dialog service.
        /// </summary>
        public PythonService()
        {
            dialogService = new DialogService();
        }

        /// <summary>
        /// Executes a Python script selected by the user via a file dialog.
        /// The script can access the active Navisworks document via the "__navisworks__" variable.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if the user cancels file selection.</exception>
        public void ExecuteCode()
        {
            string path = dialogService.SelectPythonFile();

            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            ScriptEngine engine = Python.CreateEngine();
            ScriptIO output = engine.Runtime.IO;
            ScriptSource source = engine.CreateScriptSourceFromFile(path);

            ScriptScope scope = engine.CreateScope();
            scope.SetVariable("__navisworks__", Application.ActiveDocument);

            try
            {
                source.Execute(scope);
            }
            catch (Exception ex)
            {
                ExceptionOperations exceptionOperation = engine.GetService<ExceptionOperations>();
                dialogService.ShowErrorDialog("Reader", exceptionOperation.FormatException(ex));
            }
        }
    }
}
