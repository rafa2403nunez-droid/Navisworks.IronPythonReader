using Autodesk.Navisworks.Api;
using Python.Runtime;
using System;
using System.IO;

namespace Navisworks.IronPythonReader.Services
{
    /// <summary>
    /// Executes Python scripts using pythonnet instead of IronPython.
    /// Supports external packages like pandas, numpy, matplotlib.
    /// </summary>
    internal class PythonService : IPythonService
    {
        private readonly IDialogService dialogService;
        private static bool pythonInitialized = false;

        public PythonService()
        {
            dialogService = new DialogService();
        }

        /// <summary>
        /// Loads and executes a Python script using pythonnet.
        /// Exposes "__navisworks__" referencing the active document.
        /// Captures standard output and errors.
        /// </summary>
        public void ExecuteCode()
        {
            string path = dialogService.SelectPythonFile();
            if (string.IsNullOrEmpty(path))
            {
                dialogService.ShowErrorDialog("PythonNET Error", "No se seleccionó ningún archivo.");
                return;
            }

            try
            {
                // Configurar la DLL de Python 3.12
                Environment.SetEnvironmentVariable(
                    "PYTHONNET_PYDLL",
                    @"C:\Users\RafaelNúñezdeArenas\AppData\Local\Programs\Python\Python312\python312.dll"
                );

                // Inicializar pythonnet solo una vez
                if (!pythonInitialized)
                {
                    PythonEngine.Initialize();
                    pythonInitialized = true;
                }

                using (Py.GIL())
                {
                    {

                        // Crear un scope de ejecución
                        using (PyModule scope = Py.CreateScope())
                        {
                            // Agregar la carpeta del script al sys.path
                            dynamic sys = Py.Import("sys");
                            sys.path.append(Path.GetDirectoryName(path));

                            // Exponer el documento activo de Navisworks
                            scope.Set("__navisworks__", Application.ActiveDocument);

                            // Leer y ejecutar el script
                            string code = File.ReadAllText(path);
                            scope.Exec(code);
                        }
                    }
                }
            }
            catch (PythonException pyEx)
            {
                dialogService.ShowErrorDialog("PythonNET Error", pyEx.Message + "\n" + pyEx.StackTrace);
            }
            catch (Exception ex)
            {
                dialogService.ShowErrorDialog("PythonNET Error", ex.ToString());
            }
        }

        /// <summary>
        /// Shutdown Python engine safely if needed.
        /// </summary>
        public static void ShutdownPython()
        {
            if (pythonInitialized)
            {
                PythonEngine.Shutdown();
                pythonInitialized = false;
            }
        }

        /// <summary>
        /// Helper class to capture Python output
        /// </summary>
        private class PyStringIO : IDisposable
        {
            public PyObject Stream { get; }
            public System.Text.Encoding Encoding { get; }

            public PyStringIO()
            {
                dynamic io = Py.Import("io");
                Stream = io.StringIO();
                Encoding = System.Text.Encoding.UTF8;
            }

            public void Dispose()
            {
                Stream.Dispose();
            }
        }
    }
}
