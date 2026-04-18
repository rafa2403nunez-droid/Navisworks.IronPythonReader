using System.Drawing;

namespace Navisworks.IronPythonReader.Utils
{
    public class IconManager
    {
        public static Icon GetExecutingAssemblyIcon(string version)
        {
            return Icon.ExtractAssociatedIcon($"C:/Program Files/Autodesk/Revit {version}/Revit.exe");
        }
    }
}
