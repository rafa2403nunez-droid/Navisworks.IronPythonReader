using System;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Navisworks.IronPythonReader.Services
{
    /// <summary>
    /// Provides implementations for displaying dialogs and selecting Python files.
    /// </summary>
    internal class DialogService : IDialogService
    {
        /// <summary>
        /// Displays an error dialog for a given exception.
        /// </summary>
        /// <param name="commandName">The name of the command where the exception occurred.</param>
        /// <param name="exception">The exception to display.</param>
        public void ShowErrorDialog(string commandName, Exception exception)
        {
            MessageBox.Show($"There was a problem during the execution: Error:\n{exception.Message}",
                            "Reader", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Displays an error dialog with a custom error message.
        /// </summary>
        /// <param name="commandName">The name of the command where the error occurred.</param>
        /// <param name="exceptionMessage">The error message to display.</param>
        public void ShowErrorDialog(string commandName, string exceptionMessage)
        {
            MessageBox.Show($"There was a problem during the execution: Error:\n{exceptionMessage}",
                            "Reader", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Opens a file selection dialog for the user to select a Python script.
        /// </summary>
        /// <returns>The full path of the selected Python file, or null if the dialog is canceled.</returns>
        public string SelectPythonFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Python Script";
                openFileDialog.Filter = "Python Scripts (*.py)|*.py|All Files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Multiselect = false;

                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    return openFileDialog.FileName;
                }

                return null;
            }
        }
    }
}
