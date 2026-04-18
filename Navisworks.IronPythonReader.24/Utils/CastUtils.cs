namespace Navisworks.IronPythonReader.Utils
{
    public static class CastUtils
    {
        public static T CastTo<T>(object obj) where T : class
        {
            return obj as T;
        }
    }
}
