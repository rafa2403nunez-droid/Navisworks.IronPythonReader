using Autodesk.Navisworks.Api;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Navisworks.IronPythonReader.Services;
using System;

namespace RNM.Navisworks.Balio.Services
{
    internal class PythonService : IPythonService
    {
        private readonly IDialogService dialogService;

        public PythonService()
        {
            dialogService = new DialogService();
        }

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
