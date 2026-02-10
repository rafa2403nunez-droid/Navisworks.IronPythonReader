using System;

namespace Navisworks.IronPythonReader.Services
{
    public interface IDialogService
    {
        void ShowErrorDialog(string commandName, string exceptionMessage);
        void ShowErrorDialog(string commandName, Exception exception);
        string SelectPythonFile();
    }
}
