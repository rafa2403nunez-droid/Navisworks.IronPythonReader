using System;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Navisworks.IronPythonReader.Services
{
    internal class DialogService : IDialogService
    {
        public void ShowErrorDialog(string commandName, Exception exception)
        {
            MessageBox.Show($"There was a problem during the execution: Error:\n{exception.Message}", "Balio", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowErrorDialog(string commandName, string exceptionMessage)
        {
            MessageBox.Show($"There was a problem during the execution: Error:\n{exceptionMessage}", "Balio", MessageBoxButton.OK, MessageBoxImage.Error);
        }

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
