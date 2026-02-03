using System;

namespace Navisworks.IronPythonReader.Services
{
    /// <summary>
    /// Defines a service for displaying dialogs and selecting Python files within the plugin.
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// Displays an error dialog with a custom message.
        /// </summary>
        /// <param name="commandName">The name of the command where the error occurred.</param>
        /// <param name="exceptionMessage">The error message to display.</param>
        void ShowErrorDialog(string commandName, string exceptionMessage);

        /// <summary>
        /// Displays an error dialog for a given exception.
        /// </summary>
        /// <param name="commandName">The name of the command where the exception occurred.</param>
        /// <param name="exception">The exception to display.</param>
        void ShowErrorDialog(string commandName, Exception exception);

        /// <summary>
        /// Opens a file selection dialog for the user to select a Python file.
        /// </summary>
        /// <returns>The full path of the selected Python file, or null if canceled.</returns>
        string SelectPythonFile();
    }
}
