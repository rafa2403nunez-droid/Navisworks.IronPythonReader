namespace Navisworks.IronPythonReader.Services
{
    /// <summary>
    /// Defines a service responsible for executing Python code within the plugin.
    /// </summary>
    public interface IPythonService
    {
        /// <summary>
        /// Executes the configured Python code.
        /// </summary>
        void ExecuteCode();
    }
}
